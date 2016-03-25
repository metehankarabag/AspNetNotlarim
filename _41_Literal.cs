using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _41_Literal
{
    //EnCode: Bu işlem HTML in SCRİPT kodlarını düz yazı gibi okulması için yapılır. ENCODE uygulanmayan TEXT'ler CODE'dur
    /*LITERAL CONTROL
     
     PAGE VIEW SOURCE'de LITERAL hiç bir tag içinde görünmez. LABEL SPAN içinde görünür.
     LITERAL CONTROL'un SYTLE özellikleri ve CSS özelliği yoktur. Bu yüzden yazı kodda girildiğinde STYLE TAG'ları elle yazılır.
     STYLE kollanmayacağımız bir yazı varsa o zaman LITERAL CONTROL kullanırız.
     Varsayılan olarak LABEL VE LITERAL CONTROL'ün text özelliklerine girilen yazılar kondlanmamış yazılardır. Bu yüzden SCRİPT FONKSIYONU girdiğimiz zaman tarayıcı bu FONKSIYONU çalıştırır. Bu tehlikelidir. TEXT'lerin şifrelenmelerini izliyoruz.
     
     LABEL'in TEXT'i düz yazı şeklinde tarayıcıya göstermek için SERVER.HTMLENCODE() methodunu kullanılır.
     LITERAL'in TEXT'i düz yazı şeklinde tarayıcıya göstermek için Mode özelliği kullanılır.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Text = "Label Text";
            //Literal1.Text = "<b><font color=\"Red\">Literal Text</font</b>";
        }
    }
}