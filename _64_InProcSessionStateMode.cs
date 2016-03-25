using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _64_InProcSessionStateMode
{
    /*INPROC SESSIONSTATE MODE
     INPROC SESSIONSTATE MODE: INPROC'a ayarlandığından, SESSIONSTATE değişkenleri ASP.NET WORKER PROCESS içindeki WEBSUNUCU hafızasından alınır. Bu varsayılan SESSIONSTATE modudur.

     INPROC SESSIONSTATE MODE avantajları
     1. Uygulaması çok kolaydır. Tüm gerekli şey, WEB.CONFIG dosyasında SESSIONSTATE MODE'unu INPROC olarak ayarlamaktır.
     2. En iyisi gerçekleşecek. Çünkü SESSIONSTATE hafızası ASP.NET WORKER PROCESS içinde WEBSUNUCU'da korunur.
     3. Tekil SERVER'lar içinde barınan WEB APPLICATION'lar için uygundur.
     4. Nesneler SERIALIZATION olmadan eklenebilir.

     InProc oturum durumu modunun dezavantajları

     1. WORKER PROCESS veya APPLICATION POOL yeniden çalıştırıldığında SESSIONSTATE verisi kaybedilir.
     2. WEB FARMS ve WEB GARDENS için uygun değildir.
     3. Ölçeklenebilirlik bir sorun olabilirdi.

     Note:
     WEB GARDEN - birden fazla işlemci ile bir sunucuda yayılmış WEB APPLICATION
     WEB FARM - birden fazla sunucuda yayılmış WEB APPLICATION
    
     WEB FARM: sunucuların yoğununu paylaştırmak için  kullanılan bir yöntemdir.
     INPROC ile kullanımıda istemci verileri boş olan 1. sunucuya gider.
     İstemci tarayıcıyı yenilerse ve tekrar bir istekte bulunursa 1. sunucu dolu olduğu için 2. sunucuya yönlendirir.
     Fakat veriler 1. sunucuda olduğu için bilgilerine ulaşamaz.
 ______________________________________________________________
|                                                              |
|   WEB SERVER------------|                                    |
|                         | ____________          _______      |
|                         ||            |        |       |     |
|   WEB SERVER-------------|LOAD BALANCE|--------|CLİENT |     |
|                         ||____________|        |_______|     |
|                         |                                    |
|   WEB SERVER------------|                                    |
|______________________________________________________________|
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnSendData_Click(object sender, EventArgs e)
        {
            Session["Name"] = txtName.Text;
            Session["Email"] = txtEmail.Text;
            Response.Redirect("WebForm2.aspx");
        }
    }
}