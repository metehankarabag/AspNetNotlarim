using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _87_WindowsAuthentication
{
    /*WINDOWS AUTHENTICATION
      Rezervasyon, sipariş gibi özel bilgiler içeren bir sayfaya, herkesin girebilmesini engellemeliyiz. 
	  Bu derste kullanıcıyı kullandığı WINDOWS kimliği ile sayfada kimliklendirmeyi göreceğiz.
      ASP.NET uygulamalarının güvenliği 2 düzeyde yapılır.
      IIS ve web uygulamasının kendisinde.
      
      WINDOWS AUTHENTICATION, SERVER'in kullanıcı listesi baz alarak kullanıcıları belirtir ve yetkilendirir. 
      Kullanıcı hesabının ayrıcalıklarını baz alarak. 
	  SERVER'daki kaynaklara erişime izin verilir veya engellenir.
      INTRANET WEP APPLICATION için en uygunu olandır.
       
      WINDOWS AUTHENTICATION kurumsal ağına uyguladığın güvenlik şemasının aynısını, WEB APPLICATION'da da kullanmanı sağlar.
      Kullanıcı adları, şifreleri ve izinleri ağ kaynakları ve WEB APPLICATION için aynıdır.
      
      IIS'de ANONYMOUS AUTHENTICATION açıkken, WINDOWS AUTHENTICATION'ı açsan bile.
      Uygulama çalışırken uygulama kod ANONYMOUS kimliği ile çalışır.
      Bu yüzden ANONYMOUS kimliği ile girişin engellenmesi gerekir.
	  IIS'de engellersek TÜM uygulamada kapanır. Bu yüzden CONFIG dosyasında eliyoruz.
      <authorization> <deny users="?"/> </authorization>
      
      Uygulamayı çalıştır
      Kullanıcı, kullandığı WINDOWS ACCOUNT kullanılarak kimliklendirildi.
      Ayrıca Dikkat et uygulama kodu APPLICATION POOL IDENTITY ile çalıştırılıyor.
      
      Oturumu açmış kullanıcı kimliğini kullanarak çalıştırılan uygulama kodlarına sahip olmak istiyorsan, ozaman IMPERSONATION'a izin ver. 
      Bu iş veya alttaki kodu WEB.CONFIG'e ekleyerek yapılabilir.
      <identity impersonate="true"/>
      
      IMPERSONATION açıksa, UYGULAMA kullanıcı hesabında bulan izinleri/yetkileri kullanarak çalışır. 
      Yani, girişli kullanıcının özel bir kaynağa bağlantısı varsa, sadece o zaman uygulama sayesinde kaynağa ulaşabilecek.
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