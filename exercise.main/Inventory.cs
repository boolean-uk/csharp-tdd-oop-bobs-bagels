using System.Collections;

namespace exercise.main;

public class Inventory : IInventory, IEnumerable<KeyValuePair<Product, int>>
{
    private Dictionary<Product, int> _products;
    
    public Inventory()
    {
        _products = new Dictionary<Product, int>();
    }
    
    public IEnumerator<KeyValuePair<Product, int>> GetEnumerator()
    {
        return _products.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public void AddProduct(Product product, int quantity)
    {
        _products.Add(product, quantity);
    }
    
    public void RemoveProduct(Product product, int quantity)
    {
        throw new NotImplementedException();
    }
    
    public void SetStock(Product product, int quantity)
    {
        throw new NotImplementedException();
    }
    
    public int GetStock(Product product)
    {
        throw new NotImplementedException();
    }
    
    public Product GetProduct(string sku)
    {
        try
        {
            
            return _products.First(p => p.Key.Sku == sku).Key;
        }
        catch (Exception e)
        {
            throw new Exception("Product not found", e);
        }
    }
}

public interface IInventory
{
    void AddProduct(Product product, int quantity);
    void RemoveProduct(Product product, int quantity);
    void SetStock(Product product, int quantity);
    int GetStock(Product product);
    Product GetProduct(string sku);
}