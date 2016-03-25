using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _40_WizardTemplates
{
    /*Neden Lazım olduğu
     
     Amacımız her adımdaki TEXTBOX'a FOCUS() uygulamak.
     Bu kod Page_Load da (yorum olan kodlar) çalışmadı.
     Çünkü PAGE_LOAD EVENT'i BUTTON_CLICK EVENT'inden ÖNCE çalışır. Yani bir kez sayfa yenilenir veya bir sonraki adıma geçilirse bu sefer değer gelir. 
     Bize button click eventten sonra çalışan bir event lazım buda Page_PreRender event
     
     */
    /*WIZARD CONTROL TEMPLATES
     HTML'de DESIGN bölümünde kontroldeki ok tan bu özelliğe tıklıyoruz bize tane buton ekliyor.
     Fakat bu BUTTON'lar özgür değiller. Bu yüzden Kod kısmına direk çağıramıyoruz.
     
     FINDCONTROL(): Bu method HTML de veya Çalışma zamanında dinamik olarak CONTROL bulmamızı sağlar. Verilen alan adı içinde CONTROL arar.
     
     Biz Wizard1 CONTROL'ünün bir TEMPLATE'in de bir CONTROL bulacağız.
     Burda BUTTON'a ulaşabilmek için bir hieraşi var. Bu hieraşi ID'yi VIEW PAGE SOURCE'den alıyoruz.
     
     TEMPLATEYİ bulmak için FINDCONTROL() metohdunu WIZARD CONTOL'üne uyguladık.
     Metoda parametre olarak TEMPLATE ID'yi girdik(ID yi PAGE VIEW SOURCE'den almıştık)
     BUTTONU'bulmak için bu sefer methodu bulduğumuz TEMPLATEYE uygulamamız lazım. 
     Parametre olarak BUTTON ID'yi gireceğiz.
     
     */

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Wizard1.ActiveStepIndex == 0)
            //{
            //    Step1Textbox.Focus();
            //}
            //else if (Wizard1.ActiveStepIndex == 1)
            //{
            //    Step2Textbox.Focus();
            //}
            //else if (Wizard1.ActiveStepIndex == 2)
            //{
            //    Step3Textbox.Focus();
            //} 
            Button btn = (Button)Wizard1.FindControl("StepNavigationTemplateContainerID").FindControl("StepNextButton");
            btn.OnClientClick = "return confirm('Are you sure you want to go to next step')";
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            
            if (Wizard1.ActiveStepIndex == 0)
            {
                Step1Textbox.Focus();
            }
            else if (Wizard1.ActiveStepIndex == 1)
            {
                Step2Textbox.Focus();
            }
            else if (Wizard1.ActiveStepIndex == 2)
            {
                Step3Textbox.Focus();
            }            
        }
    }
}