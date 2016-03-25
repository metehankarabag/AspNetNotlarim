using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _73_LoggingToTheEventViewer
{
    /*LOGGING EXCEPTIONS TO THE EVENT VIEWER
     Bu videoda biz WINDOWS EVENT VIEWER'a EXCEPTIONS girme hakkında tartışacağız. 
     Bir önceki derste biz WINDOWS EVENT VIEWER'da CUSTOM WINDOWS EVENT LOG ve EVENT SOURCE oluşturma hakkında tartıştık. 

     ASP.NET WEB APPLICATION oluşturma.WEBFORM1.ASPX'e ekle. 
     GIRDVIEW CONTROL'ü sürükle bırak. Aşağıdaki kodları kopyala ve yapıştır.

     Uygulamayı çalıştır. WebForm1.aspx EXCEPTION atar. Bu EXCEPTION APPLICATION düzeyine yayılana kadar herhangi bir yerede işlenmediğinden ve APPLICATION_ERROR() EVENT HANDLER çalıştırılacağından. Bu WINDOWS EVENT VIEWER girmeli
   
     NOT
     HTTPUNHANDLEDEXCEPTION hatası APPLICATION düzeyinde çıkıyor.
     Yani program çalışma sırasında PAGE üzerinde tanımlanmamış bir hata ile karşılırsa
     GLOBAL.ASAX.CS'deki APPLICATION_ERROR() EVENT'ı çalışıyor.
     Sonra PAGE'deki hatanın açıklamasını alıyoruz.
     
     Uygulamada hatanın olduğu yer Try catch içinde ise hatayı tanımlamış oluyoruz ve hata APPLICATION düzeyine yayılmıyor. Bu yüzden tek bir hata alıyoruz.

     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            // DataSet is System.Data namespace
            DataSet ds = new DataSet();
            // This line throws FileNotFoundException
            ds.ReadXml(Server.MapPath("~/Data/Countries.xml"));// not found error

            GridView1.DataSource = ds;
            GridView1.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    Logger.Log(ex);
            //}

        }
    }
}


