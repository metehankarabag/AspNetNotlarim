using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _58_Context.Handler
{
    //Sadece bu sayfada yazı var.
    /*Bir WEBFORM'dan diğerine veri gönderme teknikleri - CONTEXT.HANDLER
	  
     Genelikler bir WEBFORM'un üyeleri bir sonraki WEBFORM'dan mevcut değildir. 
     Her nasılsa, SERVER.TRANSFER() veya SERVER.EXECUTE() methodlarını kullanarak WEBFORM'lar arasında gezindiğinde,
     CONTEXT.HANDLER nesnesi kullanarak önceki WEBFORM üyelerinden veri alınabilir.

     CONTEXT.HANDLER 
     1. Sadece ilk kez WebForm1 den WebForm2 alanına girdiğinde, CONTEXT.HANDLER bir önceki sayfa olarak WEBFORM1'e döner.  
     2. CONTEXT.HANDLER'in bir önceki sayfa olarak WebForm1 döndürmesi için, 
        SERVER.TRANSFER() or SERVER.EXECUTE() method kullanarak WebForm1'den WebForm2 nin alanına girmiş olmalısın.

     3. Bir önceki sayfadan kontrol değerine FindControl() methodu kullanarak bağlanılabilir. 
        FindControl() methodu ile problem TYPE SAFE olmamasıdır.
        FintControl() methodu yerine public PROPERTIES kullanarak çalışma zamanı NullRefernceExceptions'ı eleyebiliriz.
     
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

        public string Name
        {
            get
            {
                return txtName.Text;
            }
        }

        public string Email
        {
            get
            {
                return txtEmail.Text;
            }
        }
    }
}