using System;
using System.Collections;

namespace ProductsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new ProductsCollection();
            products.Add(new Product { Id = 3, Name = "Pen", Cost = 10, Units = 60, Category = "Stationary" });
            products.Add(new Product { Id = 2, Name = "Ken", Cost = 40, Units = 30, Category = "Stationary" });
            products.Add(new Product { Id = 1, Name = "Ten", Cost = 20, Units = 50, Category = "Utencil" });
            products.Add(new Product { Id = 5, Name = "Den", Cost = 80, Units = 10, Category = "Stationary" });
            products.Add(new Product { Id = 4, Name = "Zen", Cost = 60, Units = 40, Category = "Utencil" });
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
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.ReadLine();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Cost { get; set; }
        public int Units { get; set; }

        public string Category { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}", this.Id, this.Name, this.Cost, this.Units, this.Category);
        }
    }

    public class ProductsCollection : IEnumerable
    {
        private ArrayList _list = new ArrayList();

        public void Add(Product product)
        {
            this._list.Add(product);
        }

        public int Count
        {
            get
            {
                return this._list.Count;
            }
        }



        public Product GetByIndex(int index)
        {
            return (Product)_list[index];
        }

       

        public IEnumerator GetEnumerator()
        {
            return new ProductsEnumerator(this._list);
        }
    }

    public class ProductsEnumerator : IEnumerator
    {
        private ArrayList _list;

        public ProductsEnumerator(ArrayList list)
        {
            this._list = list;
        }
        private int index = -1;
        public object Current
        {
            get
            {
                return this._list[this.index];
            }
        }

        public bool MoveNext()
        {
            ++this.index;
            if (this.index >= this._list.Count)
            {
                this.Reset();
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Reset()
        {
            this.index = -1;
        }
    }
}
