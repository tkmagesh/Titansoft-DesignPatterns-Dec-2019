using System;
using System.Collections;
using System.Collections.Generic;

namespace ProductsApp
{
    public class ProductsCollection : IEnumerable
    {
        private ArrayList _list = new ArrayList();

        //private IList<IObserver<ProductsCollection>> _observers = new List<IObserver<ProductsCollection>>();

        public delegate void OnListChangeDelegate(ProductsCollection productsCollection);

        public OnListChangeDelegate OnListChange;

        private void NotifyObservers()
        {
            this.OnListChange?.Invoke(this);
        }

        
        public void Add(IProduct product)
        {
            this._list.Add(product);
            this.NotifyObservers();
        }

        public int Count
        {
            get
            {
                return this._list.Count;
            }
        }



        public IProduct GetByIndex(int index)
        {
            return (IProduct)_list[index];
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
                    var p1 = (IProduct)this._list[i];
                    var p2 = (IProduct)this._list[j];
                    var compareResult = comparer.Compare(p1, p2);
                    if (compareResult > 0)
                    {
                        var temp = this._list[i];
                        this._list[i] = this._list[j];
                        this._list[j] = temp;
                    }
               
                }
            }
            this.NotifyObservers();
        }

        public void Sort(CompareProductDelegate compareProduct)
        {
            for (int i = 0; i < this._list.Count - 1; i++)
            {
                for (int j = i + 1; j < this._list.Count; j++)
                {
                    var p1 = (IProduct)this._list[i];
                    var p2 = (IProduct)this._list[j];
                    var compareResult = compareProduct(p1, p2);
                    if (compareResult > 0)
                    {
                        var temp = this._list[i];
                        this._list[i] = this._list[j];
                        this._list[j] = temp;
                    }

                }
            }
            this.NotifyObservers();
        }

        public ProductsCollection FilterCostlyProducts()
        {
            var result = new ProductsCollection();
            for (int i = 0; i < this._list.Count; i++)
            {
                var product = (IProduct)this._list[i];
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
                var product = (IProduct)this._list[i];
                if (specification.isSatisfiedBy(product))
                {
                    result.Add(product);
                }
            }
            return result;
        }

    }
}
