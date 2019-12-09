namespace ProductsApp
{
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
}
