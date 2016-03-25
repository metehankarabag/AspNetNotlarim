using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _52_Response.Redirect
{
    //Sadece burada yazı var.
    /*RESPONSE.REDIRECT()
	 
	 REDIRECT(), RESPONSE CLASS'ının STATIC bir methodudur ve EVENT'lar içinde çalışır.
	 Yani çalıştırılmadan önce işlem yapılabilir.
	 HYPERLINK, sadece yeni bir sayfa getirmek için SERVER'a gider.
	 
	 REDIRECT() methodunu yazdığımız EVENT çalıştırıldığında,
	 Sayfa SERVER'a gider, SERVER methodu çalıtırdığında,
	 CLIENT'e gider ve bir GET isteği ile SERVER'a gelir.
	 Son olarak SERVER'dan yeni sayfa ile gelir.
     Yani kısaca, Response.Redirect  2 istek ve cevaba döngüsüne neden olur ve
	 GET istediği oluşturularak yeni sayfaya ulaşılır.

     Özellikleri
	 Keni uygulaması içindeki bir sayfaya veya farklı bir uygulamadaki sayfaya gidebilir.
	 Sayfa geçmişini hatırlar ve URL'i değiştirir.
	 CONTROL olmadığı için HTML çıktısı olmaz.

     Farklı bir sayfaya bağlanacaksak SERVER.TRANSFER() ve SERVER.EXECUTE()'u kullanamayız.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm2.aspx");
        }
    }
}