namespace Poke.API.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IEmployeeRepository UserRepository { get; }
    }
}