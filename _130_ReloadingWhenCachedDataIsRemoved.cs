using System;
using System.Data;
using System.Web.Caching;

namespace _130_ReloadingWhenCachedDataIsRemoved
{
    /*CACHE silindiğinde yeniden yükleme
      Geçen derste CACHE'yi bir dosyaya bağlamıştık. Dosya verisi değiştiğinde CACHE silindi.
      Bu derste CACHE silindiğinde dosyadaki yeni verilerle yeniden yükleceğiz.
      
      Yeniden yükleme işlemi için INSERT() methodunun 7. parametresini kullanıyoruz.
      Bu parametre INSERT() methodunda belirttiğimiz CACHE her silindiğinde çalışır ve 
      parametre tür olarak CacheItemRemovedCallback DELEGATE'i ister.
      Yani CACHE her silindiğinde CacheItemRemovedCallback DELEGATE'i çalışır.
      DELEGATE, CONSTRUCTER'ine verdiğimi parametreyi çalıştıracağı için CACHE her silindiğinde belirttiğimiz method çalışır.
      
      CacheItemRemovedCallback parametre olarak
      1. parametresi string key, 
      2. parametresi object value, 
      3. parametresi CacheItemRemovedReason reason
      olan 3 parametreli bir method istiyor.
      
      DELEATE örneğini(method temsilcisini) INSERT() methodun 7. parametreye ekliyoruz. (DELEGATE'i anonymous olarak parametre içinde de kurabilirdik.)
      
      DELEGATE'i kuraraken veya 7. parametreye eklerken method paramtrelerine değer vermedik. Mantıklı da değil.
      Çünkü DELEGATE metohdunda yaptığımız işlem, INSERT() methodundaki sonuçlardan gelen CACHE'ye yapılıyor.
      Yani paremtre değerleri INSERT() metohdu veriyor.
      DELEGATE örneği 2 şekilde kullanılabilir. Örneği Field gibi kullanmak veya method gibi parametre girerek kullanmak.
     */

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnLoadCountriesAndCache_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Data/Countries.xml"));
            CacheItemRemovedCallback onCacheItemRemoved = new CacheItemRemovedCallback(CacheItemRemovedCallbackMethod);

            Cache.Insert("CountriesData", ds, new CacheDependency(Server.MapPath("~/Data/Countries.xml")), 
                                DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration, 
                                CacheItemPriority.Default, 
                                onCacheItemRemoved);

            gvCountries.DataSource = ds;
            gvCountries.DataBind();
            lblMessage.Text = ds.Tables[0].Rows.Count.ToString() + " rows retrieved from XML file.";
        }

        protected void btnGetCountriesFromCache_Click(object sender, EventArgs e)
        {
            if (Cache["CountriesData"] != null)
            {
                DataSet ds = (DataSet)Cache["CountriesData"];
                gvCountries.DataSource = ds;
                gvCountries.DataBind();
                lblMessage.Text = ds.Tables[0].Rows.Count.ToString() + " rows retrieved from cache.";
            }
            else
                lblMessage.Text = "Cache item with key CountriesData is not present in cache";
        }

        protected void btnRemoveCachedItem_Click(object sender, EventArgs e) { Cache.Remove("CountriesData"); }

        public void CacheItemRemovedCallbackMethod(string key, object value, CacheItemRemovedReason reason)
        {
            string dataToStore = "Cache item with key = \"" + key + "\" is no longer present. Reason = " + reason.ToString();
            Cache["CacheStatus"] = dataToStore;

            #region
            /*
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("insert into tblAuditLog values('" + dataToStore + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Reload data into cache
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Data/Countries.xml"));

            CacheItemRemovedCallback onCacheItemRemoved = new CacheItemRemovedCallback(CacheItemRemovedCallbackMethod);
            Cache.Insert("CountriesData", ds, new CacheDependency(Server.MapPath("~/Data/Countries.xml")), DateTime.Now.AddSeconds(60),
            System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, onCacheItemRemoved)
            
            */
            #endregion
        }

        protected void btnGetCacheStatus_Click(object sender, EventArgs e)
        {
            if (Cache["CountriesData"] != null) lblMessage.Text = "Cache item with key \"CountriesData\" is still present in cache";
            else if (Cache["CacheStatus"] != null) lblMessage.Text = Cache["CacheStatus"].ToString();


        }
    }
}