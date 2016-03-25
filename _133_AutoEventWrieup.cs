using System;

namespace _133_AutoEventWrieup
{
    /*AutoEventWireup  
      Page yönergesinde veya CONFIG dosyasında ayarlanan bir özelliktir. 
      EVENT methodlarının EVENT'ları ile otomatik ilişkilenirilmesi için kullanılır.
      Yani varsayılan isimlerle kullandığımız methodların çalışması için bir EVENT örneği oluşturmak zorunda kalmayız.
      
      AutoEventWireup değerini TRUE yap
      Uygulamayı çalıştır.
      EVENTHANDLER methodları EVENT'lar ile ilişkilendirmedik, fakat EVENT HANDLER methodlar, EVENT'ları ile bağlantı kurabildi. 
      Bunun nedeni, AutoEventWireup özelliğinin TRUE değer olmasıdır.
     
      Şimdi FALSE değer ver.
      Yukarıdaki EVENT HANDLER methodlarından hiç biri çalışmadı. 
      Çalışması için ONINIT methodunu üzerine yazmalıyız.
      BU method PageINIT gibi sayfa başlatılırken çalışıyor.
      Bu olayda methodları olaylarla ilişkilendiriyoruz.
      
     
      Şimdi AutoEventWireup değerini true yap.
      Uygulamayı çalıştır.
      Her EVENT HANDLER methodu 2 kez çalıştırılır. 
      Bunun nedeni,
      1. AutoEventWireup değeri TRUE olursa, EVENT HANDLAR methodların birincisi kaydeder ve
      2. OnInit() methodunun üzerine yazdığımız için aynı iş bir kez daha yapılır.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page Load <br/>");
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Response.Write("Page LoadComplete <br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("Page PreRender <br/>");
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            Response.Write("Page PreRenderComplete <br/>");
        }
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.LoadComplete += new EventHandler(Page_LoadComplete);
            this.PreRender += new EventHandler(Page_PreRender);
            this.PreRenderComplete += new EventHandler(Page_PreRenderComplete);
        }
    }
}