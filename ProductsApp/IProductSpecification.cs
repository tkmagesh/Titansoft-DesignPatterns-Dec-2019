namespace ProductsApp
{
    public interface IProductSpecification
    {
        bool isSatisfiedBy(Product product);
    }
}
