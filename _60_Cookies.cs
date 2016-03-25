using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _60_Cookies
{
    /*
     COOKIE'ler bir WEBFORM'dan diğerine veri göndermek için kullanılabilir.
     Genellikle, CLIENT'a özel olan kullanıcı tercihlerini veya diğer bilgilerini almak için kullanılır. 
     COOKIE'ler bilgiyi CLIENT pc den alır.

     COOKIE'ler 2 tür içinde geniş olarak sınıflandırılabilir.

     1. PERSISTENT COOKIES - HTTPCOOKIE nesnesinin EXPIRES özelliğinin kullanılmış halidir.
        Tarayıcı kapandığında bile, beritilen süre boyunca COOKIE, CLIENT pc de kalır.
     2. NON-PERSISTENT COOKIES - EXPIRES özelliğini kullanmadığımız halidir. 
        COOKIE'ler tarayıcı kapanana kadar hafızada kalır.
     
      Kullanımı 
      COOKIE oluştur ve kurucusuna isim ver.
      COOKEI örneğinde dizi kullanarak istediğin bilgileri tut.
      Sonra COOKIE'yi SERVER cevabına ekle Response.Cookies.Add(cookie)
      
      Verileri alırken 
      Bir COOKIE örneği oluştur ve SERVER'dan COOKIE adını belirterek iste.
      Request.COOKIES("cookie")
      Artık verileri yeni örnekten dizi ile alabilirsin.
      
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnSendData_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserDetails");
            cookie["Name"] = txtName.Text;
            cookie["Email"] = txtEmail.Text;

            cookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(cookie);

            Response.Redirect("WebForm2.aspx");
        }
    }
}
/*
 .
 */