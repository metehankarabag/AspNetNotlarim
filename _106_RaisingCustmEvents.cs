using System;

namespace _106_RaisingCustmEvents
{
    /*
      Bir DELEGATE örneğini oluştururken, EVENT anahtarı kullanırsak DELEGATE'de kullandığımız method EVENT olur.
      Kısaca DELEGATE örneği bir methodu temsil eder.
      Bu örneği doldurabilmek için DELEGE kurucusuna bir methodu vermeliyiz.
      DELEGATE parametre belirtiyorsa kurucuya eklenecek method'da aynı parametreyi vermelidir.
      Bu yüzden methodu parametreleri ile kullanmak zorundayız.
  
      USER CONTROL sayfasında boş bir EVENT örneği oluşturduk.
      Yani örneğin temsil edebileceği bir method yok 
      bu durumda çalıştabileceği bir method da yok.
      ama örneğe parametre vererek, başka bir method içinde çalıştırmışız.
      if kontrolünün amacıda bu zaten 
      Bir yazılımcı yazdığımız olayı kullanmak istiyorsa bu EVENT örneğini istediği method ile kurmalı.
      kurmamışsa EVENT'ı çalıştıramayız.
      
      Event'i çalıştırdığımız methodu PROTECTED ve VOID yaparak,  oluşturduğumuz CONTROL'den bir CLASS türetildiğinde bu olayda ek işler yapabilir.
  
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CalendarUserControl1.CalendarVisibilityChanged += new CalendarVisibilityChangedEventHandler(CalendarUserControl1_CalendarVisibilityChanged); 
            //-= kullanarak 1 tane daha yaparsak bunu silmiş gibi oluyoruz.
            // bu kodu Page_PreRender e yaparsak sonuç alamayız çünkü eventhandler Page_Load tan hemen sonra olur.
            //VS CalendarVisibilityChanged  olayının bir delege kullanacağını
        }

        protected void CalendarUserControl1_CalendarVisibilityChanged(object sender, CalendarVisibilityChangedEventArgs e)
        {
            Response.Write("Calendar visible = " + e.IsCalendarVisible.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(CalendarUserControl1.SelectedDate);
        }
    }
}