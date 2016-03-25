using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _33_PropertiesAndEventsOfCalendar
{
    /*CALENDAR CONTROL PROPERTIES AND EVENTS
    
    CAPTION: Takvime sayı eklemek için 
    CAPTIONALIGN: Takvimin nerede görüneceğini belirliyor.
    DAYHEADERSTYLE: bir sürü ayarı var
    DAYNAMEFORMAT: Görünen gün adını düzenlemek için kullanılır. 
    FIRSTDAYOFTHEWEEK: Haftanın ilk gününü belirlemk için kullanılır.
    NEXTMONTH / PREV MONTH TEXT: Bir nceki veya sonraki takvim sayfasına geçerken kullanacağımız işareti belirliyor
    NEXTPREVFORMAT: Bir önceki veya sonraki ayın adını gösteriyor.
    SELECTIONMODE: Var sayılan olarak DAY seçilebilir. Bunu düzeltebilir.
    SELECTMONTH: SELECTIONMODE'u DAYWEEKMONTH olarak ayarladığımızda karışıklıkları gidermek için SELECT MONTH gibi bir yazı yabiliriz.
    SELECTWEEK: SELECTIONMODE'u DAYWEEKMONTH olarak ayarladığımızda karışıklıkları gidermek için SELECT WEEK gibi bir yazı yabiliriz.
     
    SELECTEDDATES: kullanıcı bir seçim yaptığında SELECTEDDATE kullanırız birden fazla şeçtiğinde bu özelliği kullanılır<.  
    
    VISIBLEMONTHCHANGED: Ay(sayfa) değiştidinde çalışır.
      
    VISIBLEMONTHCHANGED EVENT'inin MONTHCHANGEDEVENTARGS parametresinden gelen e örneğinde 2 özellik var.
     NEWDATE ve PREVIOUSDATE bunlarında özellikleri ve ay gün gibi.
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DateTime dt in Calendar1.SelectedDates)
            {
                Response.Write(dt.ToShortDateString()+ "<br/>");
            }            
        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (!e.Day.IsOtherMonth && e.Day.Date.Day % 2 == 0)
            {
                e.Cell.BackColor = System.Drawing.Color.Red;
                e.Cell.ForeColor = System.Drawing.Color.White;
                e.Cell.Text = "x";
                e.Cell.ToolTip = "Booked";
            }
            else
            {
                e.Cell.ToolTip = "Available";
            }
        }

        protected void Calendar2_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            string NewMonth = GetMontName(e.NewDate.Month);
            string OldMonth = GetMontName(e.PreviousDate.Month);

            Response.Write("Month changed "+OldMonth+" to "+NewMonth);
        }
        private string GetMontName(int MontNumber)
        {
            switch (MontNumber)
            {
                case 1:
                    return "Jan";
                case 2:
                    return "Feb";
                case 3:
                    return "Mar";
                case 4:
                    return "Apr";
                case 5:
                    return "May";
                case 6:
                    return "Jun";
                case 7:
                    return "Jul";
                case 8:
                    return "Aug";
                case 9:
                    return "Sep";
                case 10:
                    return "Oct";
                case 11:
                    return "Now";
                case 12:
                    return "Dec";
                default:
                    return "Invalid Month";
            }
        }
    }
}