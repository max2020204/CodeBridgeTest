using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Data.Repository.Interfaces;
using CodeBridgeTest.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeBridgeTest.Data.Repository.Implement
{
    public class DogRepository : EFRepository<Dog>, IDogRepository
    {
        private AppDbContext context { get; set; }
        private ISortStrategyFactory<Dog> sort { get; set; }
        public DogRepository(AppDbContext _context, ISortStrategyFactory<Dog> _sort) : base(_context)
        {
            context = _context;
            sort = _sort;
        }

        public IQueryable<Dog> GetDogPeganation(int pageNumber, int pageSize)
        {
            return context.Dogs.AsSplitQuery().OrderBy(x => x.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Dog> SortDog(string attribute, string order)
        {
            ISortStrategy<Dog> sortStrategy = sort.Create(attribute, order);
            return sortStrategy.Sort(context.Dogs.AsSplitQuery());

        }
        public IEnumerable<Dog> GetDogPeganation(int pageNumber, int pageSize, string attribute, string order)
        {
            IEnumerable<Dog> query = context.Dogs;
            ISortStrategy<Dog> sortStrategy = sort.Create(attribute, order);
            return sortStrategy.Sort(query).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
