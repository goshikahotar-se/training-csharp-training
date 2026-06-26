namespace csharp.Challenges._09_product_lookup_nullable;

public class ProductLookupNullable
{
    public static void Run()
    {
        Console.WriteLine("Testing ProductLookupNullable");

        Dictionary<string, Product> productItems = new Dictionary<string, Product>();

        Product item1 = new Product { Code = "PEN", Name = "Pen", Price = 10 };
        Product item2 = new Product { Code = "BOOK", Name = "Notebook", Price = 50 };
        Product item3 = new Product { Code = "BAG", Name = "Bag", Price = 150 };
        
        AddProductItemsToDictionary(productItems, item1, item2, item3);

        bool breakLoop = false;

        while (true)
        {
            string input;
            do
            {
                input = RequestInputFromUser();

                if (CatchDecisionExitingTheProgram(input, ref breakLoop)) break;

                if (!string.IsNullOrEmpty(input))
                {
                    Product? result = FindProductByCode(productItems, input);
                    if (result != null)
                    {
                        Console.WriteLine("present: " + result.Name + ", Price: " + result.Price);
                    }
                    else
                    {
                        Console.WriteLine("Product not found!");
                    }
                }
                    
            } while (string.IsNullOrEmpty(input));

            if (breakLoop)
                break;
        }
    }

    private static void AddProductItemsToDictionary(Dictionary<string, Product> productItems, Product item1, Product item2, Product item3)
    {
        productItems.Add(item1.Code, item1);
        productItems.Add(item2.Code, item2);
        productItems.Add(item3.Code, item3);
    }

    private static Product? FindProductByCode(Dictionary<string, Product> productItems, string code)
    {
        if (productItems.TryGetValue(code, out Product? item))
        {
            return item;
        }

        return null;
    }

    private static bool CatchDecisionExitingTheProgram(string? input, ref bool breakLoop)
    {
        if (input == "exit")
        {
            breakLoop = true;
            return true;
        }

        return false;
    }

    private static string? RequestInputFromUser()
    {
        string? input;
        Console.WriteLine("Please enter valid product code (else 'exit' to close app)): ");
        input = Console.ReadLine();
        return input;
    }
}