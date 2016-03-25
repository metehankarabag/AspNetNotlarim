using System;
using System.Web.UI.WebControls;

namespace _158_BindingMenuControlToWebSitemapFile
{
    /*SITEMAPPATHDATASOURCE COntrol
     .sitemap uzantılı bir dosyamız varsa CONTROL'de bu dosyaya bağlanmak için iç bir şeye ihtiyacımız yok.
     Bu CONTROL ile MENU CONTROL'ün veri tabanı olarak göstermek için DATASOURCEID özelliğini kullanıyoruz.
     
     Bağlantıyı yapıp çalıştırdıktan sonra DummyRoot altında görünüyor asıl nesnelerimiz.
     Bunu düzeltmek için SITEMAPPATHDATASOURCE CONTROL'ünün SOWSTARTINGNODE özelliğini FALSE yap.
     
     */
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetMenuItems();
        }

        /*private void GetMenuItems()
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
        */
        private void Check(MenuItem item)
        {
            if (item.NavigateUrl.Equals(Request.AppRelativeCurrentExecutionFilePath,
                StringComparison.InvariantCultureIgnoreCase))
            {
                item.Selected = true;
            }
            else if (item.ChildItems.Count > 0)
            {
                foreach (MenuItem menuItem in item.ChildItems)
                {
                    Check(menuItem);
                }
            }
        }

        protected void Menu1_PreRender(object sender, EventArgs e)
        {
            foreach (MenuItem item in Menu1.Items)
            {
                Check(item);
            }
        }
        protected void SiteMapPath1_ItemCreated(object sender, SiteMapNodeItemEventArgs e)
        {
            if (e.Item.ItemType == SiteMapNodeItemType.Root || (e.Item.ItemType == SiteMapNodeItemType.PathSeparator && e.Item.ItemIndex == 1))
            {
                e.Item.Visible = false;
            }
        } 
    }
}