using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _36_Wizard
{
    /*DEFFERENCE MULTIPLEVIEW AND WIZARD CONTROL
     

     MULTIPLEVIEW CONTROL kullandığımıza birden fazla VIEW adımları arasında hareket etmek için kullandığımız buttınları sağlamak zorundayken.
     WIZARD CONTROL'ler bizim için buttonları sağlayacak. Onlar  WIZARD CONTROL'ün yapısında bulunur.
     
     WIZARD CONTROL'ün text özelliğe adımların açıklamasını yazıyoruz.
     WIZARD CONTROL'ü adımları kendi atar ama adımlar arasında bilgi geçişi vermek için CLICK EVENT i oluşturmalıyız. WIZARD CONTROL'ünün NEXTBOTTONCLICK EVENT'ini kullanıcaz.
     Butona tıklamayacağız. Bir sürü next buttonu olabilir. İşlem yapılacak butonu belirlemek için butonun index numarasını kullanıcaz.
     İlk butonun indexi 0 dır.(Previous butonların event olayı ayrı) 
     
     NEXTBOTTONCLICK EVENT'ının WizardNavigationEventArgs parametresinin e örneğinin özelliği olan NextStepIndex e gelen değeri IF ile kontrolettirip işlem yapabiliriz.
     
     Bu event olayı finish butonu içinde geçerli bitirmek istediğimizde ne olcağını event kullanarak yapıyoruz
     
     WIZARD'ın text özelliğine yazdığımız yazı SIDEBAR olarak geçiyor ve propertiden SIDEBARSTYLE kullanarak yazı yeri rengi gibi ayarlar yapılabilir.
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (e.NextStepIndex == 2)
            {
                lblFirstName.Text = txtFirstName.Text;
                lblLastName.Text = txtLastName.Text;
                lblGender.Text = ddlGender.SelectedValue;

                lblEmail.Text = txtEmail.Text;
                lblMobile.Text = txtMobile.Text;
            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {//Redirect ile başla sayfaya gönderiyoruz
            Response.Redirect("~/Confirmation.aspx");
        }  
    }
}