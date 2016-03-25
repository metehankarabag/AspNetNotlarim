using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _143_DifferenceBetwenHttpGetAndHttpPostMthods
{
    /*HTTP GET VE POST
      
     HTTP SERVER ile istemici arasındaki iletişim için kullanılan en yaygın protokoldur.
        
     1. GET REQUEST genellikle SERVER'den sayfayı çağarmak için kullanılır
        HYPER LINK,Response.Redirect(),URL+Enter ile bir sayfaya ulaşmak için SERVER'e GET ile gideriz.
     
      2. POST REQUEST genellikle SERVER'de çalışıtrmak için veri gönderirken kullanırız.
        Submit butona tıkladığında 
        AutoPostBack true iken ve bir seçim yaptığında.    
   
      GET ve POST İstekleri arasındaki farklar.
      1. GET ile SERVER'e sadece QUERY STRING kullanarak URL'den veri gönderebiliriz. Post ile her yerden.
      2. QUERY STRING'in sınırı vardır. POST REQUEST'te herhangi bir kısıtlama yoktur.
      3. GET ile SERVER'deki veri değiştirilebilir ama önerilmez.
      4. WEBFORM sayafında IsPostBack SERVER'e gidiş methodumuz belirler. 
        SERVER GET ile gidiyorsak FALSE, PROST ile GİDİYORSAK TRUE alırız.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm2.aspx?FirstName=" + txtFirstName.Text +
                "&LastName=" + txtLastName.Text + "&Email=" + txtEmail.Text);
        }
    }
}