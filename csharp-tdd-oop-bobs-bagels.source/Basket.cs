using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_tdd_oop_bobs_bagels.source
{
    public class Basket
    {
        private int maxCapacity = 5;
        public void SeedData()
        {
            this.AvailableProducts.Add(new Product() { Sku = "BGLO", Price = 0.49M, Name = "Bagel", Variant = "Onion" });
            this.AvailableProducts.Add(new Product() { Sku = "BGLP", Price = 0.39M, Name = "Bagel", Variant = "Plain" });
            this.AvailableProducts.Add(new Product() { Sku = "BGLE", Price = 0.49M, Name = "Bagel", Variant = "Everything" });
            this.AvailableProducts.Add(new Product() { Sku = "BGLS", Price = 0.49M, Name = "Bagel", Variant = "Sesame" });
            this.AvailableProducts.Add(new Product() { Sku = "COFB", Price = 0.99M, Name = "Coffee", Variant = "Black" });
            this.AvailableProducts.Add(new Product() { Sku = "COFW", Price = 1.19M, Name = "Coffee", Variant = "White" });
            this.AvailableProducts.Add(new Product() { Sku = "COFC", Price = 1.29M, Name = "Coffee", Variant = "Capuccino" });
            this.AvailableProducts.Add(new Product() { Sku = "COFL", Price = 1.29M, Name = "Coffee", Variant = "Latte" });
            this.AvailableProducts.Add(new Product() { Sku = "FILB", Price = 0.12M, Name = "Filling", Variant = "Bacon" });
            this.AvailableProducts.Add(new Product() { Sku = "FILE", Price = 0.12M, Name = "Filling", Variant = "Egg" });
            this.AvailableProducts.Add(new Product() { Sku = "FILC", Price = 0.12M, Name = "Filling", Variant = "Cheese" });
            this.AvailableProducts.Add(new Product() { Sku = "FILX", Price = 0.12M, Name = "Filling", Variant = "Cream Cheese" });
            this.AvailableProducts.Add(new Product() { Sku = "FILS", Price = 0.12M, Name = "Filling", Variant = "Smoked Salmon" });
            this.AvailableProducts.Add(new Product() { Sku = "FILH", Price = 0.12M, Name = "Filling", Variant = "Ham" });
        }

        private string roleOfAUser(User user)
        {

            if (user.Role.Equals("Customer"))
            {
                return user.Role;
            }
            if (user.Role.Equals("Manager"))
            {
                return user.Role;
            }
            return "";
        }

        private bool addProduct(User user, Product product, string role)
        {
            if (role.Equals("Customer"))
            {
                if (user.Products.Count < BasketsCapacity)
                {
                    foreach (Product item in AvailableProducts)
                    {
                        if (product.Sku == item.Sku)
                        {
                            user.Products.Add(product);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool removeProduct(User user, Product product, string role)
        {
            if (role.Equals("Customer"))
            {
                var productToRemove = user.Products.FirstOrDefault(item => item.Sku == product.Sku);
                if (productToRemove != null)
                {
                    user.Products.Remove(productToRemove);
                    return true;
                }
            }
            return false;
        }

        private decimal calculateTotalCost(User user, string role)
        {
            decimal totalPrice = 0M;
            if (role.Equals("Customer"))
            {
                foreach (var product in user.Products)
                {
                    totalPrice += product.Price;
                }
            }
            return totalPrice;
        }
        
        private decimal productCost(string sku, string role)
        {
            if (role.Equals("Customer"))
            {
                foreach (var product in AvailableProducts)
                {
                    if (product.Sku.Equals(sku))
                    {
                        return product.Price;
                    }
                }
            }
            return 0M;
        }

        private decimal fillingCost(string filling, string role)
        {
            if (role.Equals("Customer"))
            {
                foreach (var product in AvailableProducts)
                {
                    if (product.Variant.Equals(filling))
                    {
                        return product.Price;
                    }
                }
            }
            return 0M;
        }

        private void addFilling(User user, string sku, string filling, string role)
        {
            if (role.Equals("Customer"))
            {
                foreach (var product in user.Products)
                {
                    if (product.Sku.Equals(sku))
                    {
                        foreach (var item in AvailableProducts)
                        {
                            if (item.Variant.Equals(filling))
                            {
                                product.Price += item.Price;
                            }
                        }
                    }
                }
            }
        }

        public bool AddProduct(User user, Product product)
        {
            string role = roleOfAUser(user);
            return addProduct(user, product, role);
        }


        public bool RemoveProduct(User user, Product product)
        {
            string role = roleOfAUser(user);
            return removeProduct(user, product, role);
        }

        public bool ChangeBasketsCapacity(User user, int newCapacity)
        {
            if (user.Role.Equals("Manager"))
            {
                maxCapacity = newCapacity;
                return true;
            }
            return false;
        }

        public decimal CalculateTotalCost(User user)
        {
            string role = roleOfAUser(user);
            return calculateTotalCost(user, role);
        }

        public decimal ProductCost(User user, string sku)
        {
            string role = roleOfAUser(user);
            return productCost(sku, role);
        }

        public decimal FillingCost(User user, string filling)
        {
            string role = roleOfAUser(user);
            return fillingCost(filling, role);
        }

        public void AddFilling(User user, string sku, string filling)
        {
            string role = roleOfAUser(user);
            addFilling(user, sku, filling, role);
        }

        public int BasketsCapacity { get => maxCapacity; }
        public List<Product> AvailableProducts { get; set; } = new List<Product>();
    }
}
