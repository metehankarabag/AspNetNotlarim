using System;
using System.Web.UI.WebControls;

namespace _24_ExampleOfCheckBoxList
{
    /*CheckBoxList Select Or Deselect All List
     
     
     
     
     
    */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CheckBoxList1.SelectedValue = "2";
                //CheckBoxList1.SelectedIndex = 1; is post back içine almadan yaparsak sadece bu seçilebilir.
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected)
                {
                    Response.Write(li.Text + "<br/> ");

                }
                
            }            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in CheckBoxList1.Items)
            {
                li.Selected = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in CheckBoxList1.Items)
            {
                li.Selected = false;
            }
        }
    }
}