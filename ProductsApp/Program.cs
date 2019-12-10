using System;

namespace ProductsApp
{

    partial class Program
    {
        static void Main(string[] args)
        {

           
      
            var products = new ProductsCollection();
            var logger = new ProductsLogger();
            //products.Subscribe(logger);
            //products.OnListChange += PrintProducts;

            var pubSubInstance = PubSub.GetInstance();
            pubSubInstance.Subscribe("listChanged", Program.PrintProducts);

            products.Add(new Product { Id = 3, Name = "Pen", Cost = 10, Units = 60, Category = "Stationary" });
            products.Add(new Product { Id = 2, Name = "Ken", Cost = 40, Units = 30, Category = "Stationary" });
            products.Add(new Product { Id = 1, Name = "Ten", Cost = 20, Units = 50, Category = "Utencil" });
            products.Add(new Product { Id = 5, Name = "Den", Cost = 80, Units = 10, Category = "Stationary" });
            products.Add(new Product { Id = 4, Name = "Zen", Cost = 60, Units = 40, Category = "Utencil" });

            var book1 = new Book { BookId = 9, Title = "Design Patterns", Price = 100, Units = 3 };
            products.Add(new BookProduct(book1));

            /*
            for (int index = 0, count = products.Count; index < count; index++)
            {
                Console.WriteLine(products.GetByIndex(index));
            }
            */
            /*
            while (products.MoveNext())
            {
                var product = (Product)products.Current;
                Console.WriteLine(product);
            }
            */
            //Console.WriteLine("Default List");
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product);
            //}

            Console.WriteLine("After Default Sort [By Id]");
            //products.Sort(new ProductComparerById());
            products.Sort(ProductComparerFactory.Create(ProductComparerEnum.Id));
            

            Console.WriteLine("Sort by Name");
            products.Sort(new ProductComparerByName());
            
            Console.WriteLine("Sort by Units");
            products.Sort(new ProductComparerByUnits());
            

            Console.WriteLine("Sort by Cost");
            /*
            products.Sort(new CompareProductDelegate(Program.CompareProductByCost));
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            */

            /*
            products.Sort(delegate (Product p1, Product p2)
            {
                if (p1.Cost < p2.Cost) return -1;
                if (p1.Cost > p2.Cost) return 1;
                return 0;
            });
            */
            products.Sort( ( p1,  p2) =>
            {
                if (p1.Cost < p2.Cost) return -1;
                if (p1.Cost > p2.Cost) return 1;
                return 0;
            });
            

            Console.WriteLine("Costly Products [cost >= 40]");
            var costlyProducts = products.Filter(new CostProductSpecification(40));
            foreach (var product in costlyProducts)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("Stationary Product");
            var stationaryProducts = products.Filter(new CategoryProductSpecification("Stationary"));
            foreach (var product in stationaryProducts)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("Costly Or Stationary Product");
            var combinedProductSpecification = new OrSpecification(new CostProductSpecification(40), new CategoryProductSpecification("Stationary"));
            var combinedProductFilterResult = products.Filter(combinedProductSpecification);
            foreach (var product in combinedProductFilterResult)
            {
                Console.WriteLine(product);
            }

            Console.ReadLine();
        }

        public static int CompareProductByCost(IProduct p1, IProduct p2)
        {
            if (p1.Cost < p2.Cost) return -1;
            if (p1.Cost > p2.Cost) return 1;
            return 0;
        }

        public static void PrintProducts()
        {
            //Console.WriteLine("The current product list is :");
            //foreach (var product in data)
            //{
            //    Console.WriteLine(product);
            //}

            Console.WriteLine("The product list changed");
        }
    }

    public delegate int CompareProductDelegate(IProduct p1, IProduct p2);
}


