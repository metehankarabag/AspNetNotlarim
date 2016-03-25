using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _46_CompareValidator
{
    /*COMVARE VALIDATOR
     
     2 kontroldeki değerleri karşılaştırmak için kullanılır.
     
     OPERATOR: ile karşılaştırma işlemini belirliyoruz.
     SETFOCUSONERROR: VALIDATION kontrollerine uygulandığında hata olan kontole odaklanmaya yarar.
     DATATYPECEHCK: Özleliği ile girilen değer türünü kontrol edebiliriz. TYPE: özelliği ile birlikte kullanılır.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblStatus.Text = "Data saved";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "Validation Failed! Data not saved";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}