using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _88_WindowsAuthentication
{
    /*WINDOWS AUTHENTICATION

     WEB.CONFIG içinde AUTHORIZATION eleman kullanıldığında ? ve * özel anlamlara gelir.

     ? -  Anonymous kullanıcıları belirtir.(kullanıldığı keyde)
     * - Tüm kullanıcıları belirtir.(Anonymous kullanıcıları ayırabilir.)

     Belirli kullanıcılara erişimi açma veya kapama

     WEB.CONFIG'de aşağıdaki AUTHORIZATION listesi ile uygulamayı çalıştırdığında, izin verilen kullanıcılar sadece VENKAT ve PRAGIM'dir. 
     Diğer kullanıcı olarak bilgisayara girersen, uygulama kullanıcı adının ve şifresinin doğrulanmasını ister. 

     <authorization>
       <allow users="Prasad-PC\Venkat, Prasad-PC\Pragim"/>
       <deny users="*"/>
     </authorization> 

     Bağlantıyı kontrol etmek için windows kuralları kullanma

     WINDOWS OPERATING SYSTEM'in Administrators, Guests, Users vb. gibi bir kaç rolü var. 
     WEB.CONFIG dosyasında bu roles kullanarak kaynaklara erişimi kontrole etmekte mümkündür. 
     Aşağıdaki liste sadece Administrators role a ait kullanıcılara izin verir. 
     Diğer tüm kullanıcılara bağlantı engellenir.

     <authorization>
       <allow roles="Administrators"/>
       <deny users="*"/>
     </authorization>
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
            ds.ReadXml(Server.MapPath("~/Countries.xml"));
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}