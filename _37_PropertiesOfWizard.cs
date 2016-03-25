using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _37_PropertiesOfWizard
{
    /*
      ActiveStepIndex             Used to set or get the ActiveStepIndex of the wizard control
      
      DisplayCancelButton      -  WIZAR CONTROL'deki CANCEL BUTTON'un görünürlüğümü beriler(Determine).
      CancelDestinationPageUrl -  CANCEL BUTTON tıklandığında  hedef(destination) PAGE'ya yönlendirmek için. Bu uygulamada bir sayfa veya harici(external) web site olabilir.
      CancelButtonImageUrl     -  CANCEL BUTTON'un türü IMAGE BUTTON olarak yaralanırsa, resim belirlemek için bu özelliği kullan.
      CancelButtonStyle        -  CANCEL BUTTON'u düzenlemek için
      CancelButtonText         -  CANCEL BUTTON'un türü LINK BUTTON veya BUTTON sa,BUTTON'un text'ini belirlemek için bu özelliği kullan.
      CancelButtonType         -  CANCEL BUTTON'un türünü belirlemek için kullan.Bu BUTTON, LINK BUTTON, IMAGE BUTTON, BUTTON olabilir.
      
      DisplaySideBar           -  Sidebarı görünürlüğünü ayarlar
      
      FinishCompleteButtonType -  Bitiş butonunun türünü belirliyor.
      FinishPreviousButtonType -  Geri butonunun türünü belirliyor.
      
      HeaderStyle              -  Sayfalara başlık veriyor hmtl ile yapıldığında her sayfaya aynı başlığı veriyor ama cod ile her sayfaya farklı başlık yapabiliriz. Bunu Pre_Render even'ti kullanarak yapıcaz.
      HeaderText               -  The header text of the wizard control
      
      araçların özellillerini veriyor.
      NavigationButtonStyle    -  The style properties to customize the wizard navigation buttons
      NavigationStyle          -  The style properties to customize the navigation area that holds the navigation buttons
      
      SideBarButtonStyle       -  The style properties to customize the wizard sidebar buttons
      SideBarStyle             -  The style properties to customize the wizard sidebar
      
      StartNextButtonType      -  Başlangıç a start butonu next yerine
      StepNextButtonType       -  Başlangıç ve bitiş arasındaki start butonu next yerine
      StepPreviousButtonType   -  Geri butonun türünü beriliyor
      StepStyle                -  The style properties to customize the wizard steps
      
      Note: WizardSteps can be added in the HTML source or using the WizardSteps collection editor. 
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (1 == 1)
            {
                Wizard1.ActiveStepIndex = 1;
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Wizard1.ActiveStepIndex == 1)
            {
                Wizard1.HeaderText = "Contact Details";
            }
            else if (Wizard1.ActiveStepIndex == 2)
            {
                Wizard1.HeaderText = "Summary";
            }
        } 
    }
}