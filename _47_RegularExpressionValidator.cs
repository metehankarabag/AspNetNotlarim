using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _47_RegularExpressionValidator
{
    /*REGULAR EXPRESSION VALIDATOR
     REGULAR EXPRESSION PROPERTY'den içine kullanacağımız text i alıyoruz. 
     Tüm VALIDATOR'lerde kodun istemci tarafında çalışmasını engellemek için ENABLECLIENTSCRIPT özelliği var FALSE yapıyoruz. 
     Uygulamayı test ederken 
     Hızlı çalışabilmek için PROPERTY'den ENABLED FALSE yap VALIDATION çalışmayacak.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblStatus.Text = "Data saved";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "Data not saved";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}