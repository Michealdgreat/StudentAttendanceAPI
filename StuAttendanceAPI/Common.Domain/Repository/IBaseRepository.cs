namespace Common.Domain.Repository
{

    /// <summary>
    /// Base repository interface, which all repository depends on.
    /// </summary>
    public interface IBaseRepository
    {
        Task<int> DeleteData<T>(string dBSp, T parameters);
        Task<List<T>> LoadData<T, U>(string dpSp, U parameters);
        Task<T?> LoadOneData<T, U>(string dpSp, U parameters);
        Task<int> SaveData<T>(string dBSp, T parameters);
    }
}