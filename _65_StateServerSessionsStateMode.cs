using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _65_StateServerSessionsStateMode
{
    /*SESSIONSSTATE MODE - STATE SERVER 
        
     SESSIONS STATE, STATE SERVER olarak ayarlandığında, 
     SESSIONS STATE değişkenleri STATE SERVER olarak adlandırılan bir işlemde alınır. 
     Bu işlem WORKER PROCESS'den farklıdır. 
     STATE SERVİCE özel bir makine veya bir WEB SERVER'da sunulabilir.

     Bir WEB APPLICATION'da  STATE SERVER kullanabilmek için yapılandırma ayarları
     1. ASP.NET STATE SERVİCE başlat.
        a) Click Start > Type Run > Press Enter
        b) In the run window, type services.msc and click OK. 
        c) In the services window, right click on ASP.NET State Service and select Start.
     
     2. WEB.CONFIG'de SESSIONSSTATE MODE'u STATESERVER olarak ayarla
     3. STATECONNECTIONSTRING="tcpip=StateServer:42424" olarak ayarla
        Example: <sessionState mode="StateServer" stateConnectionString="tcpip=localhost:42424" timeout="20"></sessionState> 

	
     STATESERVER oturum modunun avantajları
        1. ASP.NET WORKER PROCESS'den bağımsızdır. 
           Hayattaki WORKER PROCESS yeniden başlat.
        2. WEB FARMS ve WEB GARDENS ile kullanılabilir.
        3. STATESERVER daha INPROC'dan daha çok ölçeklenebilirlik sunar.

     STATESERVER oturum durumu modunun dezavantajları
        1. INPROC'dan daha yavaştır.
        2. Karmaşık nesneler, SERIALIZATION ve DESERIALIZATION gerektirir.
        3. STATE SERVER özel bir makinada ise ve SERVER kapanırsa SESSION'lar kaybolur.
    
     Note: 
     Web Garden - Web application deployed on a server with multiple processors 
     Web Farm - Web application deployed on multiple server 
     
     Not: STATE SERVER PC olduğu için LOCALHOST yazıyoruz ve LOCALHOST'un port numarası 42424 dir.
          STATE SERVER olarak farklı bir PC kullansaydık, o serverin adını ve port numarasını kullanacaktık.

 ____________________________________________________________
|            |------WEB SERVER------|                        |
|            |                      |                        |
|            |                      |                        |
|            |                      |                        |
|            |                      |                        |
|STATE SERVER ------WEB SERVER------LOAD BALANCE------CLİENT |
|            |                      |                        |
|            |                      |                        |
|            |                      |                        |
|            |                      |                        |
|            |------WEB SERVER------|                        |
|____________________________________________________________|

istek en sonunda STATE SERVER'de saklanıyor. 
Yani istek en rahat olan servere gidiyor. 
Hangisinden giderse gitsin STATESERVER'den bilgiyi alıyor. bu karışıklığı engelliyor.
   
http://blogs.msdn.com/b/cenkiscan/archive/2009/03/03/web-garden-web-farm.aspx
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