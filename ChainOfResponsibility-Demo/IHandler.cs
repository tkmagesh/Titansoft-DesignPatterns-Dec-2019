namespace ChainOfResponsibility_Demo
{
    //Chain Of Responsibility

    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(object request);
    }
}
