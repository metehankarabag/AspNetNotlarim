using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _80_WritingCustomTracingMessages
{
    /*Ayarlı ASP.NET TRACE mesajları yazmak için 
     TRACE.WRITE() ve TRACE.WARN() methodları kullanılabilir. 
     
     Bu iki method arasındaki tek fark, 
     TRACE.WARN() ile yazılan mesajlar kırmızı renkle görünür.
     TRACE.WRITE() ile yazılanlar siyahla görünür.
     
     Aslında bu methodlar arasındaki fark çok ortak bir görüşme sorusudur.

	
     TRECE.ISENABLED izlemenini açık olup olmadığını kontrol etmek için kullanılır.
     Aşağıdaki kod TRACE.WRITE() izleme sadece açıksa çağırılır. 
     TRECE.ISENABLED özelliğini izleme mesajı tamamını yazmak için önce kontrole etmessen, hata almassın.
     Fakat izleme mesajı oluşturmak için herhangi bir türde önemli çalışma yapacaksan o zaman ilk önce IsEnable özelliğini kontrol ederek önleyebilirsin.

     if (Trace.IsEnabled) { Trace.Write("Debugging information"); }

     Clasik ASP ile, hata ayıklama bilgileri için ayarlar sadece RESPONSE.WRİTE() dir. Bununla 2 problem var.

	 1. Gerçek son kullanıcı RESPONSE.WRİTE() kullanarak yazdığın hata ayıklama bilgilerini görebilir. 
     Fakat izleme ile, PAGEOUTPUT özlliği FALSE olarak ayarlanmışa, o zaman izleme mesajları TRACE.AXD'ye yazılır. Son kullanıcı bu izleme bilgilerini göremez.
     2. Uygulama üretime yayılmada önce Tüm RESPONSE.WRİTE() açıklamaları silinmeli. Fakat WEB.CONFİG'de tüm yapman gereken şey izlemeyi kapatmaktır.     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnDivide_Click(object sender, EventArgs e)
        {
            try
            {
                int FirstNumber = Convert.ToInt32(txtFirstNumber.Text);
                int SecondNumber = Convert.ToInt32(txtSecondNumber.Text);

                lblMessage.ForeColor = System.Drawing.Color.Navy;
                int Result = FirstNumber / SecondNumber;
                lblMessage.Text = Result.ToString();
            }
            catch (FormatException formatException)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Only numbers are allowed";
                // Check if tracing is enabled
                if (Trace.IsEnabled)
                {
                    // Write the exception message to the trace log
                    Trace.Write(formatException.Message);
                }
            }
            catch (OverflowException overflowException)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Numbers must be between " + Int32.MinValue.ToString() + " and " + Int32.MaxValue.ToString();
                if (Trace.IsEnabled)
                {
                    Trace.Warn(overflowException.Message);
                }
            }
            catch (DivideByZeroException divideByZeroException)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Denominator cannot be ZERO";
                if (Trace.IsEnabled)
                {
                    Trace.Warn(divideByZeroException.Message);
                }
            }
            catch (Exception exception)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "An unknown problem has occured. Please try later";
                if (Trace.IsEnabled)
                {
                    Trace.Warn(exception.Message);
                }
            }
        }

    }
}