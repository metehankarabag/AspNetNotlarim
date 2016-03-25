using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _51_HyperLinkControl
{
    //Sadece burada yazı var.
    /*NAVIGATION TECHNIQUES
	
	  Sayfa değiştirme teknikleri arasındaki farklar nelerdir?
	  Bir uygulamaya nasıl link verirsin? veya
	  Bir WebForm'dan diğerine nasıl gidersin?
	  Görüşme sorusu olarak sorulan sorulardır.
	  Bir sayfadan başka birine gitmek için kullanılabilecek teknikler aşağıda mevcuttur.
      1. HYPERLINK CONTROL- Bu dersde işlenecek olan - Farklı sunucuya yönlendirebilir.
	  2. RESPONSE.REDIRECT - Farklı sunucuya yönlendirebilir.
      3. SERVER.TRANSFER - Farklı sunucuya yönlendiremez.
      4. SERVER.EXECUTE - Farklı sunucuya yönlendiremez.
      5. CROSS-PAGE POSTBACK
      6. WINDOW.OPEN      
     */
    /* 1. HYPERLINK -- 13. derste Control'den bahsedildi.
	  Sayfalar arasında gezinmek için kullanılır, 
	  Gidilecek sayfanın URL'i NAVIGATEURL özelliğine yazılır.
	  Keni uygulaması içindeki bir sayfaya veya farklı bir uygulamadaki sayfaya gidebilir.
	  Sayfa geçmişini hatırlar ve URL'i değiştirir.
	  Tarayıcıya <a> Tag'ı olarak gönderilen bir controldür.
	  
	  
	  HYPERLINK'in EVENT'ı yoktur. Yani SERVER'e sadece yeni bir sayfa getirmek için gider.
	  SERVER'da EVENT'ı olan CONTROL'ler - LINK BUTTON, BUTTON, IMAGE BUTTON
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
    }
}