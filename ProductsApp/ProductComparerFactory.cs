namespace ProductsApp
{
    partial class Program
    {
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
    }
}
