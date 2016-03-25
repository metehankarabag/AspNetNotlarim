using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace _74_LogingToTheEventViewerAsInformationEntry
{
    /*

     Bu videoda biz EXCEPTION'ları WINDOWS EVENT VIEWER'daki tüm türe bilgi olarak girme hakkında tartışacağız.
     FormatException, OverflowException, DivideByZeroException  EVENT VIEWER'da tüm türleri Hata yerine tüm türler bilgi olarak girimeli. 
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
            {                                                        //
                Logger.Log(formatException, EventLogEntryType.Information);
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Only numbers are allowed";
            }
            catch (OverflowException overflowException)
            {                                                        //
                Logger.Log(overflowException, EventLogEntryType.Information);
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Numbers must be between " + Int32.MinValue.ToString() + " and " + Int32.MaxValue.ToString();
            }
            catch (DivideByZeroException divideByZeroException)
            {                                                           //
                Logger.Log(divideByZeroException, EventLogEntryType.Information);
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Denominator cannot be ZERO";
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "An unknown problem has occured. Please try later";
            }
        }
    }
}