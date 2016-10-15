using System;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI;
using WingtipToys.Models;

namespace WingtipToys
{
    public partial class ProductDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProduct([QueryString("productID")] int? productId)
        {
            var dbContext = new ProductContext();
            IQueryable<Product> query = dbContext.Products;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductID == productId);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}