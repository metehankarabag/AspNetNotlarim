using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _82_ApplicationPools
{
    /*
      Asp.net geliştirme sunucusu yani bu Vs'nun IIS'i dir. 
      Sadece uygulamayı geliştirmek için Asp.net geliştirme ortamı kullanılabilir.
      fakat iş bittikten sonra uygulamamızın son kullanıcıya gösterilemesini istiyorsak, IIS kullanacağız.
      Bunu yapmanın 2 yolu var. 
      projesine sağ tıkla - properties - web varsayılan olarak Vs development server kullanıyor. 
      Bunun terine Ben IIS web server kullanmak istiyorum
      http://csharp-video-tutorials.blogspot.com/2012/12/application-pools-in-iis-part-82.html
      
      Bu derste öğreneceklerimiz
      IIS de Uygulama havuzu nedir?
      IIS'de uygulama havuzu oluşturma
      Uygulama havuzu kimlikleri
      Bir Asp.net uygulaması ile uygulama havuzunu ilişkilendirme.
      
      
      IIS TE uygulama havuzu nedir.
      Birden fazla oluşturabileceğimiz ve her birinde birden fazla uygulama içerebilen uygulamadır.
      Farklı APP POOL'da uygulamalar kendi worker processlerinde çalışır. 
      Bir APP POOL'da oluşan hata, başka bir APP POOL'da çalışan uygulamayı etkilemeyecektir.
      
      Yani bir APP POOL resetlenirse, sadece havuzdaki uygulamalar etkilenir(worker process içinde saklanırsa durum bilgileri serbest kalabilir.),
      ve diğer uygulama havuzundaki uygulamalar etkisizdir. 
      
      Uygulamaları farklı uygulama havularına dağıtma bize her uygulama için farklı güvenlik ve kullanılabilirlik ayarları sağlar.
      Örneğin host sağlayıcıları seni rakip firma uygulamalarını, tuttuğu APP POOL'lardan farklı bir APP POOL'da tutabilir. 
      Bu senin dosyalarını korur.
      
      Creating application pools in internet information services(IIS)
      RUN -->INETMGR --> IIS penceresinde ---> Application Pools'a sat tıkla ---> select Add Application Pool --> isim ver.
      
      APP POOL kimlikleri nelerdir?
      Asp.net uygulamaları w3wp.exe adındaki işleyiciler içinde windows kimliği kullanarak çalıştırılır.  
      Kullanılan windows kimliği, uygulama kullandığı havuzu kimliği ile bağlıdır. 
      
      Uygulama havuzu kimliği aşağıdaki kurulu hesaplardan herhangi biri olabilir.
      1. LocalService 2. LocalSystem 3. NetworkService 4. ApplicationPoolIdentity
      
      ****
      Üstteki türlere ek olarak, kendimiz de isim ve şifre belirterek yapabiliriz.
      Varsayılan APP POOL kimliği, APP POOL kimliği ApplicationPoolIdentity'dir. 
      Bunu değiştirmek için
      APP POOL'a sağ tıkla --> select "Advanced Settings" --> Process Model bölümü altındaki Identity'e tıkla
      Buradan ya kurulu olanları seç yada bir kullanıcı adı veya şifre oluştur -- ok'a tıkla çık
      
      1. Local System: Tamamen hesap güvenilir, çok yüksek ayrıcalıkları olan ve ağ kaynaklarına erişebilen bir hesap türüdür.
      2. Network Service: Sınırlı servis hesabı genellikle uygulama çalıştırmak için kullanılır. 
        En az özelliği olan servis türüdür. Bu hesap türü network kaynaklarına bağlantı kurabilir --> test etme için kullanılır.
      3. Local Service : Sınırlı servis hesabı  Network sercive hesabına cok benzerdir.
      4. ApplicationPoolIdentity: bir App Pool oluşturulduğunda IIS bir app pool ismi ile sanal bir hesab oluşturur ve bu hesabın worker process leri altında APP POOL'u çalıştırır
      bu da en ayrıcalıklı hesaptır.
      
      Note: Düşük ayrıcalığı olan bir kimlikle çalışmak, yazılım hatası oluduğunda hacker'ların uygulamayı hacklemesini engeller.
      
      Asp.net web uygulamasını App Pool ile ilişkilendirme.
      Bir uygulama oluştur --> IIS'i aç --> root altında sites e tıkla--> Default web site sağ tıkla Add application --> bir isim ver fiziksel yol özelliğine uygulamanını fiziksel yolunu belirt.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
        }
    }
}