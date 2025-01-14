using System;

namespace exercise.main;

public class Discount
{

    public Dictionary<string, int> SKUCount {get; set;} = new Dictionary<string, int>();
    public double Price {get; set;}
    public double originalPrice {get; set;}
    public Discount(Dictionary<string, int> skus, double price, double origPrice)
    {
        SKUCount = skus;
        Price = price;
        originalPrice = origPrice;

    }

    //Empty Discount object
    public Discount()
    {

    }

    public List<string> ToList()
    {
        List<string> SKUList = new List<string>();
        foreach (string sku in SKUCount.Keys)
        {
            for (int i = 0; i < SKUCount[sku]; i++)
            {
                SKUList.Add(sku);
            }
        }
        return SKUList;
    }
}
