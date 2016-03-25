using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _75_LoggingToDatabase
{
    /*  
     Bu videoda biz veritabanı tablosuna EXCEPTIONS'ı girme hakkında tartışacağız. 
     İlk adım gerekli EXCEPTIONS girmek için tabloyu oluşturmaktır.

     Script to create table - tblLog
     İstisnaları girmek için depolanmış işlem oluştur
     Logger.cs adında bir sınıf ekle
     Errors.aspx adında bir webform ekle

     Projeye bir webform ekle. GIRDVIEW  sürükle bırak. aşağıdaki kodları kopyala ve kod arkası dosyasındaki PAGE_LOAD() olayında yapıştır.
     Uygulamayı çalıştır. İstisna Database tablosuna eklenmeli - tblLog ve kullanıcı Errors.aspx sayfasına yeniden yönlendirilecek.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                // file is not present in the project
                ds.ReadXml(Server.MapPath("~/Data.xml"));
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            //catch (exception ex)
            //{
            //    logger.log(ex);
            //    server.transfer("~/errors.aspx");
            //}
            // Üstteki catch yerine
            catch(Exception exception)
            {
                Logger.Log(exception);
                if (exception is System.IO.FileNotFoundException)
                {
                    Label1.Text = "Data.xml is not found";
                }
                else
                {
                    Label1.Text = "An unknown problem has occured, please contact the administrator";
                }                
            }
            // try catch i açtiğimizda başka sayfaya göndermedik ve global.asax.cs dosyasını gitmedi
        }
    }
}