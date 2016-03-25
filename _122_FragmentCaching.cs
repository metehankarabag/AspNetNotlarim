using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _122_FragmentCaching
{

    /*Önbellek parçası
     
      Tablodaki tüm satırları dönen bir STORED PROCEDURE kullanıdık.

	  Steps to fragment cache a webform
	  1. USER CONTROL içinde sürekli değişmeyen sayfanın özel bölümlerini kapsar.
      2. OutputCache yönergesini USER CONTROL'de kullan.
      3. CONTROL'ü WEBFORM'a ekle.

	  Uygulamayı çalıştırdığında kullanıcı kontrolü önbelleğe alınır.
      WEBFORM'un zamanı sürekli değişirken USER CONTROL'ün zamanı değişmedi.

	
      OutputCache yönergesi SHARED ATTRIBUTE
      Varsayılan olarak ASP.NET önbelleğe alınmış bir kullanıcı kontolünü kullanan her web form için ayrı bir cevap önbelleğe alır.
      Tüm WEBFORM'lar için tek bir CACHE nesnesi kullanabiliriz.

	  Bir WEBFORM oluştur ikisindede USER CONTROL'ü çalıştırdığında, 5 sn ye işlem sonucunu beklersin.
	  Şimdi USER CONTROL'de SHARED ATTRIBUTE değerine true ver. 
      Atık USER CONTROL'ün kullanıldığı, tüm WEBFORM'lar için tek bir önbellek nesnesi yeter.
	  	
	  WEBFORM'lardan birini çalıştır, 5 sn işlemi beklersin, diğer WEBFORm'u çalıştırdığında hemen sonuç gelir ve gerçekleşme süreleri aynı görünür.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToString();
        }
    }
}