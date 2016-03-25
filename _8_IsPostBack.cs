using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _8_IsPostBack
{
    /*Is Post Back
    IsPostBack, PAGE'nın bir istemciye POSTBACK cevabı olarak( in response to) veya sayfanın ilk kez yüklenip yükenmediğini belirlemek için kullanılan PAGE seviyesinde bir özelliktir
 
   *WHAT İS CAUSİNG DUPLICATION
    Biz tüm ASP.NET SERVER Biz tüm ASP.NET SERVER kontrollerinin durumalrını POSTBACK boyunca tuttuğunu(retain) biliyoruz. Bu kontroller Viewstate'den yararlanır(make use of). Yani, sayfa ilk kez yüklendiğinde. ŞEHİRLER DropDownList' e doğru bir şekilde eklenir ve istemciye gönderilir.
 
    Şimdi, İstemci bir butona tıkladığında, ve PAGE ,PAGE INITIALOZATION esnasında işleme için servere geri postalandığında, View State yenilemesi(restoration) olur. Bu aşama sırasında, ŞEHİR isimileri VIEWSTATE'den alınır ve DROPDOWNLIST'e eklenir.
 
    PAGE LOAD EVENT webForm yaşam çemberinde sonra olur. PAGE LOAD esnasında biz şehirlerin başka bir kümesini tekrar ekleriz. Bundan dolayı DUPLICATION
    */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {// if i silip LoadCityDorpDownList.Items.Clear(); yada viewstate false yap ama bunu yapınca seçili nesne hafızada tutulmuyor.
            if (!IsPostBack)
            {
                LoadCityDorpDownList();
            }
        }
        public void LoadCityDorpDownList()
        {
            ListItem li1 = new ListItem("London");
            DropDownList1.Items.Add(li1);
            ListItem li2 = new ListItem("Sydeny");
            DropDownList1.Items.Add(li2);
            ListItem li3 = new ListItem("Mumbai");
            DropDownList1.Items.Add(li3);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
/*
 * IsPostBack is a Page level property,that can be used to determine(belirlemek) whether the page is being loaded in response to a client postback, or if it is being loaded and accessed for the first time.
 
 *              WHAT İS CAUSİNG DUBLİCATİON
 *We know that all ASP.NET server controls retain their state across postback.These controls make use of Viewstate.So,  the fist time, when the webform load.The cities get corrctly added to the DropDownList and sent back to the client.
 
 *Now, when the client clicks the button control, and the webform is posted back to the server for processing,During Page initialization, View State restoration happens. During this stage, the city names are retrieved from the viewstate and added to the DropDownList.
 
 *Page Load event happends later in the life cycle of the webfrom. During page load we are again adding another set of cities. Hence, the dublication.
 */