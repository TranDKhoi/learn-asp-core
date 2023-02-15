namespace LearnASP.Core.Contracts
{
    public interface IUnitOfWork
    {
        ICategoryRepo Category { get; }
        IProductRepo Product { get; }
    }
}
