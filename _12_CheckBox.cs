using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;/*eklendi*/

namespace _12_CheckBox
{
    /*CheckBox Control
     
     Kullanıcının birden fazla şeçim yapabilmesini istiyorsak kullanıyoruz.(Gruop Name özelliği vermessek bu işi oda yapabilir.)
     
     Focus(): Uygulandığı kontrole tıklama gerekliliği kalmadan klavyeden değer girebilmek için kullanılır.
     
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckBox1.Focus();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder UserChoices = new StringBuilder();
            if (CheckBox1.Checked)
            {
                UserChoices.Append(" " + CheckBox1.Text);
            }
            if (CheckBox2.Checked)
            {
                UserChoices.Append(", " + CheckBox2.Text);
            }
            if (CheckBox3.Checked)
            {
                UserChoices.Append(", "+CheckBox3.Text);
            }
            Response.Write("Your selections : "+ UserChoices.ToString());
        }
    }
}