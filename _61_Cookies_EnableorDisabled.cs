using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _61_Cookies_EnableorDisabled
{
    /*COOKIES ENABLE OR DISABLED
     ASP.NET'de COOKIES'in açık olup olmadığını nasıl kontrol ederiz?
     İnternetteki birçok makale, cookies açık olup olmadığını kontrol etmek için 
     Request.Browser.Cookies özelliğini kullanabileceğimizi belirtir. 
     Yanlıştır. --> if (Request.Browser.Cookies){ COOKIES Enabled } else { COOKIES Disabled }

	 REQUEST.BROWSER.COOKIES özelliği tarayıcının COOKIES'i destekleyip desteklemediğini kontrol etmek için kullanılır. 
     Modern birçok tarayıcı COOKIES'i destekler.
     Yani Tarayıcı COOKIE'i destekliyorsa, kullanıcı kullanımını engellesebile, sonuç hep TRUE olur.
     Yani bu özelliği tarayıcının COOKIES'i destekleyip desteklemediğini kontrol etmek için kullan.
     COOKIES'in açık olup olmadığını kontrolu etmek için kullanma
     if (Request.Browser.Cookies) {//Broswer supports cookies} else{//Broswer does not supports cookies}
 
     Sıradaki soru COOKIES'in açık olup olmadığını nasıl kontrol ederiz?
	 Bir test COOKIE yaz. - Bir sayfaya yönlendir.
	 Test COOKIE'yi oku. - Cookies mevcutsa - COOKIES açıktır.
	 Değilse kapalıdır.

     İE 9'da COOKIE'i kapat

     Yukarıdaki adımlar cookies sadece internet alanı için kapatır. makinende test ediyorsan ve localhost için cookiesleri kapatmak için
     1. Run the application --> 2. Press F12, to open developer tools --> 3. Then Select, Cache - Disable Cookies  
     */
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Browser.Cookies)
                {
                    if (Request.QueryString["CheckCookie"] == null)
                    {
                        HttpCookie cookie = new HttpCookie("TestCookie", "1");
                        Response.Cookies.Add(cookie);

                        Response.Redirect("WebForm1.aspx?CheckCookie=1");
                    }
                    else
                    {
                        HttpCookie cookie = Request.Cookies["TestCookie"];
                        if (cookie == null)
                            lblMessage.Text = "We have detected that, the cookies are disabled on your browser. Please enable cookies.";

                    }
                }
                else
                    lblMessage.Text = "Browser doesn't support cookies. Please install one of the modern browser's that support cookies.";

            }
        }
        protected void btnSendData_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserDetails");
            cookie["Name"] = txtName.Text;
            cookie["Email"] = txtEmail.Text;
            Response.Cookies.Add(cookie);
            Response.Redirect("WebForm2.aspx");

        }
    }
}
