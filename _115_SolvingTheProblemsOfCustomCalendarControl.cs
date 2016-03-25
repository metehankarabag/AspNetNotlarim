using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _115_SolvingTheProblemsOfCustomCalendarControl
{
    /* Bu derste yapılacaklar	 
	  İlk yüklendiğinde CusomCalender CONTROL'isaklama
      Resim butona tıklandığında takvimi gösterme ve saklama
	  Takvimden seçilen tarih ile yazı kutusunu doldurma
	  Bir webform da CustomCalendar kontrolundan seçilen tarihi geri alma
	 
	  1. İlk yüklendiğinde CusomCalender CONTROL'isaklama
	  ilk ayarlar varsayılan ayarlardır. Yani Kurulumda belirlenir bu yüzden CreateChildControls() içinde görünürlüğü ayarlayacağız.
	  
	  2. Displaying and hiding the calendar, when the image button is clicked:
      EVENT CHILD CONTROL'e ait olduğu için oluşturulma sırasında bir CLICK EVENT ekliyoruz. 
      Olay her gerçekleştiğinde olmasını istediğimiz işi belirtiyoruz.
      NOT: Oluşturma CreateChildControls() methodu içinde olduğu için CHILD CONTROL'e EVENT burada ekleniyor.
          Method içinde methodu oluşturamayacağımız için EVENT'da kullanıdığımız methodu bunun dışında kalıyor.
      
	  3. CHILD CALENDER CONTROL'ünden şeçilen tarih ile CHILD TEXTBOX'ı doldurma 2. durum ile ayın sadece kodlar farklı
      
	  4. CHILD CALENDER CONTROL'de seçilen tarih değerini, CUSTOM CALENDAR CONTROL'den kullanıcıya verme.
         kullanıcının CUSTOM CALENDAR CONTROL'e verdiği değeri CHILD CONTROL'lere alma.
      
      Bu iş için CUSTOM CONTROL'e PROPERTY eklememiz gerekiyor.
     
	  Form'a CUSTOM CONTROL ve bir BUTTON CONTROL ekle CUSTOM CONTROL'den seçilen tarihi CLIK olayında yazdır.
    */

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}