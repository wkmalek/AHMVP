using AHWForm.Repos;

namespace Repositories
{
    public static class RepositoryFactory
    {
        public static TRepository GetRepositoryInstance<T, TRepository>()
        where TRepository : IRepository<T>, new() where T : class
        {
            return new TRepository();
        }
    }
}