using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace _90_UserNameListConfig
{
    /*FORMS AUTHENTICATION
     Kullanıcıların WINDOWS DOMAIN-BASED NETWORK'ün bir parçası olduğu INTRANET WEB APPLICATION için WINDOWS AUTHENTICATION kullanılır.

     FORMS AUTHENTICATION ne zaman kullanılır?
     İnternet WEB APPLICATIONS'da kullanılır.
     FORMS AUTHENTICATION'ın avantajı kullanıcılar.
     Kullanıcıların uygulamanı kullanabilmeleri için 
     DOMAIN-BASED NETWORK'ün üyesi olmaları gerekmiyor.

     FORMS AUTHENTICATION nasıl açarız?
     Bir uygulama oluştur ve içine
     WELCOME.ASPX, LOGIN.ASPX sayfası ve REGISTRATION klasörü içine REGISTER.ASPX sayfası ekle.

     Kullanıcı girişi yapmadan, uygulamadaki tüm sayfalara URl'i değiştirerek gidebiliriz.
     
     FORMS AUTHENTICATION Özelliklerinin açıklaması
     LOGINURL - Giriş sayfasını belirler. Girişli olmayan kullanıcıların yönlendirileceği sayfadır. --> Değer girilmesse varsayılan sayfa aranır. Yoksa hata alırız
     TIMEOUT - CLIENT PC'de the AUTHENTICATION COOKIE'nin ne kadar kalacağını belirler. Varsayılanı 30 dk dır.
     DEFAULTURL - Giriş sayfandıktan sonra kullanıcının yönlendirileceği sayfadır. --> Değer girilmesse varsayılan sayfa aranır. Yoksa hata alırız
     PROTECTION - AUTHENTICATION COOKIE'deki bilgi türlerine göre koruma belirler.
     Varsayılan şifreleme ve DATA gerekliliklerini yerine getiren herşeyi korur. 
     Diğer mümkün ayarlar şifreleme, gereklilik ve none.
 
     
     Şu anki uygulamamızın 2 problemi var.    
     Kullanıcı adını ve şifresini WEB.CONFIG'den almak iyi değil.
     Dinamik bir liste istiyorsak WEB.CONFIG'i sürekli değiştirmemiz gerekir.
     CONFIG dosyaları çalışma zamanında değiştirilirse, 
     uygulama yeniden başlayacak ve WORKER PROCCESS içinde tutulan tüm SESSION verileri kaybolacak.
     
     Bir sonraki derste, biz veritabanı tablosunda kullanıcı adı ve şifre alma hakkında tartışacağız.
     Şu anda, kullanıcılar girişli değilseler, REGISTER.ASPX sayfasına bağlanamaz. (kayıtın yapıldığı sayfa)
     
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