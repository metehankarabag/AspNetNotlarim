using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _150_DefultContentInContentplaceholdrOfMaster
{
    /*
      CONTENT PAGE'ler sadece kendi işlerini yapar ve CONTENTPLACEHOLDER'larda da işlemler yapabiliriz.
      her 2 sindede işlem varsa sadece CONTENT PAGE işlemleri görünür. 
      CONTENTPLACEHOLDER'in işlemlerinin CONTENT PAGE'lerde geçerli olmasını istiyorsak,
      CONTENT PAGE'lerde sadece Page yönergesini ayırıp, kalan herşeyi sileceğiz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}