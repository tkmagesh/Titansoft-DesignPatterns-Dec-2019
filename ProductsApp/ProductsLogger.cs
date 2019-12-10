using System;

namespace ProductsApp
{
    public class ProductsLogger : IObserver<ProductsCollection>{
        public void Update(ProductsCollection data)
        {
            Console.WriteLine("The current product list is :");
            foreach (var product in data)
            {
                Console.WriteLine(product);
            }
        }
    }
}


