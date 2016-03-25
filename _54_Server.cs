using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _54_Server.Execute
{
    //Sadece burada yazı var.
    /*SERVER.EXECUTE()
      SERVER.TRANSFER() ve SERVER.EXECUTE() bir çok açıdan benzerdirler.
      URL değişmez
      Sadece yazıldıkları uygulamadaki sayfalara gidebilir.
	  Sayfa bilgilerini yönlendirdiği sayfaya gönderir.
      
	  Fark.
      SERVER.TRANSFER() geçerli PAGE'nin uygulamasını sonlandırır ve yeni PAGE'nin uygulamasını çalıştırır.
      SERVER.EXECUTE() ile yönlendirilen sayfa çalışır sonucu ile sayfaya gelir ve ilk sayfa çalışmaya devam eder
	  
      SERVER.TRANSFER() ve SERVER.EXECUTE() arasında söyle bir mantık var
      SERVER.TRANSFER()
      Kullanıcı ilk WEBFORM'da işlemlerini yaptıktan sonra.
      ilk WEBFORM'a ait alt sayfalar var.
      İstediği alt sayfa gidiyor ve orda işlemlerini bitiriyor.
      
      SERVER.EXECUTE()
      Kullanıcı ilk WEBFORM'da işlemlerini yapıyor.
      ilk WEBFORM'dan kullanıcı istediği alt sayfaya gidiyor.
      Burada da işlemini yapıyor ve geri geliyor ilk WEBFORM'daki işlerine devam ediyor.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnExecute_Click(object sender, EventArgs e)
        {
            Server.Execute("~/WebForm2.aspx", true);
            lblStatus.Text = "The call returned after processing the second webform";
        }
        protected void btnExecuteToExternalWebsite_Click(object sender, EventArgs e)
        {
            Server.Execute("http://pragimtech.com/home.aspx");
        }
    }
}