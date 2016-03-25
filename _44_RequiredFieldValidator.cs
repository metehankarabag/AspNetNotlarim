using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _44_RequiredFieldValidator
{
    /*REQUIRED FIELD VALIDATOR CONTROL
     
     INITIALVALUE: Kontrollerdeki belirli değerlerin bu kontrole takılması için kullanılır. Örnek DROWDOWNLIST'de varsayılan değer.
     
     
     
     
     
     VALIDATOR'ler script kullanılarak kontrollun sağlanıp sağlamadığını kontrol ederler. 
     Browserlardan script kodlarını etkisizleştirip bu denetimden kurtulabilirler. 
     Buda büyük bir güvenlik açığı demektir. Bu yüzden kod kısmından aynı işi c# ile yazıyoruz.
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Data saved successfully!";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Data not valid and not saved!";
            }
           
        }
    }
}