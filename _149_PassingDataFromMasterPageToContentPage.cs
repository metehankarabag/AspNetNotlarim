using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _149_PassingDataFromMasterPageToContentPage
{
    /*Kodlar StudentSearch sayfasında, Geçen derste yaptığımız gibi CONTROL dönen PROPERTY'ler oluşturuyoruz. CONTROL'lerin EVENT'larını CONTENT PAGE'de çalıştırıyoruz. Yani MASTER'de EVENT gerçekleşiyor ama CONTENT'de çalışıyor ve sunucu CONTENT'e alabiliyoruz.*/
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
        }
    }
}