using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _89_WindowsAndFolderLevelAuthorization
{
    /*
     Admin doyasındaki sayfalara erişim sadece administratorlere verilmeli. Sayfaların geri kalanları herhangi biri tarfında erişilebilir. 
     Bunu elde etmek için admin dosyasına başka bir web.Config dosyası ekle ve aşağıdaki kodları ilave et.
     <authorization>
       <allow roles="Administrators" />
       <deny users="*" />
     </authorization>
     
     Uygulama root düzeyi web.config dosyası authenticated tüm kullanıcılara izin verir .
     <authorization>
       <deny users="?"/> 
     </authorization> 

    
    Çok yaygın bir asp.net mülakat sorusu
    Birden falza web.config dosyasının birden fazla olması mümkünmü ? evet se Neden birden fazla web.config dosyası kullanırsınız.
    Klasik sorulardan biridir, birden fazla web.config dosyası nerede gereklidir?

    Administrator hasabı girişi kullanarak  uygulama kodlarını çalıştırmak istiyorsan ozaman Admin klasörünün web.config dosyasıdaki impersonation onayla. 
    Bu yerdeki değişiklik ile, Admin klasöründeki tüm sayfalar kullanıcı hesap girişi kullanarak çalıştırılırken dışarıda ki klasörler APP POOL kimliğini kullanarak çalıştırılır.
    
     */
    /*
     
	 Bu videoda bir örnek ile FOLDER LEVEL AUTHORIZATION hakkında tartışacağız. 
     Aşağıda görünen solution explorer proje yapısını düşün. 

     Admin klasöründeki sayfalara bağlanmak için izin sadece adminlere verilmeli. 
     Sayfaların geri kalanı herhangi biri tarafından bağlanılabilir. 
     Admin klasöründe WEB.CONFIG dosyası ekle ve aşağıdaki yetki nesnelerini ekle.
        
        <authorization>
          <allow roles="Administrators" />
          <deny users="*" />
        </authorization>

     Uygulama temel düzeyi WEB.CONFIG'dosyası. Tüm kimlikli kullanıcılara izin verir.
    
        <authorization>
          <deny users="?"/> 
        </authorization> 

     Çok ortak bir asp.net görüşme sorusu

     Bir den fazla WEB.CONFIG dosyası mümkünmü? evet se 
     Birden fazla WEB.CONFIG dosyasını ne zaman ve neden kullanırız.

     Birden fazla WEB.CONFIG dosyasına ihtiyacımız olduğunda bu klasik örneklerden biridir.

     Administrator hesabında giriş yaparak uygulama kodlarını çalıştırmak istiyorsan,
     o zaman Admin klasörünün WEB.CONFIG dosyasında kişileştirmeye izin ver.

     Bu ayarları yerleştirerek, kullanıcı hesabı girişi kullanarak admin klasöründeki sayfalar çalıştırılır iken, klasörün dışındaki sayfalar uygulama havuzunun kimliği kullanılarak çalıştırılır.
     
     <system.web>
       <authorization>
         <allow roles="Administrators" />
         <deny users="*" />
       </authorization>
       <identity impersonate="true"/>
     </system.web>

     Özel bir kullanıcı adı ve şifresi ile IMPERSONATION mümkündür. 
     Bu ayarlar ile, Admin grubudan ait herhangi bir kullanıcı Admin klasründen bir sayfaya ne zaman istek gönderirse göndersin kodlar VENKAT hesabı kullanılarak çalıştırılacak.
     
     <system.web>
       <authorization>
         <allow roles="Administrators" />
         <deny users="*" />
       </authorization>
       <identity impersonate="true" userName="Venkat" password="test"/>
     </system.web> 
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
    }
}