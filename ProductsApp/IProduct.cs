namespace ProductsApp
{
    public interface IProduct
    {
        string Category { get; set; }
        decimal Cost { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        int Units { get; set; }
    }
}