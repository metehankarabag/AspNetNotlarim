using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _104_UserControls
{
    /*USER CONTROL
      Özel sayfalarda HTML VEYA SERVER CONTROLLERİ ile birleşirilerek oluşturulabilir.
      Sayafada birleştirdiğimiz tüm CONTROL'ler tek bir CONTROL'muş gibi başka sayfalara eklenir.
      
      Yapacağımız iş tarih seçmek
	  1. Kullanıcı takvim resminde tıklar.
      2. Takvim kontrolu görünür olur.
      3. Kullanıcı takvimden bir tarih seçer.
	  4. TEXTBOX CONTROL'i seçili tarih ile otomatik olarak doldurulur ve takvim görünmez olur.
      
      32. derste bu işi tartişmıştık.
     
      USER CONTROL hazırlama sayfaları WEBFORM'lara benzerdir.
      WEBFORM sayfa uzantısı ASPX, USER CONTROL sayfa uzantusu ASCX'dir. 
      WEBFORM'lar @Page DIRECTIVE'i ile başlar, USER CONTROL @Control ile başlar ve HTML gibi tagları olmaz.
     */
    public partial class CalendarUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e) { if (!IsPostBack)Calendar1.Visible = false; }

        protected void ImgBtn_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible) Calendar1.Visible = false;
            else                   Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }
    }
}