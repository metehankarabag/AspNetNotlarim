using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _148_PassingDataFromContentPageToMasterPage
{
    /*MASTER PAGE'e CONTENT PAGE'den veri girme
      TYPE CAST'ı kullanayacağız yada HTML'de MASTERTYPE DIRECTIVE'ini kullanacağız.
      MASTERTYPE DIRECTIVE STRONGLY TYPED REFERANCE verir.

      TextBoxOnMasterPage READ ONLY özelliktir fakat text atayabiliyioruz.
      Çünkü bize TEXTBOX dönüyor.
      Yani bize sonuç olarak bir TEXTBOX veriyor bizde bunun text özelliğine değer atıyoruz.
    */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            //((Site)Master).TextBoxOnMasterPage.Text = TextBox1.Text;
            Master.TextBoxOnMasterPage.Text = TextBox1.Text;
            //((Site)Page.Master).TextBoxOnMasterPage.Text = TextBox1.Text;
        }
    }
}