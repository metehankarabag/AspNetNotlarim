using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _86_AnnoymousImpersonation
{
    //http://csharp-video-tutorials.blogspot.com/2012/12/anonymous-authentication-and-aspnet.html
    /*IMPERSONATION
      IIS'den ENABLE veya DISABLE yapılabilir
      
      1. ISS'de uygulamayı şeç --> AUTHENTICATION'a çift tıkla --> ASP.NET IMPERSONATION'ı seç --> IIS panelinin sağındaki ACTION alanının altındaki DİSABLE veya ENABLE'a tıkla --> Bu işlem otomatik olarak WE:CONFİG dosyasını değiştirir.
      
      Şimdi uygulamayı çalıştırırsan aşağıdaki hatayı alabilirisin
      HTTP Error 500.24 - Internal Server Error
      An ASP.NET setting has been detected that does not apply in Integrated managed pipeline mode.
      Bunu düzeltmek için, bizim DEFAULTAPPPOOL'un MANAGED PIPELINE MODE özelliğini CLASSIC olarak ayarlamamız gerelir.
      
      Uygulama kodunu artık 'IIS APPPOOL\DefaultAppPool' yerine 'NT AUTHORITY\IUSR hesabı ile çalıştırılıyor
      
      Yani, uygulama ANONYMOUS AUTHENTICATION kullandığında
      IMPERSONATION DISABLE olursa, APPLICATION POOL IDENTITY kodu çalışıtır.
      IMPERSONATION ENABLE olursa, 'NT AUTHORITY\IUSR' hesabı kodu çalışıtır.
      
      NOT: IIS 'NT AUTHORITY\IUSR' yani SYSTEM'de çalışıyorsa. MANAGED PIPELINE MODE INTEGRATED olabilir.
      
      IUSR üzerinde APP POOL identity kullandığında
      
      ANONYMOUS ACCOUNT olarak IUSR ile bir makinede barındırılan 2 veya daha fazla site varsa,
      o zaman onlar birbirlerinin içeriklerine bağlantı kurabilirler. 
      Her APPLICATION'ın içeriğini korumak istiyorsak,
      APLICATIONS farklı APPLICATION POOLS'da datığılabilir ve 
      NTFS dosyaları izinleri kendi APPLICATION POOLS IDENTITY için ayarlanabilir.
     
      Uygulama kodu NT AUTHORITY\IUSR kullanarak çalışıyor.
      Bu başlangıçta SERVER'deki kaynaklara ANONYMOUS ACCOUNT bağlantı kurabilmesini saplayan hesaptır.(Kaynaklara IIS ile gidiliyor.)
      Bu IIS'ın kullandığı hesaptır.
      İstek ASP.NET'e gittiğinde bile, aynı hesap uygulama kolarınıda çalıtırıyor.(Yani IIS kodları çalıştırmıyor)
      Çünkü senin impersonation a izin var. Bu yüzden uygulama kodlarını çaştırmak için IIS hesabı kullanılır.

      Yani normalde ISS ile ASP.NET ile sadece bağlantı kurarsın. 
      Kod kullanıcının kendi bilgisayarında çalışır.
      ISS impersonate özelliği verirsen kod IIS'ın çalıştığı kimlikle çalışır.     
     */
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Countries.xml"));// bir şey öğrendik server.mappath  proje yolunu veriyor.
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}