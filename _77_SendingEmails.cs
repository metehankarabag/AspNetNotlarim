using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _77_SendingEmails
{
    /*
     Bu video serisinin bir önceki oturumuda biz veritabanına EXCEPTIONS girme ve WINDOWS EVENT VIEWER'da göstermeyi tartıştık. 
     Bu oturumda geliştirme takımıma veya admimistrator EXCEPTIONS girişleri ile birlikte bir mail gönderme

	 Bir mesage oluşturmak için, MAILMESSAGE sınıfını kullan. mesajı göndermek için SMTPCLIENT sınıfını kullan. Bu sınıfların ikiside SYSTEM.NET.MAIL isim uzayunda mevcut

     SendEmail() methodu Logger sınıfınmızda çok geçmeden çağırılabilir. Giriş parametresi olara bir istisna yazısı gir.
        SendEmail(sbExceptionMessage.ToString());
     
     Mesaj gönderme yeteneği ayarlanabilir olamasını istiyorsan, WEB.CONFIG'de aşağıdaki anahtarı ekle. 
        <appSettings>
          <add key="SendEmail" value="true"/>
        </appSettings>
     
     WEB.CONFIG den SENDMAIL anahtarını oku. SENDMAIL true olarak ayarlanmışsa ozaman masaj gönder

     Gerçete grupların kendi SMTP serverleri vardır. kendi stmp serverini kullanarak bir mail göndermek istiyorsan, kendi smtp adress ve kimlik bilgilerini kullan.
    */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            // DataSet is in System.Data namespace
            DataSet ds = new DataSet();
            // This line will throw an exception, as Data.xml 
            // file is not present in the project
            ds.ReadXml(Server.MapPath("~/Data.xml"));
            GridView1.DataSource = ds;
            GridView1.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    Logger.Log(ex);
            //    Server.Transfer("~/Errors.aspx");
            //}

        }
    }
}