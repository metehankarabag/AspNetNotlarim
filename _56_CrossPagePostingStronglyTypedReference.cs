using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _56_CrossPagePosting_StromglyTypedReference_
{
    /*TYPE SAFE CROSS PAGE POSTING
	  
      Yönlendirilecek sayfada verileri PROPERTY'i içinde alabilmek için PROPERTY oluştur.
      PROPERTY'e değer ataması istemediğimiz için sadece GET PROPERTY oluşturduk.
	  
      PROPERTY isimleri yanlış girilirse, düzenleme zamanı hatası alırız.
      TYPE SAFE mantığı çalışma zamanı hatalarını engellemek için kullanılır.
      
      PREVIOUS PAGE TYPE YÖNERGESİ, TYPE SAFE PREVIOUS PAGE sağlar.
      Örneğimizde WEBFORM2 için bir önceki sayfa WEBFORM1'dir. 
      WEBFORM2.ASPX'e aşağıdaki yönergeyi eklediğimizde, bu sayfanın bir önceki sayfası her zaman aynıdır. 
	  Bu da TYPE SAFE mantığı. -Bilinen sayfa türü/veri türü/nesne türü.
      <%@ PreviousPageType VirtualPath="~/WebForm1.aspx" %>
	  
	  Yani kısaca güçlü bir bağlantı türü elde etmek için 2 yol temel adım var.
	  Birinci adım Public property oluşturmak
      İkinci adım güçlü bir bağlantı türü TypeCasting ederek veya PreviousPageType yönergesi kullanarak elde etmek
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        //Name - read only property
        public string Name
        {
            get
            {
                return txtName.Text;
            }
        }
        //Email - read only property
        public string Email
        {
            get
            {
                return txtEmail.Text;
            }
        } 
    }
}