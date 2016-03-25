using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _57_OpeningNewWindowsUsingJavaScript
{
    /* 
     javascript methodu windows.open() kullanarak yeni bir pencere açma . Öncelikle Windows.open() method'unun yazımı. 
     window.open(URL, name, features, replace) 
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|
ParameterName      | Description																						                             | ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|
URL (Optional)	   | Açılacak satfanın URL'idir. URL belirtilmesse, boş bir sayfa açılacak                                                           |
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|
Name (Optional)	   | Pencere adını veya açılma özelliğini belirler                                                                                   |
                   | name        - Pencere adını belirler                                                                                            |
                   | _blank      - Yeni bir pencere açar. (Varsayılan belirlenmemişdir)                                                              |
                   | _self       - Aynı pencerede açılır.                                                                                            |
                   | _parent     - Ana sayfanın bir parçası olarak açılır.                                                                           |
                   | _top        - URL replaces any framesets that may be loaded                                                                     |
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|
Features (optional)| Virgülle ayrılmış öğelerin listesi    		                                                                                     |
                   | resizable   = yes|no or 0|1                                                                                                     |
                   | scrollbars  = yes|no or 0|1                                                                                                     |
                   | toolbar     = yes|no or 0|1                                                                                                     |
                   | location    = yes|no or 0|1 (Adres çubuğunun görünürlüğünüğünü belirler. Varsayılanı yes)                                       |
                   | status      = yes|no or 0|1                                                                                                     |
                   | menubar     = yes|no or 0|1                                                                                                     |
                   | left        = yes|no or pixels                                                                                                  |
                   | top         = yes|no or pixels                                                                                                  |
                   | width       = yes|no or pixels                                                                                                  |
                   | height      = yes|no or pixels                                                                                                  |
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|
Replace(Optional)  |A boolean parameter that specifies whether the url creates a new entry or replaces the current entry in the window's history ist.|
				   | This parameter only takes effect if the url is loaded into the same window.                                                     |
                   | true    - url replaces the current document in the history list.                           	                                 |
                   | false   - url creates a new entry in the history list.                                                                          |
___________________|_________________________________________________________________________________________________________________________________|
java script document özelliğinin getElementById özelliği ile içinde çalıştırılacak nesneyi yazıyoruz 
--%>*/
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button2_Click(object sender, EventArgs e)
        {
            string strJavascript = "<script type='text/javascript'>window.open('WebForm2.aspx?Name=";
            strJavascript += txtName.Text + "&Email=" + txtEmail.Text + "','_blank');</script>";
            Response.Write(strJavascript);
        }

    }
}