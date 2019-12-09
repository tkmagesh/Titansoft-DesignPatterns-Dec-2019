namespace ProductsApp
{
    public class CategoryProductSpecification : IProductSpecification
    {
        private readonly string categoryName;

        public CategoryProductSpecification(string categoryName)
        {
            this.categoryName = categoryName;
        }
       
    

        bool IProductSpecification.isSatisfiedBy(IProduct product)
        {
            return product.Category == this.categoryName;
        }
    }
}
