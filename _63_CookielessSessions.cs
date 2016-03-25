using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _63_CookielessSessions
{
    /*COOKIELESS SESSIONS
     SESSION'lar varsayılan olarak COOKIE kullanılır.
     SESSIONS - ID CLIENT tarafında bir COOKIE olarak alınır. 
     Bu SESSIONS - ID isteğin aynı kullanıcıdan gelip gelmediğini belirlemek için 
     WEB SERVER tarafından kullanılır.
     
     Geçen dersteki uygulamayı bu derste kullanıyoruz.
     
     Google Chrome'da uygulamayı oturum COOKIE'sini göstermek için bir kez çalıştır.
     1. Tarayıcıya sağ tıkla --> INSPECT ELEMENT -->RESOURCES --> COOKIES'i aç. --> LOCALHOST'u seç.
     5. ASP.NET_SessionId ile bir COOKIE'yi artık görmeliyiz.

     Şimdi COOKEIES görünmez yapalim. CHOROME'da COOKIE'leri görünmez yapmak için
     1. Taryıcı ayarlarından - COOKIES ara - arama sonuçlarında gizlilik altındaki butona "içerik ayarları" tıkla.
     4. "cookies" altında,  Block sites from setting any data seç ve ok a tıkla
	
     Uygulamayı tekrar çalıştır. WEBFORM1'de girdiğin bilgileri WEBFORM2'de alamazsın.
     COOKIES görünmez oluduğunda, SESSION ID SERVER'e gönderilmez.
     Yani SERVER WEBFORM2.ASPX için gelen istediğin kimden geldiğini çıkartamaz. 
     Bu yüzden WEBFORM2.ASPX de bu alanlar görünmez.
	
     Bazı kullanıcılar, bilgisyarlarına bilgi yazan websiteleri sevmezlar. 
     Bu durumda, COKIES gerektiren uygulama düzgün çalışamaz.
     COOKIESLEES SESSION'lar bu sorunu çözmek için var.
     SESSION'ı WEB.CONFİG dosyasında göründüğü gibi ayarla. --> <sessionState mode="InProc" cookieless="true"></sessionState>

     Dikkat et SESSION - ID artık URL nin bir parçası. 
     Bu ID ter tarayıcı isteği ve cevabında URL ile gider gelir. Böylecek kullanıcı tanımlanmış olur.

     Farklı WEBFORM'lar kullanıcıları yeniden yönlendirirken, 
     uygulamaya bağlı URL'ler COOKIELESS oturumun düzgün çalışması için kullanılmalı. 
     Örneğin http://pragimtech.com/WebForm1.aspx bu sayfadaki WEBFORM2'ye gitceksen ~ile gidiceksin diğer türlü olmaz
     
     Response.Redirect("~/WebForm2.aspx") - Relative URL
     and not
     Response.Redirect("http://pragimtech.com/WebFOrm2.aspx") - Absolute URL (or Complete Path) 
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSendData_Click(object sender, EventArgs e)
        {
            Session["Name"] = txtName.Text;
            Session["Email"] = txtEmail.Text;
            Response.Redirect("WebForm2.aspx");
        }
    }
}