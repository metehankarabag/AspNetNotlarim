using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _62_SessionState
{
    /*SESSIONSTATE
     Oturum durumu değişkenleri hakkında hatırlayacağın noktalar

     1. SESSIONSTATE değişkenleri varsayılan olarak web sunucu tarafından alınır, ve oturumun yaşam süresi boyunca korunur.
     2. SESSIONSTATE'in varsayılan modu InProc'dur. (Sonraki videolarda biz farklı SESSIONSTATE MOD'ları hakkında tartışacağız.)
     3. SESSION'ın yaşam süresi WEB.CONFIG dosyasında TIMEOUT değeri ile belirtilir. 
        Varsayılanı 20 dk dır. 
        TIMEOUT değeri web uygulamanın gerekliliklerine göre ayarlanabilir.
        <sessionState mode="InProc" timeout="30"></sessionState>
     
     4. SESSIONSTATE değişkenleri sadece bir belirtilen SESSION için tüm sayfalarda geçerlidir.
        SESSION VARIABLES tekil kullanıcının evrensel verisine benzer.
     5. SESSION VARIABLE'ları object türü döndüğü için TYPE CAST yapılmadılır. NULL REFERANCE hatası almamık için IF kullanmak şarttır.
         if (Session["Name"] != null) {	lblName.Text = Session["Name"].ToString();}

     6. SESSIONSTATE uygulamanın performansını azaltır. Gerekmiyorsa kapatılmalıdır.
        Sayfa düzeyinde kapatmak için sayfa yönergesine ENABLESESSIONSTATE="FALSE" eklenir.
        Uygulama düzeyinde oturum durumunu kapatmak için, WEB.CONFIG dosyasında SESSIONSTATE MODE'unu FALSE olarak ayarla.
        <sessionState mode="Off"></sessionState>
        
        Sayfa düzeyindeki ayar uygulama düzeyindekinin üzerine yazılır.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnSendData_Click(object sender, EventArgs e)
        {
            Session["Name"] = txtName.Text;
            Session["Email"] = txtEmail.Text;
            Response.Redirect("WebForm2.aspx");
        }
    }
}