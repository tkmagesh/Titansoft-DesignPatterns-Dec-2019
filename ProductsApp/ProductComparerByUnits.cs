namespace ProductsApp
{
    public class ProductComparerByUnits : IProductComparer
    {
        public int Compare(IProduct p1, IProduct p2)
        {
            if (p1.Units < p2.Units) return -1;
            if (p1.Units > p2.Units) return 1;
            return 0;
        }
    }
}
