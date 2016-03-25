using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _105_UsingUserControlsOnAWebForm
{
    /*WEBFORM'a USER CONTROL ekleme ve kullanma
     WEBFORM DESIGN modda ile sürükleyip bıraktığında, eklenir.
     HTML'de şey kısımdan oluşur - 1. REGISTER DIRECTIVE - 2. CONTROL'ün kendisi
    
     REGISTER DIRECTIVE'indeki TAGPREFIX ve TAGNAME, CONTROL açıklamasında kullanılır.
     ASP.NET CONTROL'leri için tagprefix ASP'dir. Değiştirilebilir.
     
     Kullanmayı istediğin USER CONTROL'ü kaydını WEB.CONFIG kullanarak tüm uygulama için bir seferde yapabilirsin.
     <system.web>--><pages> --> <controls> --> <add src"yol" tagName="" tagPrefix=""/>

     USER CONTROL ve kullanıldığı WEBFORM aynı dosya derinliğinde olursa çalışma zamanı hatası alırız.
	 The page '/WebForm2.aspx' cannot use the user control '/CalendarUserControl.ascx', 
     because it is registered in web.config and lives in the same directory as the page.
     
     USER CONTROL'lerin kendi özellikleri ve methodları olabilir.
     USER CONTROL'e SELECTEDDATE özelliği ekliyoruz.
     FORM'a bir BUTTON yükleyip, Clik EVENT'inde özelliği kullanabiliz.
     Özellik HTML bilirimi olarak, düzenleme zamanında da kullanılabilir.
     
     HTML'de yaptığımız ayar DESIGN'a otomatik olarak yansımıyor. Bunu düzeltmek için
     1. USER CONTROL yerine CUSTOM CONTROL oluştur.
     2. DLL oluştur ama USER CONTROL'ün içinde olduğu PROJE'nin DLL'ini kullanırısın.
     Bunlardan sonra bahsedilecek gelecek ter EVENT ve DELEGATE'ler
     
     */

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(CalendarUserControl1.SelectedDate);
        }
    }
}