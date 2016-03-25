using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _121_ControllingCachingInCode
{
    /*CACHING IN CODE 
      Bu iş için RESPONSE nesnesinin CACGE PROPERTY'si kod da kullanılabilir.
      Bu özellikl HTML'de OutputCache yönergesine benzeyen HttpCachePolicy nesnesi olarak döner. 
     
      1. SetExpires(): CACHEING süresini belirler.
      2. Response.Cache.VaryByParams["None"] özelliği WEBFORM'ün önbellek sayısını belirliyor.
      3. HTML'de Location özellği, kodda SetCacheability() methodunu CACHE nesnesinin sağlandığı yeri kontrol etmek için kullanılır. 
	
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(30));
            Response.Cache.VaryByParams["None"] = true;
            Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);

            Label1.Text = "This page is cached by the server : "+DateTime.Now.ToString();
        }
    }
}