using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _11_RadioButton
{
    /*Radio Button Control
     Checked: özelliği radio buttonlar arasında şeçili olanları bulur. Boolean değer döner. Seçili olanlar ile işlem yaparken NULL REFERANCE EXCEPTION hatası almamak için IF kullanacağız
     Group Name: Radio Buttonları gruplamak için kullanılan özelliktir. Gruplama yapıldıktan sonra grup içinden sadece bir tane radio button şeçilebilir.
     
     CheckedChanged olayı: Bu olay uygulandığı radio buttondaki seçim durumu değiştirildiğinde çalışır.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                Response.Write("Your gender is "+ RadioButton1.Text+"<br/>");
            }
            else if (RadioButton2.Checked)
            {
                Response.Write("Your gender is " + RadioButton2.Text + "<br/>");
            }
            else if (RadioButton3.Checked)
            {
                Response.Write("Your gender is " + RadioButton3.Text + "<br/>");
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Response.Write("Male Radio button selection changed <br/>");
        }
    }
}