using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _134_AddToSiteUsingAjax
{
    //134'den 140'a kadar IMAGE CONTROL'le gilili dersler var.
    //Kodlar DEFAULT.aspx sayfasında
    /*ADD IMAGE
        WEBFORM'a ScriptManager CONTROL'ü at. 
        Bu CONTROL araç kutusunda AJAX EXTENSION altındadır. 
        ScriptManager CONTROL'ünü asp.net ajax framework'lerinden yaralanabilmek için kullanılır.
     
      FORM'a UpdatePanel at. 
        Bu CONTROL'ün bir EVENT gerçekletiğinde, 
        sadece UPDATEPANEL'le ilgili olan veri SERVER'e gönderilir ve karşılığı olan veri dönderilir. Sayfanın tamamı gönderilmez. 
        Bir sayfanın duyarlılığı, PARTIAL PAGE POSTBACK ile arttırılabilir.
        PARTIAL PAGE POSTPACK'in başka bir yararı da FULL PAGE POSTBACK değil ekran sıçramalarını önlemesidir.
     
      UPDATEPANEL'in tüm içeriği CONTENTTEMPLATE tagının içine olmalıdır. 
      Bu alana bir TIMER ve IMAGE CONTROL at.
      TIMER CONTROL, açıkken belirtilen zaman aralığına göre TICK EVENT'i çalıştırır. Verilen ZAMAN değeri mili saniyedir.
      Bu EVENT'de belirttiğimiz sürede resimlerin değişmesini sağlayacağız.
    */
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
