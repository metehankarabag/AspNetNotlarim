using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _48_CustomValidator
{
    /*CUSTOM VALIDATOR
     VALIDATIONEMPTYTEXT: Kontrol ettiğimiz yer değer girilmediğinde, Özellik değeri FALSE ise validationdan geçer, TRUE ise takılır
     TRUE olduğunda bizim SERVERVALIDATE EVENT'imize gidiyor. Biz burda INT değerlerle çalışıyor. Artık EMPTY değerde delebilir EMPTY gelirse 0 olarak atanması lazım bu yüzden TRYPARSE kullanıyoruz.
      
     TRYPARSE: boolen değer döner. 1. parametrede çevirme doğru ise TRUE döner ve değeri 2. parametre olan çıkış parametresine adar böylece hem BOOLEAN değer alır hemde rakamı alırız.

    CLIENTVALIDATIONFUNCTION buna SCRIPT gibi bir dil ile method yazdığımızda methodun adını veriyoruz CLIENT 
    ONSERVERVALIDATE: özelliği SERVERVALIDATE EVENT'ı oluşturuyor. Yani bu özelliğede SERVER tarafında çalışan bir METHOD veriyoruz.

     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblStatus.Text = "Data Saved";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "Validation Error! Data Not Saved";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void CustomValidatorEvenNumber_ServerValidate(object source, ServerValidateEventArgs args)
        {
/*args.value girilen değeri ServerValidateEventArgs  buraya alıryor girilen değer duğru ise ısvalied kullamamızı sağlıyor. bu durum kontrole özel*/
            //if (Convert.ToInt32(args.Value)%2==0)
            //{
            //    args.IsValid = true;
            //}
            //else
            //{
            //    args.IsValid = false;
            //}

            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else
            {
                int Number;
                bool isNumber = int.TryParse(args.Value, out Number);
                if (isNumber && Number >= 0 && (Number % 2) == 0)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }
    }
}