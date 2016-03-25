using System;

namespace _21_RetrievingSelectedItemTextValueAndIndexOf
{
    /*Retrieving Selected Item Text Value And IndexOF
     
     SelectedItem.Text: Listede görünen kısmıda gelecek değer yazılır.
     SelectedItem.Value : Bu özellik öğelere değer atamak için kullanılır. Bu değerleri Listeden öğeleri bulmak için kullanırız. String değer alır ve döner.
     SelectedIndex: Listedeki öğelerin sırasına göre öğeyi bulur. int değer döner.
     SelectedValue: Value özelliğine girilen değere göre öğeyi bulmamızı sağlar.
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dropdownlist1.SelectedValue = "-1";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Dropdownlist1.SelectedValue=="-1")
            {
                Response.Write("Please select  a Continent");
            }
            else
            {
                Response.Write(Dropdownlist1.SelectedItem.Text + "<br/>");
                Response.Write(Dropdownlist1.SelectedItem.Value + "<br/>");
                Response.Write(Dropdownlist1.SelectedIndex + "<br/>");
            }
        }
    }
}