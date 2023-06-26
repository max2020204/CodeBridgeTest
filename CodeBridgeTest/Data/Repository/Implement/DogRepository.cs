using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Data.Repository.Interfaces;
using CodeBridgeTest.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeBridgeTest.Data.Repository.Implement
{
    public class DogRepository : EFRepository<Dog>, IDogRepository
    {
        private readonly AppDbContext _context;
        private readonly ISortStrategyFactory<Dog> _sort;

        public DogRepository(AppDbContext context, ISortStrategyFactory<Dog> sort) : base(context)
        {
            _context = context;
            _sort = sort;
        }

        public IQueryable<Dog> GetDogPeganation(int pageNumber, int pageSize)
        {
            return _context.Dogs.AsSplitQuery().OrderBy(x => x.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Dog> SortDog(string attribute, string order)
        {
            ISortStrategy<Dog> sortStrategy = _sort.Create(attribute, order);
            return sortStrategy.Sort(_context.Dogs.AsSplitQuery());
        }

        public IEnumerable<Dog> GetDogPeganation(int pageNumber, int pageSize, string attribute, string order)
        {
            IEnumerable<Dog> query = _context.Dogs;
            ISortStrategy<Dog> sortStrategy = _sort.Create(attribute, order);
            return sortStrategy.Sort(query).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}