using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _71_CustomErrors
{
    /*CUSTOM ERRORS
    
     CUSTOM ERROR PAGES 2 düzeyde tanımlanabilir.
     1. APPLICATION LEVEL - WEB.CONFIG dosyasıda CUSTOM ERRORS nesneleri kullanarak
     2. PAGE LEVEL - PAGE DIRECTIVE, ERRORPAGE özelliği kullanarak
     
     PAGE LEVEL CUSTOM ERROR PAGES, APPLICATION LEVEL CUSTOM ERROR PAGE'lere göre öncelik alır. 
     CUSTOM ERROR PAGES mevcut HTTP durum kodlarının birine veya daha fazlasina özel bir sayfa cevabıyla gösterilme esnekliği sağlar. 
     Tüm HTML DURUM listesi için Liste için tıkla
     
     http://en.wikipedia.org/wiki/List_of_HTTP_status_codes
     
     APPLICATION düzeyinde CUSTOM ERROR PAGE belirmek için, WEB.CONFIG'de CUSTOMERRORS kullan
     
     MOD özelliği CUSTOM ERROR PAGE, YELLOW SCREEN OF DEATH üzerinde gösterildiğinde EXCEPTION sayfası belirtir. Mod özelliği açık, kapalı veya sadece uzaktan olabilir. Varsayılan sadece uzaktan
     
     On - CUSTOM ERROR PAGE LOCAL'de ve SERVER'da gösterilir.
     Off - CUSTOM ERROR PAGE hiç bir yerde gösterilemez.
	 RemoteOnly - CUSTOM ERROR PAGE sadece uzak makinada gösterilir ve EXCEPTION sayfası ordadır.
     
     GLOBAL.ASAX'daki APPLICATION_ERROR() EVENT HANDLER'de yeniden yöndendirme yapılırsa CUSTOM ERROR PAGE aktif olmayacaktır.
     
     Uygulamanda, özel HTTP durum kodu için CUSTOM ERROR PAGES göstermek zorundaysan, o zaman ayarlı hataları kullan. 
     Sadece bir tane genel hata sayfan varsa o zaman Global.asax kullanılabilir.
     
     
     DİKKAT ET: EXCEPTION nesnesi, kullanıcı CUSTOM ERROR PAGE'e yöndendirilmeden önce alınması gerekebilir. 
     Çünkü SERVER.GETLASTERROR() hedef CUSTOM ERROR PAGE'de hiç bir şey dönmez ve ERROR kaybolacağından dolayı içerik,  CUSTOM ERROR PAGE'e yönlendirme sayesinde gösterilir.
     
     Page level de Eror vermek için Page direktif inde ErrorPage="~/fdsf.aspx" i kullanılıyoruz
     
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Countries.xml"));
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}
//Countries.xml i sildik.
//GLOBAL.ASAX.CS'ye kod yazmadan önce çalıştırdığımızda,
//UNAUTORIZED ERROR sayfasına gittik. UNAUTORIZED ERROR WEB.CONFIG'den sildiğimizde.
//INTERNAL SERVER ERROR verdi. Bunu sildiğimizda DEFAULT'a gitti. 
//UNAUTORIZED ERROR PAGE düzeyinde uygulayınca GLOBAL.ASAX.CS kod yazılı iken
//ve WEB.CONFIG'de de kod varken PAGE düzeyindeki sayfaya gideceğiz.