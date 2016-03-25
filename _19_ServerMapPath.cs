using System;

namespace _19_ServerMapPath
{
    /*Server.MapPath()
     Verilen sanal yol için fiziksel yol döner. Bu method sanal yolda kullandığımız karakterlere dayalı olarak  varklı yollar ile kullanılabilir.
     
     ".": Çalışan WEBFORM'un bulunduğu klasörün fiziksel yolunu veriyor.
     "..": Çalışan WEBFORM'un bulunduğu klasörün parent klasörünün fiziksel yolunu veriyor.
     "~": Root fiziksel yolunu veriyor
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Server.MapPath(".") + "<br/>");
            //Response.Write(Server.MapPath("..") + "<br/>");// root directiory vermez dosya varsa kullanabiliriz.
            Response.Write(Server.MapPath("~") + "<br/>");
            //Response.Write(Server.MapPath("../..") + "<br/>");
        }
    }
}