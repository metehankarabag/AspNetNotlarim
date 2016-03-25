using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _43_CreatingControlsDynamicallyUsingPanel
{
    /*ADD DYNAMICALLY CONTROL'S
     
     Bunu yaparken en öncemli nokta kontrollerin doğru yerelere eklenmesini sağlamak.
     Kontrolleri PAGE'ye doğru eklemek için birden fazla yol var.
     
     1 - PLACEHOLDER 
     2 - TABLO
     3 - PANEL CONTROL
     4 - FORM
     
     CONTROL'ler PAGE kullanılarakda eklenebilir.
     
     CONTROL'leri PAGE'ye eklerek FORM'un dışına ekler hata alırız. PAGE yerine FORM'a eklersek FORM'un en altına ekleniyor bütün kontroller. Bunu düzelmek için eklemek istediğimiz satırlara ID'ler verebiliriz. This kullanmamıza gerek yok zaten anlar.
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnGenerateControl_Click(object sender, EventArgs e)
        {
            // Kullanıcı TEXTBOX'a CONTROL sayısı girdi.
            int Count = Convert.ToInt16(txtControlsCount.Text);
            // CHECKBOX'ile hangi CONTROl'ü kullanmak istediğini anlıyoruz.
            foreach (ListItem li in chkBoxListControlType.Items)
            {
                if (li.Selected)
                {
                    //Seçili olanlardan Lable değerli olanlar için 
                    if (li.Value == "Label")
                    {               //istediği ayıda CONTROL ekliyoruz.
                        for (int i = 1; i <= Count; i++)
                        {
                            Label lbl = new Label();//ID'ler otomatik değişiyor.
                            lbl.Text = "Label - " + i.ToString();
                            //phLabels.Controls.Add(lbl);
                            //tdLabels.Controls.Add(lbl);
                            pnlLabels.Controls.Add(lbl);
                            //this.Page.Controls.Add(lbl);
                        }
                    }
                    
                    else if (li.Value == "TextBox")
                    {
                        for (int i = 1; i <= Count; i++)
                        {
                            TextBox txtBox = new TextBox();
                            txtBox.Text = "TextBox - " + i.ToString();
                            //phTextBoxes.Controls.Add(txtBox);
                            //tdTextBoxes.Controls.Add(txtBox);
                            pnlTextBoxes.Controls.Add(txtBox);
                            //this.Page.Controls.Add(txtBox);
                        }
                    }
                    // Generate Button Controls
                    else
                    {
                        for (int i = 1; i <= Count; i++)
                        {
                            Button btn = new Button();
                            btn.Text = "Button - " + i.ToString();
                            //phButtons.Controls.Add(btn); // satır içine place holder ekleyip içine attı
                            //tdButtons.Controls.Add(btn); // eklenecek satıra id verip içine attı
                            pnlButtons.Controls.Add(btn);  // Satır içine panel kontrol ekleyip içine attı.
                            //this.Page.Controls.Add(btn); // bunuda kontrolleri sayfa sonuna eklemek istersek yapabiliri.(form1 kullanarak)
                        }
                    }
                }
            }
        } 

    }
}