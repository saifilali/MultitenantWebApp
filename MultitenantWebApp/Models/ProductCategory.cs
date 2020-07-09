using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantWebApp.Data
{
    public class ProductCategory : BaseEntity
    {
        private readonly List<Product> _products = new List<Product>();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public IEnumerable<Product> Products => _products.AsReadOnly();

        public void AddProduct(Product product)
        {
            product.Category = this;

            _products.Add(product);
        }
    }
}
