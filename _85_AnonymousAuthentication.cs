using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _85_AnonymousAuthentication
{//http://csharp-video-tutorials.blogspot.com/2012/12/anonymous-authentication-in-aspnet-part.html
    /*ANONYMOUS AUTHENTICATION
      Varsayılan olarak kullanılan kimlik türüdür. 
      IIS'te bu açık diğerleri kapalıdır. 
      Bunu IIS'ten veya WEB.CONFİG'den kapatabiliriz hepsi kapalı olursa hata verecek. 
      UNAUTHORIZED hatası kodlar WEB.CONFİG'de 
          
      AUTHENTICATION - kullanıcı kim?(hangi bağlantı kimliğini kullanmış)
      AUTHORİZATION - hangi hakları var ve hangi kaynaklara erişebilir(bağlantı kimliğinine verilen izinleri denetliyor)
      
      Kamu web sitelerinin çoğu kullanıcı adı ve şifre girmeyi sormaz. 
      Buna rağmen Sitelere erişebileceğiz. ASP.NET WEB APPLICATION SERVER'deki kaynaklara adsız erişim sağlar. 
      ANONYMOUS AUTHENTICATION bir kullanıcı adı ve şifre sormadan kullanıcının web sitesinin ortak alanlara bağlantı kurmasına izin verir.
      
      Uygulamayı IIS'e al ve APPLICATION POOL olarak DefultAppPool kullan. 
      
      In IIS 6.0 --> IUSR_ComputerName is used for providing anonymous access.
      In IIS 7.0 --> IUSR account is used for providing anonymous access. 
      
      Varsayılan olarak IIS'DE ANONYMOUS AUTHENTICATION açıktır 
      IIS --> root > Sites > Default Web Site --> your web application -->features --> dobule click Authentication
      5. Notice that, anonymous authentication is enabled by default.
      
      Uygulamayı çalıştır. Dikkat et, APPLICATION POOL IDENTITY uygulama kodunu çalıştırmak için kullanılır. 
            
      ANONYMOUS ACCES ile ilişkilendirilen hesabı değiştirmek için, Edit e tıkla ACTION altında 
      Dikkat et varsayılan kullanıcı IUSR. Bu CUSTOM WINDOWS ACCOUNT veya APPLICATION POOL IDENTITY ile değiştirilebilir.
     */
    /*
      <!--<deny users="?"/>--><!--?: KİMLİKSİZ KULLANICILARI BELİRTİR DENY İLE ENGELLEDİK--><!--
      <allow users="*"/>--><!--* TÜM KULLANICILARI BELİRTİR İZİN VERDİR. KULLANDIĞIMIZ BİR KİMİK OLMADIĞI İÇİN GİREMİYORUZ. ÇÜNKÜ ÜSTTE ENGELLENDİ.-->*/
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Application code executed using ");
            Response.Write(System.Security.Principal.WindowsIdentity.GetCurrent().Name + "<br/>");

            Response.Write("Is User Authenticated: ");
            Response.Write(User.Identity.IsAuthenticated.ToString() + "<br/>");

            Response.Write("Authentication Type, if Authenticated: ");
            Response.Write(User.Identity.AuthenticationType + "<br/>");

            Response.Write("User Name, if Authenticated: ");
            Response.Write(User.Identity.Name + "<br/>"); 
        }
    }
}