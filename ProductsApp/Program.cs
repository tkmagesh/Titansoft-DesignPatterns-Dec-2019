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
            Console.WriteLine("Default List");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("After Default Sort [By Id]");
            products.Sort(new ProductComparerById());
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("Sort by Name");
            products.Sort(new ProductComparerByName());
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("Sort by Units");
            products.Sort(new ProductComparerByUnits());
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

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
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

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

        public enum ProductComparerEnum
        {
            Id,
            Units,
            Name
        }
        public class ProductComparerFactory
        {
            public static IProductComparer Create(ProductComparerEnum comparerEnum)
            {
                switch (comparerEnum)
                {
                    case ProductComparerEnum.Id:
                        return new ProductComparerById()
                        break;
                    case ProductComparerEnum.Units:
                        return new ProductComparerByUnits();
                        break;
                    case ProductComparerEnum.Name:
                        return new ProductComparerByName();
                        break;
                    default:
                        break;
                }
            }
        }

        public static int CompareProductByCost(Product p1, Product p2)
        {
            if (p1.Cost < p2.Cost) return -1;
            if (p1.Cost > p2.Cost) return 1;
            return 0;
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

        public void Sort(IProductComparer comparer)
        {
            for (int i = 0; i < this._list.Count - 1; i++)
            {
                for (int j = i + 1; j < this._list.Count; j++)
                {
                    var p1 = (Product)this._list[i];
                    var p2 = (Product)this._list[j];
                    var compareResult = comparer.Compare(p1, p2);
                    if (compareResult > 0)
                    {
                        var temp = this._list[i];
                        this._list[i] = this._list[j];
                        this._list[j] = temp;
                    }
               
                }
            }
        }

        public void Sort(CompareProductDelegate compareProduct)
        {
            for (int i = 0; i < this._list.Count - 1; i++)
            {
                for (int j = i + 1; j < this._list.Count; j++)
                {
                    var p1 = (Product)this._list[i];
                    var p2 = (Product)this._list[j];
                    var compareResult = compareProduct(p1, p2);
                    if (compareResult > 0)
                    {
                        var temp = this._list[i];
                        this._list[i] = this._list[j];
                        this._list[j] = temp;
                    }

                }
            }
        }

        public ProductsCollection FilterCostlyProducts()
        {
            var result = new ProductsCollection();
            for (int i = 0; i < this._list.Count; i++)
            {
                var product = (Product)this._list[i];
                if (product.Cost >= 50)
                {
                    result.Add(product);
                }
            }
            return result;
        }

        public ProductsCollection Filter(IProductSpecification specification)
        {
            var result = new ProductsCollection();
            for (int i = 0; i < this._list.Count; i++)
            {
                var product = (Product)this._list[i];
                if (specification.isSatisfiedBy(product))
                {
                    result.Add(product);
                }
            }
            return result;
        }

    }

    public interface IProductSpecification
    {
        bool isSatisfiedBy(Product product);
    }

    public class CostProductSpecification : IProductSpecification
    {
        private readonly decimal cost;

        public CostProductSpecification(decimal cost)
        {
            this.cost = cost;
        }
        public bool isSatisfiedBy(Product product)
        {
            return product.Cost >= this.cost;
        }
    }

    public class CategoryProductSpecification : IProductSpecification
    {
        private readonly string categoryName;

        public CategoryProductSpecification(string categoryName)
        {
            this.categoryName = categoryName;
        }
       
    

        bool IProductSpecification.isSatisfiedBy(Product product)
        {
            return product.Category == this.categoryName;
        }
    }

    public class OrSpecification : IProductSpecification
    {
        private readonly IProductSpecification leftSpecification;
        private readonly IProductSpecification rightSpecification;

        public OrSpecification(IProductSpecification leftSpecification, IProductSpecification rightSpecification)
        {
            this.leftSpecification = leftSpecification;
            this.rightSpecification = rightSpecification;
        }

        public bool isSatisfiedBy(Product product)
        {
            return leftSpecification.isSatisfiedBy(product) || rightSpecification.isSatisfiedBy(product);
        }
    }

    public class AndSpecification : IProductSpecification
    {
        private readonly IProductSpecification leftSpecification;
        private readonly IProductSpecification rightSpecification;

        public AndSpecification(IProductSpecification leftSpecification, IProductSpecification rightSpecification)
        {
            this.leftSpecification = leftSpecification;
            this.rightSpecification = rightSpecification;
        }

        public bool isSatisfiedBy(Product product)
        {
            return leftSpecification.isSatisfiedBy(product) && rightSpecification.isSatisfiedBy(product);
        }
    }

    public interface IProductComparer
    {
        int Compare(Product p1, Product p2);
    }

    public delegate int CompareProductDelegate(Product p1, Product p2);

    public class ProductComparerById : IProductComparer
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Id < p2.Id) return -1;
            if (p1.Id > p2.Id) return 1;
            return 0;
        }
    }

    public class ProductComparerByName : IProductComparer
    {
        public ProductComparerByName()
        {
        }

        public int Compare(Product p1, Product p2)
        {
            return p1.Name.CompareTo(p2.Name);
        }
    }

    public class ProductComparerByUnits : IProductComparer
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Units < p2.Units) return -1;
            if (p1.Units > p2.Units) return 1;
            return 0;
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
