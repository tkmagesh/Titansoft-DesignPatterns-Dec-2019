namespace ProductsApp
{
    public class AndSpecification : IProductSpecification
    {
        private readonly IProductSpecification leftSpecification;
        private readonly IProductSpecification rightSpecification;

        public AndSpecification(IProductSpecification leftSpecification, IProductSpecification rightSpecification)
        {
            this.leftSpecification = leftSpecification;
            this.rightSpecification = rightSpecification;
        }

        public bool isSatisfiedBy(Product product)
        {
            return leftSpecification.isSatisfiedBy(product) && rightSpecification.isSatisfiedBy(product);
        }
    }
}
