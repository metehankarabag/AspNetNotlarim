using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _78_UsingSMTPServerSettingsFormWebConfig
{
    /*WEB.CONFIG dosyasında SMTP SERVER ayarlarını belirlemeyi göreceğiz
      SMTP server için WEB.CONFIG ayarları. Tüm özellikleri kendinden açıklayıcıdır
      <system.net>
        <mailSettings>
          <smtp deliveryMethod="Network">
            <network host="smtp.gmail.com" enableSsl="true" port="587" userName="your_email@gmail.com" password="your_password" />
          </smtp>
        </mailSettings>
      </system.net> 
      
      
      STMP serve ayarları artık WEB.CONFIG'den yapılandırılır. Kodda yapmak zorunda olduğun her şey
      
      1. MailMessage sınıfının bir örneğini oluştur. ayarları belirle
      
      2. SMTPCLIENT sınfının bir örneğini oluştur ve SEND() methodu kullanarak gönder. 
        Mail gönderildiğinde SMTP ayarları otomatık olarak WEB.CONFIG'den alınacak.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            // DataSet is in System.Data namespace
            DataSet ds = new DataSet();
            // file is not present in the project
            ds.ReadXml(Server.MapPath("~/Countries1231.xml"));
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