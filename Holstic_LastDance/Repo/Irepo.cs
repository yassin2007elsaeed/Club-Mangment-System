namespace Holstic_LastDance.Repo
{
    public interface Irepo<T> where T : class
    {
        public Task<List<T>> GetAllAsync();

        public Task<T> GetById(int id);

        public Task Create (T entity);
        public Task Update (T entity);
        public Task Delete (T entity);

        public Task Save();
    }
}
