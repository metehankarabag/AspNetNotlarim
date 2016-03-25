using System;

namespace _27_RadioButtonList
{
    /*RadioButton List Control
     
     REPEATDIRECTION,REPEATCOLUMNS bunlar var
     REAPAETLAYUOT: Bu özellik RADIOBUTTON LİST'in HTML e nasıl çevirileceğini belirlemek için kullanılır.
     Varsayılan olarak TABLE değerindedir.
     Flow: tablo kullanmaz. 
     UNORDERLIST ve ORDERLIST'de var: Bunlardan birini şeçtiğimizde düzenleme zamanında hata alırız. Bunun nedeni Buttonların HORIZONTAL olarak sıralanmış olmasıdır. VERTICAL yap.
     
     
     
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Radiobuttonlist1.SelectedValue != null)
            {
                Response.Write("Text = " + Radiobuttonlist1.SelectedItem.Text + "<br/>");
                Response.Write("Value = " + Radiobuttonlist1.SelectedItem.Value + "<br/>");
                Response.Write("Index = " + Radiobuttonlist1.SelectedIndex.ToString());
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Radiobuttonlist1.SelectedIndex = -1;
        }
    }
}