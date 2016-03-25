using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _70_ErrorEvents
{
    /*Error Event
      TRY-CATCH kullanarak EXCEPTIONS HANDLING çoğunlukla STRUCTURED EXCEPTION HANDLING olarak adlandırılır.
      ASP.NET 2 hata olayı sağlar.
      
      PAGE_ERROR - Sayfada UNHANDLED EXCEPTION olduğunda, bu EVENT sayfa düzeyinde çalışır. 
         EVENT HANDLER'i sayfada bulunur.
      APPLICATION_ERROR - APPLICATION düzeyinde UNHANDLED EXCEPTION olduğunda, 
         bu EVENT APPLICATION düzeyinde yükselir. EVENT HANDLER GLOBAL.ASAX dosyasında bulunur.
      
      Bu hata EVENTS'ı STRUCTURED EXCEPTION HANDLING'e bir ek veya vekil olarak kullanılabilir.
      
      COUNTRIES.XML'den XML verisi okumayı dene FILE NOTFOUND hatası alıyoruz.
      Kodu TRY içinde yazmadığımız için hata PAGE_ERROR EVENT HANDLER ile sayfa düzeyinde işlenir. 
      
      PAGE_ERROR EVENT HANDLERS kullanımı
      1. SERVER.GETLASTERROR() son gerçekleşen hata ile bir EXCEPTION nesnesi oluşturururz.
      2. APPLICATION düzeyine yayılmasın diye hatayı SERVER'dan sileriz.
      3. Aynı sayfada sorunu düzelmeye calışır veya sorunu kullanıcıya bildirebiliriz. 
         Veritabanında, EVENT VIEWER'da sorunu kaydedip, geliştirme takımına hatayı bildirebiliriz. 
         (Biz sonraki derslerde bildirimleri ve yazdırmayı tartışacağız.)
         Bu EXCEPTION ile kullanıcıyı EROR sayfasında gönderebiliriz.        
      
      Lütfen Dİkkat et
      1. EXCEPTION PAGE_ERROR EVENT'da silinmesse, uygulama düzeyine yayılır ve APPLICATION_ERROR EVENT HANDLER çalıştırılır. 
         Biz APPLICATION düzeyinde EXCEPTION'ı temizlemiyorsak, uygulama YELLOW SCREEN OF DEATH ile çöküyor.
      2. EXCEPTION temizlenir ve ERORR.ASPX'e yeniden yönlendirime yapılmassa, o zaman boş sayfa görünür. 
         Bunun nedeni EXCEPTION ortaya çıktığında WEBFORM işlemleri aniden durdurulmasıdır.

      Bir EXCEPTION PAGE düzeyinde PAGE_ERROR EVENT'i kullanılarak işlenmemişse, 
      APPLICATION düzeyine gider ve GLOBAL.ASAX'daki APPLICATION_ERROR EVENT HANDLER kullanılarak işlenebilir ve 
      hatayı işleme için tebir belirtilmiş yer olarak kullanılabilir.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Data/Countries.xml"));
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Server.ClearError();
            Response.Redirect("Errors.aspx");
            
        }
    }
}
