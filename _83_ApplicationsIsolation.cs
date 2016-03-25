using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _83_ApplicationsIsolation
{
    /*
     Farklı APP POOL'lar ile ilişkilendirilmiş, APPLICATION'ları izeole edeceğiz.
     2 uygulama ve bir APP POOL oluştur. Bunları ilişkilendir.
     Built - in ayarlarını ISS yap
     
     2 uygulamayıda çalıştır. 
     Uygulamalardaki butona tıkladığında, oturum verileri görünmeli.

     APPLICATION POOL'u yeniden başlat
     Şimdi buton kontrollerine tıkla, Verilerin kaybolduğuna dikkat et.

     Şimdi IIS'de yeni bir APP POOL oluştur. 
     2. uygulamayı bununla ilişkilendir, uygulamaları çalıştır. 
     butona tıkla veriler görünür. 
     WebApplication1Pool resetle uygulama butonlaruna tekrar tıkla. 
    
     sitede bunun aynısı webapplication2 oluşturmak için var App Pool içine atacak bende App Pool olmadığı için yeni bir web uygulaması açmadım.
     ilk önce 2 uygulamayıda 1 app pool a attı. reset yaptı veriler gitti. sonra uyuglamaları ayrı app pool lara attı. bir pool u resetledi onun verileri gitti diğeri kaldı.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Application1_Data"] = "Application 1 Data";
            }
            Response.Write("Identity used = " + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "<br/>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Application1_Data"] != null)
            {
                Response.Write("Application1_Data = " + Session["Application1_Data"]);
            }
            else
            {
                Response.Write("Session Data not available");
            }
        }
    }
}
