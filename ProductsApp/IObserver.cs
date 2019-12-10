namespace ProductsApp
{
    public interface IObserver<T>
    {
        void Update(T data);
    } 
}