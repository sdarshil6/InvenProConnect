namespace InvenProConnect.DAOs.Interfaces
{
    public interface IDaoWrapper
    {
        IUserDao UserDao { get; }
        Task SaveAsync();
    }
}
