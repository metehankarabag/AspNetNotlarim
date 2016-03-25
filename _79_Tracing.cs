using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _79_Tracing
{
    /*TRACING
      Açılan sayfalarla ilgili bilgileri gösterir.
      bir sayfa açtıktan sonra trace.axd'i yenilersek o sayfa ile ilgili bilgileri görürürüz.       
      Tracing açılabilir veya kapatilabilir.
      1. APPLICATION düzeyinde 
      2. PAGE düzeyinde
      
      APPLICATION düzeyinde TRACING açmak için WEB.CONFIG'de <trace enabled="true"/>
      Özel sayfalar için TRACING kapatmak için
      <%@ Page Language="C#" Trace="false" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>
      
      APPLICATION düzeyinde izleme açıksa, TRACE.AXD olarak adlandırılan bir dosyada izleme mesajları yazılır.
      TRACE.AXD dosyası sadece yerelden erişilebilir.
      Uzak kullanıcılardada izlemenin mümkün olabilmesi için LOCALONLY'yi FALSE olarak ayarla
      TRACE SERVER'e giren hackerlar için kullanışlıdır. Sadece gerektiğinde FALSE yap.
      <trace enabled="true" localOnly="false"/>

      TRACE mesajlarını sayfanın sonuna eklemek için PAGEOUTPUT'u TRUE olarak ayarla.
      <trace enabled="true" pageOutput="true" localOnly="false" />
      SERVER'da tutulan isteklerin TRACE sayısını kontrol etmek için <trace enabled="true" pageOutput="true" requestLimit="5" localOnly="false"/>
      Varsayılanı 10 dur. Bu limit e ulaşıldığıktan sonra sunucu TRACE dosyasına yazmayı durduracak.

      REQUESTLIMIT dolduktan sonra izleme mesajlarını eklemek istiyorsan, MOSTRECENT özelliğini TRUE olarak ayarla. 
      Bu özellik TREU olarak ayarlandığında TRACE'deki eski girişler atılır ve yeni girişler eklenir.
      <trace enabled="true" mostRecent="true" requestLimit="3"/>

     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            // DataSet is in System.Data namespace
            DataSet ds = new DataSet();
            // This line will throw an exception, as Data.xml 
            // file is not present in the project
            ds.ReadXml(Server.MapPath("~/Countries.xml"));
            GridView1.DataSource = ds;
            GridView1.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    Logger.Log(ex);
            //    Server.Transfer("~/Errors.aspx");
            //}
        }
    }
}