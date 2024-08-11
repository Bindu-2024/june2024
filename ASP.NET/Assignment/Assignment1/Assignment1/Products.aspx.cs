using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class Products : System.Web.UI.Page
    {
        Dictionary<string, (string ImageUrl, decimal Price)> products = new Dictionary<string, (string, decimal)>
        {
            {"Handbags",("~/images/Handbags.jpg", 2000m) },
            {"Softtoys",("~/images/Softtoys.jpg", 300m) },
            {"Cosmetics",("~/images/Cosmetics.jpg", 5000m) }
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (var product in products.Keys)
                {
                    ddlProducts.Items.Add(product);
                }
            }

        }
        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = ddlProducts.SelectedItem.Text;
            if (products.ContainsKey(selectedProduct))
            {
                imgProduct.ImageUrl = products[selectedProduct].ImageUrl;
            }
        }
        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selectedProduct = ddlProducts.SelectedItem.Text;
            if (products.ContainsKey(selectedProduct))
            {
                lblPrice.Text = "Price $" + products[selectedProduct].Price.ToString();
            }
        }
    }
}