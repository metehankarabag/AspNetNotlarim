using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Caching;

namespace _128_AbsuluteExpirationSlidingExpirationCacheItemPriority
{
    /*Absulute Expiration, Sliding Expiration, Cache Item Priority

      Oluşturduğumuz CACHE'nin SERVER'de ne kadar kalacağını belirlemenin 2 yol var.
     
      1.AbsoluteExpiration: CACHE'nin ne zaman silineceğini belirtiriz. 
        Bunun için gelecekte bir zaman belirtmeliyiz.
        DateTime.Now.AddSecond() -Year, month, bu methodlar geçerli zamana, zaman ekler ve gelecekte bir zaman belirtir.
    
      2.SlidingExpiration: CACHE'ye yapılan son bağlantıdan sonra CACHE'nin kalacağı süreyi belirler.
        Eklenen süre içinde başka bir bağlantı olmassa CACHE silinir.
        Bunu yapamak için TimeSpan.FromSeconds(10) CLASS'ını kullanır.

      Uygulama verisinin depolanma zamanını belirtirken, bu PROPERTY'leri aynı anda kulanamayız. Kullanırsak hatalırız.
      'absoluteExpiration must be DateTime.MaxValue or slidingExpiration must be timeSpan.Zero' ile başlayan bir RUN-TIME hatası alırsın.

        CacheItemPriority: SERVER çalışabilmek için hafıza ihtiyac duyduğunda, ihtiyacı olan hafızaya ulaşmak için sonlanmamış nesneleri silebilir.
        CacheItemPriority CACHE'nin saklanma önceliğini belirler.
        SERVER hafızaya ihtiyac duyduğunda çalışma, saklanma önceliği en düşü olan ilk önce silinir.
        CacheItemPriority enum values:
        CacheItemPriority.Low
        CacheItemPriority.BelowNormal
        CacheItemPriority.Normal - Varsayılan değerdir.
        CacheItemPriority.Default
        CacheItemPriority.AboveNormal
        CacheItemPriority.High
        CacheItemPriority.NotRemovable
        
      SERVER çalışmak içi CACHE silme ihtiyacı duyarsa. Hiç silinmesini istemediğimiz nesneleride silebilir.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {   
        protected void btnGetProducts_Click(object sender, EventArgs e)
        {
            DateTime dtStartDateTime = DateTime.Now;
            System.Text.StringBuilder sbMessage = new System.Text.StringBuilder();
            if (Cache["ProductsData"] != null)
            {
                DataSet ds = (DataSet)Cache["ProductsData"];
                gvProducts.DataSource = ds;
                gvProducts.DataBind();
                sbMessage.Append(ds.Tables[0].Rows.Count.ToString() + " rows retrieved from cache.");
            }
            else
            {
                DataSet ds = GetProductsData();
                //Cache["ProductsData"] = ds;

                //Cache.Insert("ProductsData",ds);
                Cache.Add("ProductsData", ds, null, DateTime.Now.AddSeconds(10), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);          
                
                gvProducts.DataSource = ds;
                gvProducts.DataBind();
                sbMessage.Append(ds.Tables[0].Rows.Count.ToString() + " rows retrieved from database.");
            }
            DateTime dtEndDateTime = DateTime.Now;
            sbMessage.Append((dtEndDateTime - dtStartDateTime).Seconds.ToString() + " Seconds Load Time");
            lblMessage.Text = sbMessage.ToString();
        }

        private DataSet GetProductsData()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter("spGetProducts", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataSet dsProducts = new DataSet();
            da.Fill(dsProducts);

            return dsProducts;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cache.Remove("ProductsData");
            lblMessage.Text = "The cached item is removed";
        }
    }
}