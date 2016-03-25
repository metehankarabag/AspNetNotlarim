using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _59_QueryString
{
    /*QUERYSTRING
     QUERYSTRING hakkında bilinmesi gereken şey isim ve değer çiftiden oluşmasıdır.

     QUERYSTRING'ler kullanımı bir WEBFORM'dan diğerine veri göndermek için çok yaygındır.
     QUERYSTRING'ler sayfa URL sine eklenir.
     ? bir QUERYSTRING'in başlangıcını ve değerini gösterir.

     Birden fazla query string kullanmak mümkündür. 
     İlk QUERYSTRING ? ile belirtilir. 
     Sonraki QUERYSTRING & sembolu kullanılarak URL ye eklenebilir.

     QUERYSTRING ne zaman kullanılmaz
     QUERYSTRING çok uzun verileri göndermek için kullanılamaz. Çünkü karakter sayısı sınırlı.
     QUERYSTRING kullanıcılara görünür, bu yüzden gizli bilgiler şifreli olmadığı sürece gönderilmemeli.
     QUERYSTRING değerlerini okumak için istek nesnesinin QUERYSTRING özelliği kullanılır.
     & QUERYSTRING'i bağlamak için kullanılır, yani QUERYSTRING için değer olarak & göndermek istiyorsan, asağıda göründüğü gibi 2 yol var.

     Using SERVER.URLENCODE() method
     Response.Redirect("WebForm2.aspx?UserName=" + Server.UrlEncode(txtName.Text) + "&UserEmail=" + Server.UrlEncode(txtEmail.Text));
     Or
     &(ampersand) is encoded as %26, so use, Replace() function to replace & with %26 --> & sembolünün karşılığı %26 dır
     Response.Redirect("WebForm2.aspx?UserName=" + txtName.Text.Replace("&", "%26") + "&UserEmail=" + txtEmail.Text.Replace("&", "%26")); 
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnSendData_Click(object sender, EventArgs e)
        {
            //Using Server.UrlEncode to encode &(ampersand)
            //Response.Redirect("WebForm2.aspx?UserName=" + Server.UrlEncode(txtName.Text) + "&UserEmail=" + Server.UrlEncode(txtEmail.Text));

            //Using String.Replace() function to replace &(ampersand) with %26 
            Response.Redirect("WebForm2.aspx?UserName=" + txtName.Text.Replace("&", "%26") + "&UserEmail=" + txtEmail.Text.Replace("&", "%26"));
        }
    }
}