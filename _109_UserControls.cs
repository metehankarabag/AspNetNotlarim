using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _109_UserControls
{
    /*
     Her nedense USER CONTROL'leri dinamik olarak yüklemek isteyebiliriz.
     Örneğin admin ve admin olmayan kullanıcıları dayalı, farklı kullanıcı CONTROL'leri yüklemek.

     Internet bilgilerinin çoğunda, POCTBACK karşısında VIEWSTATE'ı korumak için dinamik olarak oluşturulmuş, 
     USER CONTROL'leri istiyorsak,CONTROL'ler WEBFORM olaylarından PAGE_INIT()'de yüklü olmalı. 
     
     ben PAGE_LOAD() olayı kullandım, fakat CONTROL'ler VIEWSTATE değerlerini korudu.

     Dinamik olarak eklenecek CONTROL'ler için önemli olan bir nokta CONTROL'lerin nereye ekleneceğidir.
     Control.ADD() ile CONTROL'ü sayfaya direk eklemeye çalıştığımızda,
     CONTROL'ün önünde başka bir CONTROL yoksa, CONTROL form dışına eklenir.
     varsa, CONTROL sayfanın en altına eklenir.
     Bu yüzden PLACE HOLDER gibi bir nesne içine eklemessek RUN - TİME EXCEPTION alabiliriz. -- HttpException 
     
          
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarUserControl CUC = (CalendarUserControl)LoadControl("~/UserControls/CalendarUserControl.ascx");
            CUC.ID = "CU1";
            CUC.DateSelected += new DateSelectedEventHandler(CUC_DateSelected);
            CUC.CalendarVisibilityChanged += new CalendarVisibilityChangedEventHandler(CUC_CalendarVisibilityChanged);
            PlaceHolder1.Controls.Add(CUC);

        }

        protected void CUC_CalendarVisibilityChanged(object sender, CalendarVisibilityChangedEventArgs e)
        {
            Response.Write("Calender Visible = " + e.IsCalendarVisible.ToString() + "<br/>");
        }

        protected void CUC_DateSelected(object sender, DateSelectedEventArgs e)
        {
            Response.Write(e.SelectedDate.ToShortDateString() + "<br/>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(((CalendarUserControl)PlaceHolder1.FindControl("CU1")).SelectedDate);
        }
    }
}