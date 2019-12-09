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
                        return new ProductComparerById();
                        
                    case ProductComparerEnum.Units:
                        return new ProductComparerByUnits();
                        

                    case ProductComparerEnum.Name:
                        return new ProductComparerByName();
                        
                    default:
                        return new ProductComparerById();
                }
            }
        }
    }
}
