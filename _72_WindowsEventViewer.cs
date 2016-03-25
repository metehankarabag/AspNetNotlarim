using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _72_WindowsEventViewer
{
    /*WINDOWS EVENT VIEWER

     ASP.NET WEB APPLICATION'larda EXCEPTIONS EVENT VIEWER girilebilir. 
     İlk olarak EVENT VIEWER ve CUSTOM EVENT LOG tartışalım oluşturma ve EVENT SOURCE hakkında tartışalım.

     EVENT VIEWER'a bağlanma

     Çalıştırı aç. -->eventvwr 

     Windows girişleri altında, görmen gerekenler

     1. APPLICATION - MS Office,SQL Server, Visual Studio gibi uygulamalardan bilgileri girer.
     2. SECURİTY - Oturum açma bağlantıları kontrol etme gibi güvenlik'le ilgili bilgileri girer.
     3. SYSTEM - Sistem servis hataları gibi sürüyle ilgili biglileri girer.

     Artık CUSTOM WINDOWS EVENT LOG ve EVENT SOURCE oluşturmak için kullanılabilecek bir WINDOWS APPLICATION oluşturalım. 
     EVENT SOURCE olayların girileceği uygulamanın adıdır. 
     EVENT VIEWER'da bir olay seçildiğinde, EVENT SOURCE detaylar bölmesinde gösterilir. 

     CUSTOM WINDOWS EVENT SOURCE ve EVENT LOG oluşturmak için WINDOWS APPLICATION oluşturacak adımlar

	 1. WINDOWS FORM'u sürükle ve bırak 2 TEXTBOX, LABEL ve bir BUTTON
     2. Kontrolleri düzenle, yani asağıdaki gibi görünsün
     3. EVENT VIEWER'ı oluşturmak için BUTTON'a çift tıkla.
     4. BUTT_CLICK EVENT'ına aşağıdaki kodları kopyala
	 5. Uygulamayı çalıştır
     6. Olay girişi için isim ve kaynak gir.
     7. Create Event Log and Event Source Button'a tıkla.

     Olay görüntüleyiciyi aç. Yeni oluşturulan "EVENT LOG" APPLICATIONS AND SERVICE LOGS altında olmalı. Onları yerleştiremiyorsan, makineni yeniden başlat.

     Ayarlı olay girişini silmek için Delete() method unu kullan 
     System.Diagnostics.EventLog.Delete("EventLogNameToDelete")  --> Bu isim altında 

*/
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateEventLogButton_Click(object sender, EventArgs e)
        {
            if (EventLogNameTextBox.Text != string.Empty && EventLogSourceTextBox.Text != string.Empty)
            {
                System.Diagnostics.EventLog.CreateEventSource
                    (EventLogSourceTextBox.Text, EventLogNameTextBox.Text);
                MessageBox.Show("Event Log and Source Created");
            }
            else
            {
                MessageBox.Show("Event Log and Source are required");
            }
        }        
    }
}
