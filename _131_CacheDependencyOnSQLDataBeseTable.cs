using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Caching;

namespace _131_CacheDependencyOnSQLDataBeseTable
{
    /*CACHE kaynağı SQL DATA BASE'de olan veri değiştiğinde, CACHE nesnesini silme
      Geçen dersteki ile aynı mantıkta burada SQL SERVER ile ilgili özel işler yapmamız gerekecek.
      
      SQL SERVER'deki DEPENDENCY'i aktifleştirmek için kullanıyoruz.
        System.Web.Caching.SqlCacheDependencyAdmin.EnableNotifications(CS) --> ilk önce bağlantıyı
        System.Web.Caching.SqlCacheDependencyAdmin.EnableTableForNotifications(CS, "tblProducts"); --> bağlantı kullanacağımız tabloyu

      Alternatif  aktivasyon için aspnet_regsql.exe'yi yükledikten sonra
        Vs command prompt ve çalıştır aşağıdaki 2 komutu gir.
        
        Aspx131 veri tabanında SqlCacheDependency aktif etmek için 
        aspnet_regsql -ed -E -d Aspx131

        Aspx131 veri tabanındaki tblProducts tablosunun SqlCacheDependency özelliğini aktif etmek için
        aspnet_regsql -et -E -d Sample -t tblProducts

        et, -E, -d, -t, nin amacını anlama ihtiyacın varsa --> aspnet_regsql ? 'i çalıştır.

        pollTime özelliği 2000'e ayarladı. 
        ASP.NET her 2 sn ye'de değişiklikler için Veri kaynağını kontrole edecek. Varsayılanı 0,5 sn dir.

        Uygulamayı çalıştır ve biz Get Products butonuna tıkladığımızda ilk sefer içini veri databaseden yüklenir. 
        Tekrar tıkla, veri önbellekden yüklenmeli. Şimdi aşağıdaki Güncelleme sorgusunu çalıştır.

        Update tblProducts set Name='Laptops' where Id = 1

      Şimdi tekrar butona tıkla ve dikkat et önbellekten varolan veri silindiği için veri database'den yüklenir. 
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
                SqlDataAdapter da = new SqlDataAdapter("select * from tblProducts", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                
                SqlCacheDependency sqlDependency = new SqlCacheDependency("Part131", "tblProducts");
                                
                Cache.Insert("ProductsData", ds, sqlDependency);

                gvProducts.DataSource = ds;
                gvProducts.DataBind();
                lblStatus.Text = "Data retrieved from database @ " + DateTime.Now.ToString();
            }
        }
    }
}