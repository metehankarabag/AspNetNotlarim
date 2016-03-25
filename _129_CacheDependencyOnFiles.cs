using System;
using System.Data;
using System.Web.Caching;

namespace _129_CacheDependencyOnFiles
{
    /*Dosyadaki veriye bağımlı önbellek
      Bir CACHE verisinin başka bir veri/veri kümesi ile karşılaştırılması CACHE bağımlılığıdır.
      Karışaştırılacak verinin bir dosyadan gelmesi CACHE'nin dosya bağımlılıdır.
      Karışlaştırma sonucunda veriler farklıysa, CACHE silinir.
      
      Karşılaştırılacak veri Insert() metthodunun 3. parametresine eklenir.
      Bu parametre değer olarak CacheDependency nesnesi bekliyor. 
      Bu yüzden karışlaştırılacak veriyi CacheDependency CONSTRUCTER'ine giriyoruz.
      
      3. paremtreye CacheDependency yerine null girilirse karşılaştırma yapılmaz.
      Veriyi dosyadan aldığımız için CacheDependency CONTRUCTER'ına dosya yolunu giriyoruz.
      
      Artık dosyadan gelen veriyi CACHE'ye aldıktan sonra, dosyada değişiklik yaparsak, CACHE silinir.
      
      CACHE kotrolü uygulamanın başlangıç EVENT'lerinden birinde yapılıyor galiba
      Çünkü Aşağıdaki kodun çalışması için Buton CLICK EVENT'ine gelmeden CACHE'nin silinmiş olması gerekiyor. Silinmesse hep if'e girer.
      
    */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnGetCountries_Click(object sender, EventArgs e)
        {
            if (Cache["CountriesData"] != null)
            {
                DataSet ds = (DataSet)Cache["CountriesData"];
                gvCountries.DataSource = ds;
                gvCountries.DataBind();
                lblMessage.Text = ds.Tables[0].Rows.Count.ToString() + " rows retrieved from cache.";
            }
            else
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/Data/Countries.xml"));

                Cache.Insert("CountriesData", ds, new CacheDependency(Server.MapPath("~/Data/Countries.xml")), 
                    DateTime.Now.AddSeconds(20), Cache.NoSlidingExpiration);

                gvCountries.DataSource = ds;
                gvCountries.DataBind();
                lblMessage.Text = ds.Tables[0].Rows.Count.ToString() + " rows retrieved from the file.";
            }
        }
    }
}