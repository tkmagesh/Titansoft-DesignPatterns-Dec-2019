namespace ProductsApp
{
    public class CostProductSpecification : IProductSpecification
    {
        private readonly decimal cost;

        public CostProductSpecification(decimal cost)
        {
            this.cost = cost;
        }
        public bool isSatisfiedBy(Product product)
        {
            return product.Cost >= this.cost;
        }
    }
}
