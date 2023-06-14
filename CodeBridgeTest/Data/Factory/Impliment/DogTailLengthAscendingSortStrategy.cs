using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Model;

namespace CodeBridgeTest.Data.Factory.Impliment
{
    public class DogTailLengthAscendingSortStrategy : ISortStrategy<Dog>
    {
        public IEnumerable<Dog> Sort(IEnumerable<Dog> collection)
        {
            return collection.OrderBy(x => x.TailLength);
        }
    }
}
