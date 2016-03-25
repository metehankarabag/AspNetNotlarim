 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _55_CrossPagePosting
{
    //Sadece burada yazı var.
    /*CROSS PAGE POSTING
	  Bir sayfadan başka bir sayfaya postalamaya izin verir.
	  POST BACK URL özelliğine gidilecek sayfa URL'sini yaz
      Varsayılan olarak, BUTTON'a tıkladığında, WEBFORM kendisine postalar. 
      BUTTON'da bir tıklamayla başka bir WEBFORM a postalamak istiyorsan, 
	  Yani sayfa SERVER'e postalandığında SERVER başka bir sayfayı getirsin istiyorsan, kullan.
	  URL'i değiştirir.
	  SERVER.TRANSFER() aynı şekilde çalışır. URL'i değiştirmez yönlendirilen sayfayı geçerli sayfa içinde açlıştırır.

	  
	  The problem with FindControl() method is that, if you mis-spell the ControlID, we could get a runtime NullRefernceException. In the next video we will discuss about obtaining a strongly typed reference to the previous page, which can avoid NullRefernceExceptions.
	  
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/WebForm2.aspx");
            
        }
    }
}