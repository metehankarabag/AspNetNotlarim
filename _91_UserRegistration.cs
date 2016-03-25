using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace _91_UserRegistration
{
    /*
      Geçen derste REGISTER.ASPX sayfasına giremiyorduk. 
      REGISTRATION klasörüne başka bir WEB.CONFIG dosyası ekle ve AUTHENTICATION nesnesi tüm kullanıcılara izin vermek için belirt.
      <authorization> <allow users="*"/>  </authorization>
      Bu noktada uygulama içine giriş olmadan, kullanıcılara Registration/Register.aspx sayfasına gidebiliecek.
      Uygulamayı çalıştır. Gerekli detayları doldur ve Register butonuna tıkla. Kullancı veritabanına eklenmeli.
      Sıradaki video oturumunda, biz veri tabanından aldığımız kimlik bilgileri ile AUTHENTICATING hakkında tartışacağız.
      
      ADO.NET ve SERVER'de yapılan işler.
      
      SQL Server veya windows authentication da bir data yi kullanıma açmak için 
      Security > Logins > SQL Server'deki hesap > properties > UserMapping > data adına ve alttan dp_owner tik koy. 
      hata hata verdi New Query'ye exec sp_changedbowner 'sa','true' sa kullandığım hesap DATA'yı kullanıma açtı. 

      WINDOWS AUTHENTICATION ile veritabanına bağlanıyorken, 
      SQL SERVER AUTHENTICATION'a geçmek için 
      ObjectBrowser'daki(1.) -- properties -- security-- SQL SERVER AUTENTICATION -- Security -- logins -- oturum türü -- properties -- Status den enable yap.
     */
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(txtUserName.Text, txtPassword.Text))
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkBoxRememberMe.Checked);
            else
                lblMessage.Text = "Invalid UserName and/or password";
        }
    }
}