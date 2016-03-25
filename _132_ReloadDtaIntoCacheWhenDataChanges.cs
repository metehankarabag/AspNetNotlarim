using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Caching;

namespace _132_ReloadDtaIntoCacheWhenDataChanges
{

    /*
      Database tablosudaki temeli oluşturan veri değiştiğinde, veriyi önbelleğin içine otomatik olarak yeniden yükleme hakkında tartışacağız. 
      
      Önbellek içine otomatik olarak veri yüklemek için, önbelleğe alınmış veri silindiğinde, çalışması için bir CALLBACK methodu tanımlamamız gerekir. 
      CACHE'deki item silindiğinde bu method çalıştırılacak
      Yani veriyi yeniden yüklemek ve önbelleğe almak için gerekli kod, bu methodda yazılabilir. 
      BU işin olabilmesi için CacheItemRemovedCallback DELEGATE'si ile methodu çağarmalıyız.
      
     130. ders ile aynı mantık
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnGetData_Click(object sender, EventArgs e)
        {
            if (Cache["ProductsData"] != null)
            {
                gvProducts.DataSource = Cache["ProductsData"];
                gvProducts.DataBind();
                lblStatus.Text = "Data retrieved from cache @ " + DateTime.Now.ToString();
                
            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                System.Web.Caching.SqlCacheDependencyAdmin.EnableNotifications(CS);
                System.Web.Caching.SqlCacheDependencyAdmin.EnableTableForNotifications(CS, "tblProducts");

                SqlConnection con = new SqlConnection(CS);
                SqlDataAdapter da = new SqlDataAdapter("spGetProducts", con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                CacheItemRemovedCallback onCacheItemRemoved = new CacheItemRemovedCallback(CacheItemRemovedCallbackMethod);
                SqlCacheDependency sqlDependency = new SqlCacheDependency("Aspx131", "tblProducts");
                Cache.Insert("ProductsData", ds, sqlDependency, DateTime.Now.AddMinutes(1), Cache.NoSlidingExpiration, CacheItemPriority.Default, onCacheItemRemoved);
                // Pass SqlCacheDependency object, when caching data
                Cache.Insert("ProductsData", ds, sqlDependency);
                gvProducts.DataSource = ds;
                gvProducts.DataBind();
                lblStatus.Text = "Data retrieved from database @ " + DateTime.Now.ToString();
            }
            
        }

        public void CacheItemRemovedCallbackMethod(string key, object value, CacheItemRemovedReason reason)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("spGetProducts", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            CacheItemRemovedCallback onCacheItemRemoved = new CacheItemRemovedCallback(CacheItemRemovedCallbackMethod);
            SqlCacheDependency sqlDependency = new SqlCacheDependency("Aspx131", "tblProducts");
            Cache.Insert("ProductsData", ds, sqlDependency, DateTime.Now.AddMinutes(1), Cache.NoSlidingExpiration,
    CacheItemPriority.Default, onCacheItemRemoved);
        }
    }
}