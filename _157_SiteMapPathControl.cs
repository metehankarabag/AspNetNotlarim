using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace _157_SiteMapPathControl
{
    /*SITEMAPPATH CONTROL
     1. kontrolü ekle
     2. SITEMAP uzantılı sayfayı ekle
     
     Bu sayfaya linkler ve başlıklarını içeren yazılar eklecek şekilde bir düzen oluşturacağız.
     SITEMAP uzantılı dosya aslında bir XML dosyasıdır.
     XML açıklamasının hemen altında
     SITEMAP nesnesi bulunur. SITEMAP'ın hemen altında 
     SITEMAPNODE'nesnesi bulunur. Bu nesne hieraşiyi oluşturmak ve hieraşiye nesne eklemek için kullanılır..
     Yani bir level aşağıya inmek için kullanılır.
     
     Bir level aşağıya inmek için --> <siteMapNode title="" ...></siteMapNode> şeklinde yazılır.
     Düzeye nesne eklemek için --> <siteMapNode title="" .../> şeklinde yazılır.
     
     Hata mesajında SITEMAP'ın içinde direk olarak sadece bir tane siteMapNode nesnesi olur yazıyor.
     
     SiteMapPath1_ItemCreated olay işleyicisinde yapılan ROOT'daki yazıyı ve index'i 1 olan nodd için > işaretini silmek
     */
    /*Özellikleri
     CurrentNodeStyle
     RootNodeStyle 
     düzeyler için özellikleri belirtir.
     
     PathSeparator: Node'lar arası geçiş simgesini belirtir.
     PathDirection: Hieraşiyi ters çevirmek için kullanılır.
     ParentLevelDisplayed: Bir levelin kaç alt leveli görüneceğini belirler. 
     0 yapılırsa ilk levelin alt leveli görünmez. -1 tüm levelleri göster demek.
     
     */
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e) { GetMenuItems(); }

        private void GetMenuItems()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("spGetMenuData", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);

            ds.Relations.Add("ChildRows", ds.Tables[0].Columns["ID"], ds.Tables[1].Columns["ParentId"]);

            foreach (DataRow level1DataRow in ds.Tables[0].Rows)
            {
                MenuItem item = new MenuItem();
                item.Text = level1DataRow["MenuText"].ToString();
                item.NavigateUrl = level1DataRow["NavigateURL"].ToString();

                DataRow[] level2DataRows = level1DataRow.GetChildRows("ChildRows");
                foreach (DataRow level2DataRow in level2DataRows)
                {
                    MenuItem childItem = new MenuItem();
                    childItem.Text = level2DataRow["MenuText"].ToString();
                    childItem.NavigateUrl = level2DataRow["NavigateURL"].ToString();
                    item.ChildItems.Add(childItem);
                }
                Menu1.Items.Add(item);
            }
        }
        private void Check(MenuItem i)
        {
            if (i.NavigateUrl.Equals(Request.AppRelativeCurrentExecutionFilePath, StringComparison.InvariantCultureIgnoreCase)) i.Selected = true;
            else if (i.ChildItems.Count > 0) { foreach (MenuItem menuItem in i.ChildItems) { Check(menuItem); } }
        }

        protected void Menu1_PreRender(object sender, EventArgs e) { foreach (MenuItem item in Menu1.Items) { Check(item); } }
        protected void SiteMapPath1_ItemCreated(object sender, SiteMapNodeItemEventArgs e)
        {
            if (e.Item.ItemType == SiteMapNodeItemType.Root || (e.Item.ItemType == SiteMapNodeItemType.PathSeparator && e.Item.ItemIndex == 1))
                e.Item.Visible = false;

        }
    }
}