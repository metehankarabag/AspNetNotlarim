using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _39_UseSubmitBehaviorPropertyOfButton
{
    /*USESUBMITBEHAVIOR PROPERTY OF THE BUTTON CONTROL
     Tüm butonların üstüne tıklanmadan enter ile çalışması için USESUBMITBEHAVIOR özelliği vardır.
     Varsayılan olarak TRUE'dur. 
     2 buton varsa ve özellik değeri TRUE ise öndeki çalışır. Böyle bir durumda öndeki butonu atlamak istiyorsak özelliği FALSE yapıcaz. 
     Üstteki duruma ayarlar ulaşılırsa kullanıcı CLEAR'a kolay ulaşır ve ENTER ile işini görür.
      
     USESUBMITBEHAVIOR özelliği BUTTON CONTROL'ün tarayıcı yapısı veya ASP.NET POSTBACK mekanizmasından hangisini kullanıdığını belirler.
     Bu özellik FALSE olarak ayarlanırsa ASP.NET veriyi göndermek için istemci taraflı SCRİPT kodu yazar. 
     
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            TxtName.Text =string.Empty;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            LblMessage.Text = "You Entered = " + TxtName.Text;
        }
    }
}