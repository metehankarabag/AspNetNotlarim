using System;
using System.Web.UI.WebControls;

namespace _25_ListBox
{
    /*ListBox Control
     Seçilen nesneler üzerind çalışırken NULL REFERANCE EXCEPTION almamak için IF kontrolü kullanıyoruz.
     
     Rows: Listbox'da kaç nesne grünecek onu belirliyoruz.
     
     LISTBOX'daki öğelerden varsayılan olarak sadece bir tane seçilebilir.
     
     SelectionMode ile birden fazla seçim yapmayı saşlayabiliriz
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex != -1)
            {             //single olan listbox için
            Response.Write("Text = " + ListBox1.SelectedItem.Text + "<br/>");
            Response.Write("Text = " + ListBox1.SelectedItem.Value + "<br/>");
            Response.Write("Text = " + ListBox1.SelectedIndex.ToString() + "<br/>");
            Response.Write("**********************************************<br/>");
            }

            foreach (ListItem li in ListBox2.Items)
            {
                if (li.Selected)
                {
                    Response.Write("Text = " + li.Text + "<br/>");
                    Response.Write("Value = " + li.Value + "<br/>");
                    Response.Write("Index = " + ListBox2.Items.IndexOf(li).ToString() + "<br/>");
                    Response.Write("-------------------------------------------------<br/>");
                }
            }
        }
    }
}