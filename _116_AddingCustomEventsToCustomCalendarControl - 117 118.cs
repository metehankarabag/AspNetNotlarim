using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _116_AddingCustomEventsToCustomCalendarControl
{
    /*118
      CUSTOM CONTROL'ler kendi ASSEBLY'si içinde derlenirlerken, USER CONTROL'ler derlenmez. 
      CUSTOM CONTROL'ler TOOL BOX'a eklenebilir, USER CONTROL'ler eklenemez.
      USER CONTROL'leri web sayfası oluşturmaya benzer ve oluşturması kolaydır. 
      
      TOOLBOX'dan bir CUSTOM CONTROL'ü sürükleyip bıraktığında 2. şey olabilir.
       1. CUSTOM CONTROL'ün ASSEMBLY'si GAC içine yüklenmemişse,
          ASSEMBLY kullanılan her uygulamanın bin klasörüne eklenir.
       2. CUSTOM CONTROL'ün ASSEMBLY'si GAC içine yüklenmişse,
          Tüm uygulamalar GAC'dan referans alacağı için GAC'a yüklenmiş tek bir ASSEMBLY kopyası yeterlidir.
	  DOTNET video serisinin 3. ve 4. derslerinde GAC'a ASSEBLY yükleme anlatılmıştır.
     */
    /*117
      CUSTOM CONTROL'ü bir resim ile ilişkilendirmek için 
        ToolboxBitmap özelliğini kullan. Bu özellik System.Drawing isim uzayında mevcuttur. Bu özelliği kullanabileceğimiz 2 yol var.
      1. bir kontrolün TYPE'ını parametre olarak kullnma(varsayılan resmi alır.)
      2. Bir resim yolunu aprametre olarak kullanma
     */
    /*116 - EVENT ekleme USER CONTROL'de görmüştük.
    CUSTOM CONTROL'e 5 adımda EVENT eklenebilir. 
    
    Adım 1: EVENT verisini barındıran ve veriyi dışarı vermek için GET PROPERTY içeren bir CLASS'ı oluşturmak
	Step 2: OLay işleyici DEGATE'yi oluşturmak
    Adım 3: EVENT'ı EVENT anahtarı ile bir DELEGE örneği olarak oluşturmak.
	Adım 4: EVENT'ı çalıştırmak için Protected virtual method oluşturmak.
	Adım 5: Methodu EVENT ARGS nesnesi ile CONTROL içinde kullanmak. EVENT kurulup kodlar çalıştığında EVENT çalışmış olur.
    
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomCalendar1_DateSelected(object sender, _112_CustomCalendarControls.DateSelectedEventArgs e)
        {
            Response.Write(e.SelectedDate.ToShortDateString());
        }
    }
}