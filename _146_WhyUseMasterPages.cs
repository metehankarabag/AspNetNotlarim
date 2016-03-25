using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _146_WhyUseMasterPages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        /*Tüm sayfalarımız boyunca bir düzen(bir önceki slaytdakine benzeyen)'e sahip olmak için master page kullanmadan 2 yol kullanabiliriz.
          Aşağıdakiler bu yaklaşımın problemleridir.
          1 - Her sayfada bir çok kod ikilemesi olacak
          2 - Biz ortak düzende bir şeyi değiştirmek istersek, tüm sayfalarda bu değişikliği yapmak zorunda kalırız. Bu da zaman kaybına ve hata ya yakınlığa neden olur
            
          önemli bir şey yazmıyor.
         */
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}