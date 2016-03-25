using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _69_ExceptionHandling
{
    /*EXCEPTION HANDLING
      EXCEPTİON'lar uygulamanın matığı içinde olan beklenmedik hatalardır.
      Örnegin, bir dosya okuduğunda, EXCEPTİON koşullarından bir tanesi oluşabilir.
      1. Dosya olmayabilir.
      2. Dosyaya erişmek için izninin olmayabilir
      Öngörülemeyen hata durumları UNHANDLED EXCEPTION olarak adlandırılır. 
      Bir UNHANDLED EXCEPTION kullanıcıya bir ölümün sarı ekranı kullanılarak gösterilir.
      Bu ekranda şifrelenmiş bilgiler vardır ve son kullanıcının bir işi olmaz ama HACKER'lar sever
      TRY-CATCH kullanarak EXCEPTION HANDLING
         Hataya neden olabilecek kod TRY içinde yazılır.
      Bir hata olursa uygulama CACHE alanına atlar.
         CATCH - Hatanın yakalandığı ve düzeltilmeye çalışıldığı yerdir.
      FINALLY - kaynakları kurtarmak için kullanılır. 
         FINALLY hata olsada olmasada çalışır.
      THROW - bir EXCEPTION'yı çalıştırmak için kullanırız.
      
	  Specific exceptions should be caught, before catching the general parent exception.
      Tüm EXCEPTIONS BASE CLASS için EXCEPTİON sınıfıdır. Temel EXCEPTIONS yakalanmadan önce özel EXCEPTIONS yakalamalıdır.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Uncomment this line to print the name of the account 
        // used to run the application code
        // Response.Write(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/Countries.xml"));
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            // Catch specific exceptions first
            catch (System.UnauthorizedAccessException unauthorizedAccessException)
            {
                //Log the exception information
                lblError.Text = "Access to the file denied";
            }
            catch (System.IO.FileNotFoundException fileNotFoundException)
            {
                //Log the exception information
                lblError.Text = "File does not exist";
            }
            catch (Exception ex)
            {
                lblError.Text = "There is an unkown problem. IT team is working on this issue. Please check back after some time";
            }
            finally
            {
            }
        }
    }
}
