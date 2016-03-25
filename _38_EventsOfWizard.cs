using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _38_EventsOfWizard
{
    /*WIZARD CONTROL EVENTS
     
     CancelButtonClick: Kullanıcı CANCEL'e tıkladığında server taraflı bir iş yapmamız gerekiyorsa kullanacağız.  Böyle bir işimiz yoksa PORPERTY kullanabiliriz.
     
     NextButtonClick:   Bu EVENT parametre olarak WIZARDNAVIGATIONEVENTARGS nesnesi bekliyor.
     Nesne örneği e'de CURRENTSTEPINDEX, NEXTSTEPINDEX, CANCEL özellikleri var.
     CANCEL Boolen değer döner. True değerini aldığında bir sonraki adıma geçemeyiz.
     CURRENTSTEPINDEX, NEXTSTEPINDEX : Nest butone tıklama öncesi index ve sonrası indexi alırlar.
     Bu olay Sayfalar arasında kontrol gibi işlemler için kullanılır.
     
     FinishButtonClick: NextButtonClick ile aynı parametreyi bekliyor burada da bitirme öncesi işlemler yapılabilir.
     SideBarButtonClick: FinishButtonClick ile aynı parametreyi bekliyor. Burada da geri dönme öncesi işlemler yapılabilir.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Wizard1_ActiveStepChanged(object sender, EventArgs e)
        {
            Response.Write("Active step changed to"+Wizard1.ActiveStepIndex.ToString());
        }

        protected void Wizard1_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("Cancel button clicked");
        }

        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {// bu event ile işlemler arasında yapıcak olayları belirleyebiliyoruz navigasyon gibi
            Response.Write("CurrentStepIndex = " + e.CurrentStepIndex + "<br/>");
            Response.Write("NextStepIndex = " + e.NextStepIndex + "<br/>");
            e.Cancel = CheckBox1.Checked;
            //if (CheckBox1.Checked)
            //{
            //    e.Cancel = true;// true olduğunda sonraki adıma geçmeyi engelliyor.   
            //}
            
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            Response.Write("CurrentStepIndex = " + e.CurrentStepIndex + "<br/>");
            Response.Write("NextStepIndex = " + e.NextStepIndex + "<br/>");
        }

        protected void Wizard1_SideBarButtonClick(object sender, WizardNavigationEventArgs e)
        {

        }

        
    }
}