using CodeBridgeTest.Model;

namespace CodeBridgeTest.Data.Repository.Interfaces
{
    public interface IDogRepository : IRepository<Dog>
    {
        IQueryable<Dog> GetDogPeganation(int pageNumber, int pageSize);

        IEnumerable<Dog> GetDogPeganation(int pageNumber, int pageSize, string attribute, string order);

        IEnumerable<Dog> SortDog(string attribute, string order);
    }
}