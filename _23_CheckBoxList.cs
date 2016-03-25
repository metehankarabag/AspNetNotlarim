using System;
using System.Web.UI.WebControls;

namespace _23_CheckBoxList
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        /*SelectedIndex, SelectedValue, SelectedItem
		SELECTEDINDEX Şeçilen nesnlerin INDEX değerni alır bu değerle öğeye ulaşırız. INT değer döner.
		Birşey seçilmesse -1 değeri alıyor. Bu NULL'a eşittir.
		
		SELECTEDVALUE'de aynı mantık.
        Kontrolün VALUE özelliğine girdiğimiz STRING değer ile öğeyi bulmamızı sağlar. STRING değer döner
		
		SELECTEDITEM öğelerin şeçili olup olmadığını kontrol eder.
		BOOLEAN değer döner.
        
		Bir CONTROL'den şeçili olan nesnelerle çalışmak istiyorsak, nesnelerin şeçili olanlarını bulmak için IF kullanmalıyız. Kullanmassak NULL REFERANCE EXCEPTION alırız.
		*/
        /*Özellikleri
         REPEATDIRECTION: tekrarlanma yönünü belirtir.
         REPEATCOLUMS: tekrarlanma yönünde kaç sütun gidileceğini belitir.
         */
        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in CheckBoxList1.Items)
            {
                Response.Write(CheckBoxList1.SelectedIndex.ToString()+ " ");
                if (CheckBoxList1.SelectedItem !=null)
                {
                    Response.Write(CheckBoxList1.SelectedItem.ToString()+ ",");
                }
                

                //if (li.Selected)
                //{
                //    Response.Write("Text = " + li.Text + ", ");
                //    Response.Write("Value = " + li.Value + ", ");
                //    Response.Write("Index = " + CheckBoxList1.Items.IndexOf(li));
                //    Response.Write("<br/>");
                //}
                
            }
            
        }
    }
}