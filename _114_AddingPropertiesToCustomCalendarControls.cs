using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _114_AddingPropertiesToCustomCalendarControls
{
    /* Custom CONTROL'lere PROPSERTY ekleme.
	Şu anda,COMPOSITE CALENDAR CONTROL'ün IMAGE BUTTON'unun bir resmi yok. 
	Bir resim ile ilişkilendirmek için ImageButtonImageUrl özelliği oluşturalım.

	
	CONTROL'ü kullanmadan önce Güncellenmiş DLL'i sayfaya eklememiz gerekiyor.
	CONTROL'e sağ tıkla özellikleri şeç özelliği gürürsün.
	Bir resim ekle, eklemeyi yaptıktan sonra DESIGN modda resim görünmez ama çalışma zamanında görünür.
     
	Bu sorunu düzelmek için RECREATECHILDCONTROLS() unun üzerine yazıyoruz.
	Oluşturduğumuz CONTROL'ün alt CONTROL'lerini yeniden oluşturmak için kullanılır.


	CHILD CONTROL'lerin görünümünde sorun var
	Bu sorunu çözmek için RENDER() methodunun üzerine yazıyoruz.
	Bu method bir tabloda takvim ve yazı kutusu koyar ve iç boşluk ekler.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}