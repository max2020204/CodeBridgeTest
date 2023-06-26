using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Model;

namespace CodeBridgeTest.Data.Factory.Impliment
{
    public class DogTailLengthDescendingSortStrategy : ISortStrategy<Dog>
    {
        public IEnumerable<Dog> Sort(IEnumerable<Dog> collection)
        {
            return collection.OrderByDescending(x => x.TailLength);
        }
    }
}