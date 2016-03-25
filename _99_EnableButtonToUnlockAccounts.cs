using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace _99_EnableButtonToUnlockAccounts
{
    /*LockedAccounts.aspx
     Bu 98. bölüme devamdır. ENABLE BUTTON'u yapmak için, aşağıdaki değişiklikleri GRIDVIEW CONTROL'e uygula 

     1. Değişiklik : Şablon sütununda BUTTON CONTROL'ün COMMANDARGUMENT özelliğini belirt.
     2. Değişiklik: GRIDVIEW CONTROL'ü için ROWCOMMAND EVENT HANDLER oluştur.

     1. GRIDVIEW CONTROL'e sağ PROPERTIES'i seç tıkla.
     2. PROPERTIES WINDOWS'da EVENT'a tıkla
     3. EVENT WINDOWS'da ROWCOMMAND event'ına tıkla.
     
     LockedAccounts.aspx.cs sayfasında aşağıdaki methodu kopyala ve yapıştır.
     Aşağıda göründüğü gibi ROWCOMMAND() EVENT HANDLER'da ENABLEUSERACCOUNT() methodu çağır.
     
     */
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            AuthenticateUser(txtUserName.Text, txtPassword.Text);
        }
        private void AuthenticateUser(string username, string password)
        {
            // ConfigurationManager class is in System.Configuration namespace
            string CS = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            // SqlConnection is in System.Data.SqlClient namespace
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //Formsauthentication is in system.web.security
                string encryptedpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

                //sqlparameter is in System.Data namespace
                SqlParameter paramUsername = new SqlParameter("@UserName", username);
                SqlParameter paramPassword = new SqlParameter("@Password", encryptedpassword);

                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int RetryAttempts = Convert.ToInt32(rdr["RetryAttempts"]);
                    if (Convert.ToBoolean(rdr["AccountLocked"]))
                    {
                        lblMessage.Text = "Account locked. Please contact administrator";
                    }
                    else if (RetryAttempts > 0)
                    {
                        int AttemptsLeft = (4 - RetryAttempts);
                        lblMessage.Text = "Invalid user name and/or password. " +
                            AttemptsLeft.ToString() + "attempt(s) left";
                    }
                    else if (Convert.ToBoolean(rdr["Authenticated"]))
                    {
                        FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkBoxRememberMe.Checked);
                    }//daha güvenli olması için else eklenip sifre yanlış denilebilir. beklenmeyen bir durum olursa die.
                }
            }
        }
    }
}
/*Why are we executereader because we are gonna get row of date it is not scayle value it's going to be row of data so */