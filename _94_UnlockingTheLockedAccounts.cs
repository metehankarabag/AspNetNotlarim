using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace _94_UnlockingTheLockedAccounts
{
    /*Kilitlenmiş hesapları açma
     Approach 1: Kullanıcı yardım ister, belirli bir kişi buna oluşmu cevap verirse bir ubdate sorgusu ile işi yapar.
     Update tblUsers set RetryAttempts = null, IsLocked = 0, LockedDateTime = null where username='CallersUserName'

     Sorgu bir şekilde yanlış yazılabilir bu istenmeyen sonuçlar doğurabilir.
     Yani güncellemeyi istemediğimiz satırlari güncelleyebileceğimiz için, 
     Veri tabanında elle işlem yapılması tavsiye edilmez.
    
     Approach 2: Kilitli hesapları barındıran bir web sayfasıdır.
     Bir buton ile belirtilen kişinin bilgileri, sorumlu kişi tarafından güncellenebilir.
     Bu daha az tehlikelidir, elle yapıldığı için sorun çıkartabilir.
     Uygulaması kolaydır.

     Approach 3: Sql SERVER JOB'dur. 
     Beritilen yabloyu belirtilen aralıklarla kontrol eder. 

     SQL JOB oluşturmayı göreceğiz.
     
     Öncelikle kilitli hesapları açmak için update sorgusu yazalım. 
     Kilitli kullanıcılar genellikle 24 saat içinde açılır.

     Update tblUsers set RetryAttempts = null, IsLocked = 0, LockedDateTime = null where IsLocked = 1
     and datediff(HOUR,LockedDateTime,GETDATE()) > 24
     
     Bu sorguyu her 30 dk da bir çalıştırmak istiyoru SQL JOB ile çok kolay.
     
     SQL SERVER 2008'de
     SQL Server Agent'in çalış çalışmadığını kontrol et.
     Çalışıyorsa sağtıkla --> START --> +'ya tıkla -->Jobs'a sağ tıkla --> NEW JOB -->kutuya mantıklı bir isim ver. --> Enable'ı seç ve Owner, Category ve Description alanlarını doldur.
     8. Steps alanındaki New'e tıkla -->New Job Step kuutusuna bir isim ver --> Tür olarak Transact-SQL Script'i seç. --> Veri tabanını seç -->Command alanına komutu yapıştır
     13. New Job kutusunda --> Schedules seç ve New'e tıkla --> New Job Schedule'a bir isim ver -->Schedule türü olarak Recurring'i seç -->Frequency, altındaki Occurs'u Daily olarak ayarla ve Recurs every 1 gün olarak ayarla
     17. Daily Frequency altındaki, Occurs every'i 30 dk ya ayarla --> Son olarak Duration altındaki schedule start ve end dates'i doldur.

	 Bu JOB her 30 dk da bir çalışacak ve 24 saatten daha fazka kilitlenen hesapları açacak.
    */
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            AuthenticateUser(txtUserName.Text, txtPassword.Text);
        }
        private void AuthenticateUser(string username, string password)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                string encryptedpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

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
                    }
                }
            }
        }
    }
}