namespace ProductsApp
{
    public class ProductComparerByName : IProductComparer
    {
        public ProductComparerByName()
        {
        }

        public int Compare(IProduct p1, IProduct p2)
        {
            return p1.Name.CompareTo(p2.Name);
        }
    }
}
