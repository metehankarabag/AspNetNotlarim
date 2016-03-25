using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _7_EventsOfServerControls
{
    /*ASP.NET SERVER CONTROL EVENTS
    Textbox,Button,DropDownList gibi her asp.net SUNUCU CONTROL'ünün EVENT'ları vardır. 
	Bizim VALIDATION olaylarının olduğu, ASP.NET VALIDATION CONTROLleri kümemiz var. 
	Bu kontrollerin ortaya çıkardığı bu olay, 3 katagoriye ayrılabilir.
 
    POSTBACK EVENTS: Bu olaylar işleme(porcessing) için servere sayfayı hemen gönderir. 
	Postback olayı için BUTTON kontrolünün tıklamayı olayı bir örnektir.
 
    CACHED EVENTS: Bu olaylar POSTBACK olayı çalıştığında işletilmek için PAGE'nın VIEW state'sinde kaydedilir. TEXTBOX CONTROL'ünün TEXTCHANGED ve DROPDOWNLIST'in SELECTEDINDEXCHANGE olayı ön bellek(cached) olayları için örneklerdir. CACHED olayları, kontrollerin AutoPostBack özelliğini TRUE olarak ayarlayıp eklenerek POSTBACK olayları içinde çevirilebilir.

    VALIDATION EVENTS: Bu olaylar PAGE servere postalanmadan önce CLIENT'da ortaya çıkar. VALİDATİON kontrollerini böyle kullan.
 */
    /*Çalışma sırası
     PAGE_LOAD olayından sonra sırayla
     CACHED, POSTBACK olayları çalışır.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        { Response.Write("Page_PreInit" + "<br/>"); }
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
        protected void Page_PreRenderComplete(object sender, EventArgs e)
        { Response.Write("Page_PreRenderComplete" + "<br/>"); }
        protected void Page_Unload(object sender, EventArgs e)
        {}
        
        protected void Button1_Click(object sender, EventArgs e)
        { Response.Write("Button Click" + "<br/>"); }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        { Response.Write("Text Changed" + "<br/>"); }
    }
}
