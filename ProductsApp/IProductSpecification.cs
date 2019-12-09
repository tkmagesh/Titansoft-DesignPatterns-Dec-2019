namespace ProductsApp
{
    public interface IProductSpecification
    {
        bool isSatisfiedBy(IProduct product);
    }
}
