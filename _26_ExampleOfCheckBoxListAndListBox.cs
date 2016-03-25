using System;
using System.Web.UI.WebControls;

namespace _26_ExampleOfCheckBoxListAndListBox
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {//seçili kutucuk sayısına göre dönüyor döngü
            ListBox1.Items.Clear();
            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected)
                {
                    ListBox1.Items.Add(li.Text);                    
               }                
            }

            if (CheckBoxList1.SelectedIndex == -1)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Label1.ForeColor = System.Drawing.Color.Black;
            }
            Label1.Text = ListBox1.Items.Count.ToString() + " İtem(s) selected";
        }
    }
}