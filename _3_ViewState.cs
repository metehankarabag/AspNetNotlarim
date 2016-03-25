using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*Web application work on HTTP protocol. HTTP protocol is a stateless(vatansız) protocol,meaning it is not retain (alı koymak) between user request*/
namespace _3_ViewState 
{                          /*.aspx classtır*/
    public partial class ViewState : System.Web.UI.Page
    {
        int ClicksCounts = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Text = "0";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClicksCounts = ClicksCounts + 1;
            TextBox1.Text = ClicksCounts.ToString();
        }
    }
}