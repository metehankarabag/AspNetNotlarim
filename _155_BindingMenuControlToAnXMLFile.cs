using System;
using System.Web.UI.WebControls;

namespace _155_BindingMenuControlToAnXMLFile
{
    /*MENU CONTROL
      Geçen derste Menu nesnelerini HARDCODE ile eklemiştik yani değerler sadece Projeden değiştirilebiliyordu.
      Bu zaman ve iş kaybına yol açar bu yüzden XML dosyasından değerleri menüye ekleyeceğiz böylece sadece XML'i değiştirmek yetecek.
      
      Birinci adım XMLDATASOURCE CONTROL'ünün DATAFILE özelliği ile kaynağı belirlemek.
      İkinci adım MENU CONTROL'ün DATASOURCEID özelliği ile XMLDATASOURCE'u belirlemek.
      Üçüncü adım MENU CONTROL içinde DATABINDINGS kullanmak burda kaynakdaki değerlerin nereden geleceğini belirliyoruz.
        Uygulamayı çalıştırdığımızda XML'de eklediğimiz en kapsayan nesnede MENU öğesi olarak ekleniyor. 
      Dördüncü adım ROOT elementi istemiyoruz. Bu yüzden XPATH kullanarak bir atım ilerliyoruz. XPATH="/Items/MenuItem"
      Bir önceki dersten farkı Nesnelere uygulan StaticSelectedStyle özelliği PAGE_LOAD da değil MENU1_PRERENDER'de çalışıyor.
     */
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Menu1_PreRender(object sender, EventArgs e) { foreach (MenuItem item in Menu1.Items) Check(item); }
        private void Check(MenuItem i)
        {
            if (i.NavigateUrl.Equals(Request.AppRelativeCurrentExecutionFilePath, StringComparison.InvariantCultureIgnoreCase)) i.Selected = true;
            else if (i.ChildItems.Count > 0) { foreach (MenuItem menuItem in i.ChildItems) Check(menuItem); }
        }
    }
}