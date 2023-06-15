using CodeBridgeTest.Data.Repository.Interfaces;
using CodeBridgeTest.Model;
using CodeBridgeTest.Services.Interfaces;

namespace CodeBridgeTest.Services.Impliment
{
    public class DogServices : IDogsServices
    {
        private IDogRepository Dog { get; set; }
        public DogServices(IDogRepository dog)
        {
            Dog = dog;
        }
        public IEnumerable<Dog> GetDogs(int? pageNumber, int? pageSize, string? attribute, string? order)
        {
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                if (!string.IsNullOrEmpty(attribute) && !string.IsNullOrEmpty(order))
                {
                    return Dog.GetDogPeganation((int)pageNumber, (int)pageSize, attribute, order);
                }
                else
                {
                    return Dog.GetDogPeganation((int)pageNumber, (int)pageSize);
                }
            }
            else if (!string.IsNullOrEmpty(attribute) && !string.IsNullOrEmpty(order))
            {
                return Dog.SortDog(attribute, order);
            }
            else
            {
                return Dog.GetAll();
            }
        }
    }
}
