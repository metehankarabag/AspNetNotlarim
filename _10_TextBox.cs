using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _10_TextBox
{
    //ToolTip: Controlün üzerine mouse ile gelindiğinde açıklama österir.
    //Focus() methodu sayfa yüklendiğinde uygulandığı CONTROL'e direk işlem yapmayı sağlar
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.ToolTip = "text box bir bu ne yin açıklamasını yapayım anlamadım";
            TextBox1.Focus();
            TextBox2.Focus();
            TextBox3.Focus();
        }
    }
}