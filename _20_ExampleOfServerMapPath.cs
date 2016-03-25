using System;
using System.Data;

namespace _20_ExampleOfServerMapPath
{
    /*server.mapPath bize sayfanın bulunduğu klasörün yolununu veriyor ../../ 2 klasör gidip root a geliyoruz sonra xml e gidiyoruz
     // en iyisi ~/ kullanmaktır
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            DS.ReadXml(Server.MapPath("../../Data/Countries/Countries.xml"));
            
            //Response.Write(Server.MapPath("Data/Countries/Countries.xml") + "<br/>");
            //Response.Write(Server.MapPath("../../Data/Countries/Countries.xml"));
            DropDownList1.DataTextField = "CountryName";
            DropDownList1.DataValueField = "Countryid";
            DropDownList1.DataSource = DS;
            DropDownList1.DataBind();
        }
    }
}