using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _50_ValidationGroups
{
    /*VALIDATION GROUPS
     
     VALIDATION içindeki bilgileri silmek istiyoruz. Fakat VALİDATİON hataları var.
     Clear butonu serverde çalışır. Hatalar yüzünden SERVERE GİDEMEYİZ. Bunu düzelmek için CAUSESVALIDATION özelliğini FALSE olarak ayarla     
     
     2. BUTTON'a her tıkladığımızda tüm sayfa SERVER'e gider ve sayfadaki tüm VALIDATION CONTROL'leri çalışır.
        Yani, bir BUTTON tıklanığında sadece bazı VATIDATİON'ların kontrol edilmesini istiyoruz.
        Bunu için kontrolleri ve çalıştıracağı BUTTON'u bir Grup içine alıyoruz.
        Tüm nesneleri seçtikten sonra VALIDATIONGROUP özelliğine bir isim veriyoruz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblStatus.Text = "No registration validation Errors";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "Registration validation Errors";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblLoginStatus.Text = "No Login Validation Errors";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "Login validation errors";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}