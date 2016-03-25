using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _15_CommandEventOfButton
{
    /*COMMAND EVENT
    Click even happens before the COMMAND EVENT
    EVENTHANDLER bir kontrolün olayları ile 2 şekilde ilişkilendirilebilir.
    1.Düzenleme zamanında HTML'de
    2.DELEGE kullanarak programla
 
     COMMAND olayı programda oluşturulurken COMMANDEVENTARGS adında bir parametre ister bu parametreye değerler kontrolün HTML kısmından COMMANDNAME ve COMMANDARGUMENT özelikleri ile gelir.
     Bir web formda birden fazla BUTTON kontrolü varsa, ve hangisinin tıklandığını programda belirtmek(determine) istiyorsan, her kontrolün üstteki özellikleri için farklı değerler vererek belirlersin.
 
    COMMAND EVENT birden fazla BUTTON'un CLİCK olayını cevaplayan tek bir olay işleyici methoda sahip olmayı hangisinin tıklandığını belirlemekte mümkün yapar.
    COMMAND EVENT, COMMANDNAME ve COMMANDARGUMENT Repeather,GridView,DataList gibi DATA_BOUND(veri bağlama) kontrolleri ile çalışırken eksra kullanışlıdır. 2 BUTTON kontrolünün hepsi Command olayı, COMMANDNAME ve COMMANDARGUMENT özelliklerini ortaya çıkarır
 */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {// html de silinen attribute'lerin işini yapıyor.
            Button1.Click += new EventHandler(Button1_Click);
            Button1.Command += new CommandEventHandler(Button1_Command);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("Button Click event <br/>");
        }
        // bunların html tarafındaki kodlarını sildik
        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            Response.Write("Button Command event <br/>");
        }
    }
}
