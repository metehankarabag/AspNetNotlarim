using System;
using System.Web.UI.WebControls;

namespace _16_DropDownList
{
    /*Drop Down List
     
     ListItem nesnelerinin bir kolleksiyonudur.
     LİstItem düzenleme ve çalışma zamanında DROPDOWNLİST'e eklenebilir.
     Selected  özelliğini true olarak ayarlandığında ListItem otomatik seçili olur.
     Enable false olarak ayarlandığında ListItem görünmez.
     Page_Load olayında DROPDOWNLİST'e bir nesne ekleyeceksen IsPostBack ile yapmalısın yapmassan her seferinde aynı nesneler listeye eklenir.
     
     ListItem nesnelerinin bir kolleksiyonudur. Aynı mantıkla aşağıdaki nesnelerde ListItem nesnelerinin bir kolleksiyonudur. Yani bunlara ListItem eklemek DROPDOWNLİST'e çok benzerdir. 
     
     CHECEKBOXLIST, RADIOBUTTONLIST, BULLETEDLIST, LISTBOX
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ListItem maleListItem = new ListItem("male", "1");
                ListItem femaleListItem = new ListItem("female", "2");

                Dropdownlist2.Items.Add(maleListItem);
                Dropdownlist2.Items.Add(femaleListItem);   
            }
            
        }
    }
}