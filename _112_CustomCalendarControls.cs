using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _112_CustomCalendarControls
{
    /*
     Bu video da COMPOSITE CUSTOM CONTROLS hakkında tartışacağız. 
     USER CONTROL'lerin aksine COMPOSITE CUSTOM tamamen kod ile oluşturulur. 
    
     1. Vs'yi aç > File > New Project >WEB > ASP.NET Server Control project >isim ver >tamamla

     Solution explorer'da ServerControl1.cs dosyasının adını CustomCalendar.cs olarak yeniden adlandır.
     
     Farklı seviyelerde ATRIBUTE'lar kullanarak, CONTROL'ün VS ayarlarını yapacağız.
     
     CONTROL'ü oluşturacağımız CLASS için 2 ATTRIBUTE belitreceğiz.
     ToolboxBitmap: CONTROL'ün TOOL BOX'da hangi resimle gösterileceğini belirliyor.
        CONSTRUCTER'ine herhangi biri CONTROL'ün TYPE'ını verirsek, TYPE'in varsayılan resmi alınır.
        Kullanmayı istediğimiz resmin yolunuda belirtebiliriz.
     ToolboxData: CONSTRUCTER'ında CONTROL'ün yazım şeklini belirliyoruz.
     
     CONTROL2'ün tüm özelliklerini PROPERTIES penceresine eklemek için 2 ATTRIBUTE kullanacağız.
     Category: CONSTRUCTER'ine PROPERTY'in görüneceği sekmeyi gireceğiz.
     Description: PROPERTIES penceresinin en altında görünecek açıklama metnini gireceğiz
     
     Oluşturduğumuz PROPSERTY'lere değer alırken ve verirken, CONTROL CLASS'ın EnsureChildControls() methodunu kullanıyoruz.
     Bu method kullanımdaki CONTROL'ün CHILD CONTROL'leri varmı yokmu belirliyor. Yoksa, CreateChildControls() methodunu çalıştırıyor.
     Bu methodun üzeriye yazarak istediğimiz CONTROL'leri CHILD CONTROL olarak oluşturuyoruz.
     Sonra oluşturulan CONTROL'lerden birine belirtiğimiz özelliği ekliyoruz.
     
     RecreateChildControls(): Düzenleme zamanındaki değişikliklerin hemen yansıması için kullanılıyor. Yani her değişiklik sonrasında çalışır.
     CHILD CONTROL'lerin oluşturulup oluşturulmadığını kontrol ediyoruz.
     Her seferinde CONTROL'leri tekrar oluşturduğumuz için bir önceki CONTROL'leri silmeliyiz.
     
     */
    [ToolboxBitmap(typeof(Calendar))]

    [ToolboxData("<{0}:CustomCalendar runat=server></{0}:CustomCalendar>")]
    public class CustomCalendar : CompositeControl
    {

        TextBox textBox;
        ImageButton imageButton;
        Calendar calendar;

        [Category("Appearance")]
        [Description("Sets the image icon for the calendar control")]
        public string ImageButtonImageUrl
        {
            get { EnsureChildControls(); return imageButton.ImageUrl != null ? imageButton.ImageUrl : string.Empty; }
            set { EnsureChildControls(); imageButton.ImageUrl = value; }
        }
        [Category("Appearance")]
        [Description("Gets or sets the selected date of custom calendar control")]
        public DateTime SelectedDate
        {
            get { EnsureChildControls(); return string.IsNullOrEmpty(textBox.Text) ? DateTime.MinValue : Convert.ToDateTime(textBox.Text); }

            set
            {
                if (value != null) { EnsureChildControls(); textBox.Text = value.ToShortDateString(); calendar.VisibleDate = value; }
                else               { EnsureChildControls(); textBox.Text = ""; calendar.VisibleDate = DateTime.Today; }
            }
        }
        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }
        protected override void CreateChildControls()
        {
            Controls.Clear();

            textBox = new TextBox();
            textBox.ID = "dateTextBox";
            textBox.Width = Unit.Pixel(80);

            imageButton = new ImageButton();
            imageButton.ID = "calendarImageButton";
            imageButton.Click += new ImageClickEventHandler(imageButton_Click);

            calendar = new Calendar();
            calendar.ID = "calendarControl";
            calendar.Visible = false;
            calendar.SelectionChanged += new EventHandler(calendar_SelectionChanged);

            this.Controls.Add(textBox);
            this.Controls.Add(imageButton);
            this.Controls.Add(calendar);
        }


        void calendar_SelectionChanged(object sender, EventArgs e)
        {
            textBox.Text = calendar.SelectedDate.ToShortDateString();
            DateSelectedEventArgs eventData = new DateSelectedEventArgs(calendar.SelectedDate);
            OnDateSelection(eventData);
            calendar.Visible = false;
        }
        void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (calendar.Visible) calendar.Visible = false;
            else
            {
                calendar.Visible = true;
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    calendar.VisibleDate = DateTime.Today;
                }
                else
                {
                    DateTime output = DateTime.Today;
                    bool isDateTimeConverionSuccessful = DateTime.TryParse(textBox.Text, out output);
                    calendar.VisibleDate = output;
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {// Bu method içine eklenen nesneler DESIGN'de görünüyor. CONTROL'leri eklediğimizde onlarla ilgili olan her şeyide eklemiş oluyoruz.
            AddAttributesToRender(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "1");

            writer.RenderBeginTag(HtmlTextWriterTag.Table);

            writer.RenderBeginTag(HtmlTextWriterTag.Tr);

            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            textBox.RenderControl(writer);
            writer.RenderEndTag();

            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            imageButton.RenderControl(writer);
            writer.RenderEndTag();

            writer.RenderEndTag();
            writer.RenderEndTag();

            calendar.RenderControl(writer);
        }
        public event DateSelectedEventHandler DateSelected;
        protected virtual void OnDateSelection(DateSelectedEventArgs e) { if (DateSelected != null) DateSelected(this, e); }
    }
    /*Part116*/
    public class DateSelectedEventArgs : EventArgs
    {
        private DateTime _selectedDate;
        public DateSelectedEventArgs(DateTime selectedDate) { this._selectedDate = selectedDate; }
        public DateTime SelectedDate { get { return this._selectedDate; } }
    }
    public delegate void DateSelectedEventHandler(object sender, DateSelectedEventArgs e);
}
