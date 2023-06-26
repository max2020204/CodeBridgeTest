using CodeBridgeTest.Model;

namespace CodeBridgeTest.Services.Interfaces
{
    public interface IDogsServices
    {
        IEnumerable<Dog> GetDogs(int? pageNumber, int? pageSize, string? attribute, string? order);
    }
}