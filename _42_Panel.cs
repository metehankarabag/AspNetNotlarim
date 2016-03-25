using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _42_Panel
{
    /*PANEL CONTROL
     
     Diğer kontrolleri tutmak için kullanılan bir alandır.
     PANEL CONTROL Dinamik olarak webform'a kontrol eklerkende çok kullanışlıdır.
    
     
     
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // When the page first loads, hide all admin and non admin controls
            if (!IsPostBack)
            {
                HideAdminControls();
                HideNonAdminControls();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Admin")
            {
                ShowAdminControls();
                HideNonAdminControls();
            }
            else if (DropDownList1.SelectedValue == "Non-Admin")
            {
                ShowNonAdminControls();
                HideAdminControls();
            }
            else
            {
                HideAdminControls();
                HideNonAdminControls();
            }
        }

        private void HideAdminControls()
        {
            AdminGreeting.Visible = false;
            AdminNameLabel.Visible = false;
            AdminNameTextBox.Visible = false;
            AdminRegionLabel.Visible = false;
            AdminRegionTextBox.Visible = false;
            AdminActionsLabel.Visible = false;
            AdminActionsTextBox.Visible = false;
        }
        private void ShowAdminControls()
        {
            AdminGreeting.Visible = true;
            AdminNameLabel.Visible = true;
            AdminNameTextBox.Visible = true;
            AdminRegionLabel.Visible = true;
            AdminRegionTextBox.Visible = true;
            AdminActionsLabel.Visible = true;
            AdminActionsTextBox.Visible = true;
        }
        private void HideNonAdminControls()
        {
            NonAdminGreeting.Visible = false;
            NonAdminNameLabel.Visible = false;
            NonAdminNameTextBox.Visible = false;
            NonAdminRegionLabel.Visible = false;
            NonAdminRegionTextBox.Visible = false;
            NonAdminCityLabel.Visible = false;
            NonAdminCityTextBox.Visible = false;
        }
        private void ShowNonAdminControls()
        {
            NonAdminGreeting.Visible = true;
            NonAdminNameLabel.Visible = true;
            NonAdminNameTextBox.Visible = true;
            NonAdminRegionLabel.Visible = true;
            NonAdminRegionTextBox.Visible = true;
            NonAdminCityLabel.Visible = true;
            NonAdminCityTextBox.Visible = true;
        }
    }
}