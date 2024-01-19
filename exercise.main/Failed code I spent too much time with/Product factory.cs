/*
public abstract class ProductFAIL
{
	private string _sku;
	public string SKU { get { return _sku; } set { _sku = value; } }

	private string _name;
	public string Name { get { return _name; } set { _name = value; } }

	private double _price;
	public double Price { get { return _price; } set { _price = value; } }

	private string _variant;
	public string Variant { get { return _variant; } set { _variant = value; } }

	public virtual double CheckPriceOfProduct()
	{
		throw new NotImplementedException();
	}

	public static ProductFAIL CreateProduct(string sKU)
	{
		sKU = sKU.ToUpper();

		List<Tuple<string, double, string, string>> skuList = new List<Tuple<string, double, string, string>>
			{
				new Tuple<string, double, string, string>("BGLO", 0.49,  "Bagel",   "Onion"         ),
				new Tuple<string, double, string, string>("BGLP", 0.39,  "Bagel",   "Plain"         ),
				new Tuple<string, double, string, string>("BGLE", 0.49,  "Bagel",   "Everything"    ),
				new Tuple<string, double, string, string>("BGLS", 0.49,  "Bagel",   "Sesame"        ),
				new Tuple<string, double, string, string>("COFB", 0.99,  "Coffee",  "Black"         ),
				new Tuple<string, double, string, string>("COFW", 1.19,  "Coffee",  "White"         ),
				new Tuple<string, double, string, string>("COFC", 1.29,  "Coffee",  "Capuccino"     ),
				new Tuple<string, double, string, string>("COFL", 1.29,  "Coffee",  "Latte"         ),
				new Tuple<string, double, string, string>("FILB", 0.12,  "Filling", "Bacon"         ),
				new Tuple<string, double, string, string>("FILE", 0.12,  "Filling", "Egg"           ),
				new Tuple<string, double, string, string>("FILC", 0.12,  "Filling", "Cheese"        ),
				new Tuple<string, double, string, string>("FILX", 0.12,  "Filling", "Cream Cheese"  ),
				new Tuple<string, double, string, string>("FILS", 0.12,  "Filling", "Smoked Salmon" ),
				new Tuple<string, double, string, string>("FILH", 0.12,  "Filling", "Ham"           )

			};

		if (skuList.Any(t => t.Item1 == sKU))
		{
			string name = skuList.First(t => t.Item1 == sKU).Item3;
			double price = skuList.First(t => t.Item1 == sKU).Item2;
			string variant = skuList.First(t => t.Item1 == sKU).Item4;

			if (name == "Bagel")
			{
				return new Bagel(sKU, name, price, variant);
			}
			else if (name == "Coffee")
			{
				return new Coffee(sKU, name, price, variant);
			}
			else if (name == "Filling")
			{
				return new Filling(sKU, name, price, variant);
			}
			else
			{
				throw new ArgumentException("Invalid product type");
			}
		}
		else
		{
			throw new ArgumentException("Invalid product type");
		}

	}
}


public class Bagel : Product
{
    private Filling _filling;
    public Filling Filling { get { return _filling; } set { _filling = value; } }

    public Bagel(string sKU) : base(sKU)
    {

    }

    public virtual double CheckPriceOfProduct()
    {
        return Filling != null ? (Price + Filling.Price) : Price;
    }
}
*/


//This should work, but I wasn't comfortable using it.
//ProductFAIL bagel = ProductFAIL.CreateProduct("BGLO");
//Bagel bagelInstance = bagel as Bagel;

