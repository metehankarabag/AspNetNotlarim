using System;
using System.Web.UI.WebControls;

namespace _153_MenuControl
{
    /*MENU CONTROL --> ContentSayfalar projesindeki base pagenen kullanılan master'ı değiştir.
     ORIENTION PROPERTY'si: CONTROL'ün sıralanma şekli belirleniyor. Oriention ENUM'undan bir değer alıyor.
     STATICDISPLAYLEVELS: Her zaman gösterilecek Menü seviyelerini belirliyor.
     DISAPPEARAFTER: STATIC olmayan menülerin görünme süresini belirler.
     
     Menü controlün kendisine veya bölümlerine veya böülmlerdeki nesnelere STYLE uygulanabilir. 
          
     STATICMENUSTYLE - STATIC görünen Menü alanı için özellikleri belirtir.
     STATICMENUITEMSTYLE - STATIC görünen Menü nesneleri için özellikler belirtir.
     STATICSELECTEDSTYLE - Seçilen nesnelerin alacağı özellikleri belirtiyor. 
        Bir sorunu var bir Nesne seçildiğinde NAVIGATION uygulanırsa değeri hatırlamıyor. Bu yüzden aşağıdaki CECK methodunu kulanıyoruz.
     STATICHOVERSTYLE - FARE ile üzerine gelindiğinde alınacak özellikleri veriyoruz.
     
     
     DynamicMenuStyle 
     DynamicMenuItemStyle 
     DynamicSelectedStyle 
     DynamicHoverStyle 

     LevelMenuItemStyles: Bu özellikte yukarıdakiler ile aynı mantıkta, fark burada LEVEL'lere levellerin içindeki nesnelere tek bir yerden değer girmeyi sağlar. bu özelliğie eklenen MENUITEMSTYLE nesnesinin 3. 3. levele değerlerini verir.
     
     
     
     */
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e) { foreach (MenuItem item in Menu1.Items) { Check(item); } }

        private void Check(MenuItem i)
        {   //NavigateUrl değeri ile SERVER'e giden URL'i alıyoruz. Fakat SERVER ABSULUTE URL gidiyor 1. parametre ROOT kısımını siliyor. 
            //Kelimede büyük küçük har uygumuna takılmamak için
            //ELSE IF ile yapılan Menü öğesinin alt öğeri varsa hepsi için üstteki işlemi uygula
            if (i.NavigateUrl.Equals(Request.AppRelativeCurrentExecutionFilePath, StringComparison.InvariantCultureIgnoreCase)) i.Selected = true;
            else if (i.ChildItems.Count > 0) { foreach (MenuItem menuItem in i.ChildItems) Check(menuItem); }
        }
    }
}