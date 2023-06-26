using CodeBridgeTest.Data.Repository.Interfaces;
using CodeBridgeTest.Model;
using CodeBridgeTest.Services.Interfaces;

namespace CodeBridgeTest.Services.Impliment
{
    public class DogServices : IDogsServices
    {
        private readonly IDogRepository _dog;

        public DogServices(IDogRepository dog)
        {
            _dog = dog;
        }

        public IEnumerable<Dog> GetDogs(int? pageNumber, int? pageSize, string? attribute, string? order)
        {
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                if (!string.IsNullOrEmpty(attribute) && !string.IsNullOrEmpty(order))
                {
                    return _dog.GetDogPeganation((int)pageNumber, (int)pageSize, attribute, order);
                }
                else
                {
                    return _dog.GetDogPeganation((int)pageNumber, (int)pageSize);
                }
            }
            else if (!string.IsNullOrEmpty(attribute) && !string.IsNullOrEmpty(order))
            {
                return _dog.SortDog(attribute, order);
            }
            else
            {
                return _dog.GetAll();
            }
        }
    }
}