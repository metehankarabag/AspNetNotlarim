using System;
using System.Data;
using System.Web.UI.WebControls;

namespace _18_BindingAnDropDownListWithAnXMLFile
{
    /*DropDownList'e XML ile bağlanma
	DataTextField: Kullandığımız CONTROL'e bir dosyadan TEXT değeri alır.
	DataValueField: Kullandığımız CONTROL'e bir dosyadan VALUE değeri alır.
	DataSource: Kullandığımız CONTROL'ün veri kaynağını belirler.
	*/
    //Server.MapPath(): Web serverdeki sanal yolu karşılayan fiziksel dosya yolunu döner.
    //ReadXml(): parametre olarak fiziksel yol alır.

    /*Not: Insert özelliği 1. parametreye öğenin ekleneceği indexi alır. parametreyede öğeyi alır. Yani ilk 10 index dolu olsa bile bu kod 0 den nesneleri ekleyecek.
     Add() methodu sürekli Listenin başına ekleme yapıyor bu yüzden ilk eklenen sonra kalıyor.
     */
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            string strPhysicalPath = Server.MapPath("Countries.xml");
            DS.ReadXml(strPhysicalPath);
            DropDownList1.DataTextField = "CountryName";
            DropDownList1.DataValueField = "Countryid";
            DropDownList1.DataSource = DS;
            DropDownList1.DataBind();

            ListItem li = new ListItem("Select","-1");
            DropDownList1.Items.Insert(0,li);

        }
    }
}