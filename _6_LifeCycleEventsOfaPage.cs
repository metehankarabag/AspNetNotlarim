using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _6_LifeCycleEventsOfaPage
{
 /*ASP.NET PAGE LİFE CYCLE EVENTS
   Aşağıdakiler ASP.NET hayat çemberinde çoğunlukla kullanılan olayların bazılarıdır.
   Sadece işlenemeyen bir işe göre çalışan ERROR olayı hariç(except), olaylar olay (occurrence) sırasına göre gösteriliyor.
   
   PRE(ön) Init : Adındanda anlaşılacağı gibi(as the name suggests), Bu olay PAGE INITIALZETION olayından hemen önce çalışır. 
   IsPostBack, IsCallBack and IsCrossPagePostBack özellikleri bu evrede(stage) ayarlanır. 
   Bu olaylar dinamık olarak web uygulama teması ve MASTER PAGE ayarlamamıza izin verir.
   PREINIT dinamık kontrollerle çalışırken kapsamlı olarak(extensively) kullanılır.
   
   INIT : Bir WEBFORM'daki bireysel kontrollerin hepsinin INIT olayından sonra PAGE INIT olayı oluşur. 
   Bu olayı kontrol öelliklerini başlatmak veya okumak için kullan. Sunucu kontrolleri yüklenir ve web formun VIEW state'inden çalıştırılır.
   INIT Complate : Adındanda anlaşılacağı gibi, Bu olay PAGE INITIALIZETION'dan hemen sonra çalışır.
   PRELOAD: PAGE LOAD olayından hemen önce olur.
   LOAD : PAGE LOAD olayı web formataki bireysel kontrollerin tamamının yüklenme olayından hemen önce çalışır.
   CONTOL EVENTS : PAGE LOAD olayından sonra, BUTTON CLİCK, DROPDOWNLIST'in SelectIntextChanced olayı gibi kontrol olayları çalışır.
   LOAD COMPLATE: Bu olay Control olayları işlendikten sonra çalışır.
   PRERENDER : Bu olay sayfanın işleme aşaması öncesinde çalıştırılır.
   PRERENDERCOMPLATE : PRERENDER olayından hemen sonra çalıştırılır.
   UNLOAD : Her kontrol için ve çok geçmeden PAGE için çalışır. Bu aşamada sayfa hafısaya yüklenmemiştir. Bu olay sadece bir hata varsa çalışır.
 */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        { Response.Write("Page_PreInit"+ "<br/>"); }
        protected void Page_Init(object sender, EventArgs e)
        { Response.Write("Page_Init" + "<br/>"); }
        protected void Page_InitComplete(object sender, EventArgs e)
        { Response.Write("Page_InitComplete" + "<br/>"); }
        protected void Page_PreLoad(object sender, EventArgs e)
        { Response.Write("Page_PreLoad" + "<br/>"); }
        protected void Page_Load(object sender, EventArgs e)
        { Response.Write("Page_Load" + "<br/>"); }
        protected void Page_LoadComplete(object sender, EventArgs e)
        { Response.Write("Page_LoadComplete" + "<br/>"); }
        protected void Page_PreRender(object sender, EventArgs e)
        { Response.Write("Page_PreRender" + "<br/>"); }
        protected void Page_ReRenderComplete(object sender, EventArgs e)
        { Response.Write("Page_ReRenderComplete" + "<br/>"); }
        protected void Page_Unload(object sender, EventArgs e)
        { /*Response.Write("Page_Unload" + "<br/>"); -->sayfa devre dışı olduğu için hata verecek*/ }
    }
}