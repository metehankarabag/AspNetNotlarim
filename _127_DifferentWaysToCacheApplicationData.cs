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

namespace _127_DifferentWaysToCacheApplicationData
{
    /*Uygulama Verisini CACHE ile depolamanın farklı yolları.
     
      Atama(=) kullanarak veriyi önbellekten ayrıma, uygulama verisini önbelleğe 2 farklı yolla alınabilir.
      1.CACHE CLASS'ının INSERT() methodu
        INSERT() methodunun 5 aşırı yüklenmiş versiyonu var. 
        Az basit olanı 2 parametre alır.
        1. parametre CACHE anahtar kelimesi
        2. parametre CACHE değeri

        Geçen derste atama kullanarak verileri ön belleğe aldık. Cache["ProductsData"] = ds;
        Aynı işi Cache.Insert("ProductsData", ds) methodu da yapar.
        Aşırı yüklenmiş durumlarını tartışacağız.
      
      2.CACHE CLASS'ının Add() methodu
        INSERT() methodundan farkı 
        Aşırı yüklenmiş durumu yok, ve tüm parametreleri girilmek zorunda. 
        Insert methodunda optional parametreler var.
        Cache.Add("ProductsData", ds, null, 
                                            System.Web.Caching.Cache.NoAbsoluteExpiration,¯¯¯¯¯¯¯¯¯¯¯|
                                            System.Web.Caching.Cache.NoSlidingExpiration,------------|--> Gelecek dersde görülecek.
                                            System.Web.Caching.CacheItemPriority.Default, null);_____|

      SERVER, CACHE nesnelerini otomatik olarak 
      SERVER'in belleğe ihtiyacı olduğunda veya belirlediğimiz CACHE süresi dolduğunda silebilir.
      CACHE nesnesini SERVER'den silinmesini istiyorsak  Cache.Remove("MyKey") methodunu kullanırız.
    
      CACHE, APPLICATION STATE'e benzerdir. 
      APPLICATION STATE değişkenlerinde tuttuğumuz nesneler uygulama içinde herhangi bir yerde gerçerlidir. 
      CACHE'de aynı şekilde geçerlidir.
      Fark CACHE içindeki nesne sonlanabilir fakat APPLICATION STATE içindeki nesne asla sonlanmaz.
     
      NOT: CACHE'ye veri ataması yaparken kullanılan anahtara dikkat etmek gerekir. Yeni veri eski verinin üzerine yazılır.
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

                Cache.Add("ProductsData", ds, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
                
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