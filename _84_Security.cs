using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _84_Security
{

    /*Farklı APPLICATION POOLS için farklı güvenlik düzeyi ayarlama hakkında tartışacağız.
     2 xml dosyası oluştur.
     Bir uygulama ve bir APP POOL oluştur. Bunları ilişkilendir.
     
     Aynı işi bir kez daha yap.
     Sırayla iki uygulamayıda çalıştır ve iki XML dosyasınıda yüklemeye çalış. Başarılı olursun.
     
     XML dosyalarına sınırlama getirmek istiyoruz, herkes olaşmasın.
     
     Uygulamalar farklı havuzlara dağıtılır ve 2 uygulamada kendi uygulama havuzu kimliği ile çalıştırılır. Yani 
     WEBAPPLICATION1 APPLICATION1POOL'u kullanarak IIS APPPOOL\Application1Pool kimliği ile çalışır ve 
     WEBAPPLICATION2 APPLICATION2POOL'u kullanarak IIS APPPOOL\Application2Pool kimliği ile çalışır

     Bu aşamada tüm yapmamız gereken  uygulama kimliğine göre dosya izinlerini ayarlamaktır.
     WEBAPPLICATION1DATA.XML dosyasına IIS APPPOOL\Application2Pool kimliğini engellemek için 

     XML dosyasını seç --> Properties --> Security --> Edit --> Add --> Locations -->bilgisyar adını seç--> ok.
     6 - "Enter the object names to select", kutusuna, IIS APPPOOL\Application2Pool yaz ve adı kontrol et.
     8. izin listedinden tüm kontrolleri seç ve Deny a tıkla.
     aynı işi yap diğeri içinde yap

     İzni olmayan dosyaya giriş erişmeye çalışırsa, ölümün sarı ekranı yerine aşağıdaki kodları kullan.      
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Identity used = " +System.Security.Principal.WindowsIdentity.GetCurrent().Name + "<br/>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(FileUpload1.PostedFile.FileName);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    Label1.Text = "";
                }
                catch (System.UnauthorizedAccessException)
                {
                    Label1.Text = "You do not have acces to this file";
                }
                catch(Exception)
                {
                    Label1.Text = "An unexception error has occured, please contact administrator";
                }
            }
            else
            {
                Label1.Text = "Please select a file first";
            }
        }
    }
}
/*
 */