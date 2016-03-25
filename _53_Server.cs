using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _53_Server.Transfer
{
    //Sadece burada yazı var.
	/*SERVER.TRANSFER()
	  Sacade yazıldığı uygulama içindeki bir sayfaya gidebilir.
	  URL'i değiştirmez.
	  Yazıldığı sayfadaki tüm FORM nesnelerini saklar.
	  Yeni sayfaya yönlendirme SEVER'da yapılır.
	  Yani geçerli sayfa gider yeni sayfa gelir. (Veri transferi de SERVER'da olur.)
	  Bu yüzden RESPONSE.REDIRECT()'den daha hızlıdır.
	  SERVER.TRANSFER() çalıştıktan sonra yazılan kodlar çalıştırılmaz.
	  
	*/
    /*Geçerli sayfadaki CONTROL verilerine açılan sayfada nasıl ulaşırız?
      SERVER.TRANSFER(), 2 parametreli bir methoddur ve 2. parametresinin varsayılan değeri TRUE'dur.
      Bu parametre verilerin bir sonraki sayfaya gidip gitmeyeceğini belirler.
	  
      Bir CONTROL'ün verisini almak için ilk önce CONTROL'e ulaşmalıyız.
      CONTROL'e nasıl ulaşacağız?
      Farklı yolar var
      1. REQUEST.FORM():
      NameValueCollection ABSTRACT CLASS nesnesi dönder.
      Bu CLASS System.Collections.Specialized içindedir.
      Bu CLASS örneğine dizi içinde CONTROL adını yazıp, CONTROL'e ulaşırız.
						 
      2. (this.)PAGE.PREVIOUSPAGE: 
       Yazıldığı sayfaya SERVER.TRANSFER() ve CROOSPAGEPOSTBACK kullanılarak gelinmiş ise sayfa bilgilerini alır ve
       Bu özellik TRANSFER() methodunun 2. parametresi FALSE olsa bile değer alır.
       
       
       PAGE.PREVIOUSPAGE - PAGE döndüğü için değerlerini PAGE örneğinde tutar.
       PAGE.PREVIOUSPAGE.FINDCONTROL() - CONTROL getirdiği için değerlerini CONTROL örneğinde turar.
       (TYPE CAST ile özel bir CONTROL örneğine atabiliriz)
       ((TextBox)PAGE.PREVIOUSPAGE.FINDCONTROL()).TEXT - STRING döndüğü için değeri STRING örneğinde turar.
       */

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/WebForm2.aspx", true);
        }
        protected void btnTransferToExternalWebsite_Click(object sender, EventArgs e)
        {
            Server.Transfer("http://pragimtech.com/home.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm2.aspx");/*böyle gidersek page.previouspage değeri null olucak*/
        }
    }
}