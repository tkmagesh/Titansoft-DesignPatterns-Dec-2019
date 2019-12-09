namespace ProductsApp
{
    public class ProductComparerById : IProductComparer
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Id < p2.Id) return -1;
            if (p1.Id > p2.Id) return 1;
            return 0;
        }
    }
}
