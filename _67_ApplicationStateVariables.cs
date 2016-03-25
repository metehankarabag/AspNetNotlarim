using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _67_ApplicationStateVariables
{
    /*APPLICATIONSTATE VARIABLES
     1. Tüm oturumlar ve sayfaları karşısında geçerlidir. 
        Birden fazla kullanıcıların evrensel verisi gibidir.
     2. WEB SERVER'den alınır.
     3. Sadece uygulamayı barındıran işlem yeniden başlatıldığında silinir. 
        Bu uygulama sonlandığında olur.
     4. WEB FARMS ve WEB GARDENS karşısında paylaşılmaz.
     5. güvenli iş parçası değildir. 
        Uygulama sınfının kilitleme ve açma methodları race conditions, kilitlenmelere ve bağlantı ihlalleri karşısında korunmalı.
	
     Application.Lock();
     Application["GlobalVariable"] = (int)Application["GlobalVariable"] + 1;
     Application.UnLock();

     Lütfen not al: Bu örnekte, biz APPLICATIONSTATE VARIABLES'ini bir WEBFORM'dan diğerine veri göndermek içn kullanıyoruz. bir WEBFORM'dan değierine veri göndermek gereklilikse, diğer alternatifleri düşünmelisin.

     6. APPLICATIONSTATE VARIABLES'i sadece, değişkenlere bir uygulamanın yaşam süresi boyunca evrensel bağlantılar gerektiğinde ve onlara ihtiyaç duyduğunda kullan. CACHE OBJECT belirli bir süre için evrense bağlantılara itiyacın varsa alternatif olarak kullanılabilir
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSendData_Click(object sender, EventArgs e)
        {
            Application["Name"] = txtName.Text;
            Application["Email"] = txtEmail.Text;
            Response.Redirect("WebForm2.aspx");

            Response.Write("Number of Users Online ="+Application["UsersOnline"].ToString());
        }

    }
}