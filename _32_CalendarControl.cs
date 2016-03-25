using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _32_CalendarControl
{
    /*Calendar Control
     
     SELECTIONCHANGED: Kontroldeki seçim değeri değiştiğinde yapılacak işleri yazıyoruz.
     
     DAYRENDER: Kontrol görünür duruma geldiğinde 49 gün gösteri bu olay her gösterilen gün için çalışır. Takvim görünür olduğu her seferde 49 kez çalışır.
     
     DAY: DAYRENDER EVENT'inin DAYRENDEREVENTARGS parametresinden gelen e örneğine ait özelliktir.
     DAY özelliğinin birden fazla seçeneği vardır. --> ISOTHERMONTH, ISWEEKEND, ISSELECTABLE
     
     CELL: DAY gibi E nin özelliği hücrelere işlem yapmak için kullanılır(genelde renk vermek için)
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToString("d");// to string herşeyi veriyor. d, D, dd/MM/yy
            Calendar1.Visible = false;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Cell.BackColor = System.Drawing.Color.Azure;
            e.Cell.ForeColor = System.Drawing.Color.DarkGreen;
            if (e.Day.IsOtherMonth || e.Day.IsWeekend)
            {
                
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.White;
                e.Cell.ForeColor = System.Drawing.Color.Red;
                e.Cell.Visible = false;
            }            
        }
    }
}