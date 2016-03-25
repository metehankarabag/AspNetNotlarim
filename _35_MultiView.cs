using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _35_MultiView
{
    /*MULTI VIEW CONTROL
      Occupy = işgal etmek
      MULTI VIEW CONTROL varsayılan olarak WEBFORM'da hiçbir şey göstermeyecek. Yüklediğim hangi görüntüyü görmek istedimi MULTI VIEW CONTROL'e söylemek zorundayım.
      Bunu nasıl söylerim sayfa 
      ACTIVEVIEWINDEX: Özlliği çalıştığında aldığı index değerindeki VIEW'ı gösteirir.
     */
    /*Kısa yollar  
      Alt+ctrl+alt yön tuşu işe sayfalar arası geçilir.
      Alt+ctrl+x ile toolbox paneline geçilir.
      Alt+ctrl+l ile solution paneline geçilir.
      f4 ile properties paneline geçilir
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                multiViewEmployee.ActiveViewIndex = 0;
            }
        }

        protected void btnGoToStep2_Click(object sender, EventArgs e)
        {
            multiViewEmployee.ActiveViewIndex = 1;
        }

        protected void btnBackToStep1_Click(object sender, EventArgs e)
        {
            multiViewEmployee.ActiveViewIndex = 0;
        }

        protected void btnGoToStep3_Click(object sender, EventArgs e)
        {
            lblFirstName.Text = txtFirstName.Text;
            lblLastName.Text = txtLastName.Text;
            lblGender.Text = ddlGender.SelectedValue;

            lblEmail.Text = txtEmail.Text;
            lblMobile.Text = txtMobile.Text;

            multiViewEmployee.ActiveViewIndex = 2;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            multiViewEmployee.ActiveViewIndex = 1;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Write ado.net code to save data to a database table
            Response.Redirect("~/Confirmation.aspx");
        }
    }
}