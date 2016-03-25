using System;

namespace _152_MasterPageCntentPageUserControlLifeCycle
{

    /*Master-Content-UserControl ilin çalışma sırası
     Bu uygulamayı çalıştırdığımızda INIT yüklemesi aşağıdaki gibidir.
     TextBox Init Event
     UserControl Init Event
     Master Page Init Event
     Content Page Init Event
     
     Bunun anlamı INIT EVENT'lar en içerideki CONTROL'den en dışarıdaki CONTROL'e doğru çalışıyor.
     Yani en dışarıda CONTENT PAGE var. Yani MASTER PAGE, CONTENT PAGE içine bir CONTROL gibi eklenir.
     
     INIT EVENT'lar içten dışa doğru çalışırken, diğer bütün EVENT'lar dıştan içe çalışır.
     Yani, ASPX sayfalar en işten çalışmaya başlar, en dıştan yüklenmeye başlar.
    
     Content Page Load Event
     Master Page Load Event
     TextBox Load Event
     UserControl Load Event
    
     TextBox, UserControl ve çalışma sırasındaki durum eklenme sırası ile alakalı.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e) { Response.Write("Content Page Init Event<br/>"); }
        protected void Page_Load(object sender, EventArgs e) { Response.Write("Content Page Load Event<br/>"); }
        protected void Page_PreRender(object sender, EventArgs e) { Response.Write("Content Page PreRender Event<br/>"); }

        protected void TextBox1_Init(object sender, EventArgs e) { Response.Write("TextBox Init Event<br/>"); }
        protected void TextBox1_Load(object sender, EventArgs e) { Response.Write("TextBox Load Event<br/>"); }
        protected void TextBox1_PreRender(object sender, EventArgs e) { Response.Write("TextBox PreRender Event<br/>"); }

        protected void TestUC1_Init(object sender, EventArgs e) { Response.Write("UserControl Init Event<br/>"); }
        protected void TestUC1_Load(object sender, EventArgs e) { Response.Write("UserControl Load Event<br/>"); }
        protected void TestUC1_PreRender(object sender, EventArgs e) { Response.Write("UserControl PreRender Event<br/>"); }
    }
}