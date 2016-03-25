using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _45_RangeValidator
{
    /*RANGE VALIDATOR CONTROL
     
     MINIMUMVALUE ve MAXIMUMVALUE değerleri ile aralığı belirliyoruz. TYPE: İle değer türünü belirliyoruz.
     Hiç bir değer girilmesse o zaman bu kontrol çalışmıyor.
     2 CONTROl'ü bir CONTROL'e uyguladığımızda 1. CONTROL'ün hata mesajını almassak mesaj yerinde boşluk olur ve 2. hata mesajı olması gereken yerden uzakta görünür. 
     
     Bunu düzelmek için DISPLAY özelliğini kullanıyoruz.
     DISPLAY:  3 şeçeneği var. Dynamic ile düzeltilir.
     NONE: Şeçeneği şeçili ise hata mesajları görünmez. VALIDATIONSUMMARYCONTROL için kullanılır.
     
     Her CONTROL'e eklenmesi gerekiyor.
     
     RANGEVALIDATOR Tarihler içinde kullanılabilir.
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnSave_Click(object sender, EventArgs e)
        { /*TÜM VALİDATORLERİN İSVALİD ÖZELLİĞİ VARDIR*/
            if (Page.IsValid)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Data Saved successfully";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Validation Failed! Data not saved";
            }
        }
    }
}