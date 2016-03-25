using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4_LifeCycleEventsOfaWebApplication
{
    /*
      Bir web uygulamasında olaylar 3 seviyede oluşur.
      1. Uygulama düzeyinde(Example : Aplication start)
      2. Sayfa düzeyinde(Example : Page_load)
      3. Kontrol düzeyinde(Example : Button Click)
      
      
      VIEW STATE değişkenleri sayfayı POSTBACK boyunca korumak(preserve) için kullanılır. 
	  Varsayılan olarak, bir sayfanın VIEW STATE'i, başka bir sayfada geçerli değildir.
      Bir WEBFORM'dan diğerine veri gönderme teknikleri
      1.QUERY STRINGS
      2.COOKIES
      3.SESSION State
      4.APPLICATION State
      Bunlar bir sayfadan diğerine veri aktarır.
      
      SESSION STATE değişkenleri her sayfada geçerli, fakat sadece verilen tek bir SESSION için.
      SESSION değişkenleri tekil bir kullanıcının evrensel verisi gibidir. 
	  Sadece geçerli SESSION kendi SESSION STATE'na bağlanabilir.
      APPLICATION STATE değişkenleri tüm sayfalarda ve SESSION'larda geçerlidir.
      APPLICATION STATE değişkenleri çoklu kullanıcıların evrensel verisi gibidir. 
	  Tüm SESSION'lar APPLICATION STATE değişkenlerini okuyabilir ve yazabilir.
	*/
    /*APPLİCATİON LEVEL
      Bir ASP.NET web uygulamasında, Global.asax dosyası APPLICATION seviyesinde olaylar içerir. 
	  (Genellikle, APPLICATION olayları APPLICATION'nın geçerli SESSIONS için geçerli olması gereken veriyi başlatmak için kullanılırken.) 
	  SESSION olayları sadece verilen bireysel(individual) SESSION için geçerli olması gereken veriyi başlatmak için kullanılır, fakat birden fazla SESSION için geçerli değildir.
     */
    /*WHAT İS A SESSİON
      Bir web APPLICATION'ında SESSION nedir?
      A SESSION bir tarayıcının özel bir örneğidir. 
  
      Bir SESSION-id'yi nasıl alırız ve SESSION_Start() olayını çalıştırmak için nasıl zorlarız?
      1. Varolan tarayıcı pencerelerini kapat ve ondan sonra web tarayıcının yeni bir örneğini aç. 
      2. Farklı bir tarayıcının yeni gör örneğini aç.
      3. cookies-less SESSION'ları kullan <sessionState mode = "InProc" cookiesless="true"></sessionState>
      Bunu yaptığımızda kullanıcının oturum idd url de görünüyor
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Number of applications : " + Application["TotalApplications"]);
            Response.Write("<br/>");
            Response.Write("Nubmer of sessions     : " + Application["TotalUserSessions"]);
        }
    }
}