using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _66_SQLServerSessionStateMode
{
    /*SESSION STATE MODE - SQL SERVER 
     
      SQL SERVER  MODE'u ayarlandığında, 
      SESSION STATE değerleri SQL SERVER veritabanında alınır.
     
      SQL SERVER  yapılandırma adımları
      1. ASPState ASPNET_REGSQL.EXE aracı kullanarak veritabanı oluştur. 
         Ben C:\Windows\Microsoft.NET\Framework64\v4.0.30319.'da mevcut olan versiyonu kullanacağım.
      
      a) cmd --> cd C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319 --> enter --> aspnet_regsql.exe -S USER -E -ssadd -sstype p 
       Bu SQLServerde ReportServerTempDB adında database oluşturuyor. 
       Server veya windows authentication a göre ayarların değiştirilmesi gerekir linkten
       http://msdn.microsoft.com/en-us/library/ms229862(v=vs.100).aspx
      
	  
      2. SQL SERVER MODE'u ve SQLCONNECTIONSTRING ayarla

      SQL SERVER'e WINDOWS AUTHENTICATION ile baklanmak için
      <sessionState mode="SQLServer" sqlConnectionString="data source=SQLServerName; integrated security=SSPI" timeout="20"></sessionState>
      SQL SERVER'e SQL SERVER AUTHENTICATION ile baklanmak için
      <sessionState mode="SQLServer" sqlConnectionString="data source=SQLServerName; user id=sa; password=pass" timeout="20"></sessionState> 

      Not: Entegre güvenlik(Windows authentication) kullanıyorsan, bir hata durumu alabilirsin 
      "Failed to login to session state SQL SERVER for user 'IIS APPPOOL\ASP.NET v4.0'.". Bu dahayı çözmek için 
      
      inetmgr --> IIIS and Click on Application Pools --> ASP.NET v4.0 sağ tıkla --> Advanced settings -->
      Process Model > Identity to LocalSystem and Click OK
      
	  
      SQL SERVER MODE vantajları.
      1. SQL SERVER en güvenilir seçenektir. 
         Yenilenen WORKER PROCESS  canlı kalır ve SQL SERVER yeniden başlat.
      2. WEB FARMS ve WEB GARDENS ile kullanılabilir.
      3. STATE SERVE ve INPROC SESSTION STATE modlarından daha fazla ölçeklenebilir 
     
     StateServer kullanmanın dezavantajları
     1. StateServer ve InProc dan daha yavaş dir.
	 2. Karmaşık nesneler, serileştirme ve çözme gerektirir.

     Note: 
     Web Garden - Web application deployed on a server with multiple processors
     Web Farm - Web application deployed on multiple server 
     _________________________________________________________
    |                   ______                                |
    |       	 ______| WEB  |______                         |
    |       	|      |SERVER|      |                        |
    |       	|       ¯¯¯¯¯¯		 |                        |
    |  ______	|       ______       |     _______     ______ |
    | | SQL  |__|______| WEB  |______|____| LOAD  |___|CLİENT||
    | |SERVER|	|      |SERVER|      |    |BALANCE|    ¯¯¯¯¯¯ |
    |  ¯¯¯¯¯¯	|       ¯¯¯¯¯¯	     |     ¯¯¯¯¯¯¯            |
    |       	|       ______       |                        |
    |       	|______| WEB  |______|                        |
    |       	       |SERVER|                               |
    |                   ¯¯¯¯¯¯                                |
    |_________________________________________________________|
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