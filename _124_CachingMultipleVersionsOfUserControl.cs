using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _124_CachingMultipleVersionsOfUserControl
{
    /*USER CONTROL'ün birden fazla cevabını önbelleğe almak 
      OutputCache yönergesinin VaryByControl özelliği kullanıyoruz.
      Satırları veri türüne göre gösteren bir STRORED PROCEDURE kullandık.
	  
      USER CONTROl'e gerekli yönergeyi ekle.
      Aynı işe  [PartialCaching(60, VaryByControls = "DropDownList1")] ATTRIBUTE'u ile ulaşabiliriz.
     
      Uygulamayı çalıştır ve test et. 
      DROPDOWNLIST'de şeçim her değiştiğinde, 
      USER CONTROL, her farklı sonuç için önbelleğe alınır.
      WEBFORM'da ön belleğe alma olmadığı için alınmaz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToString();
        }
    }
}