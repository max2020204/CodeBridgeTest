namespace CodeBridgeTest.Data.Factory.Interfaces
{
    public interface ISortStrategy<T> where T : class
    {
        IEnumerable<T> Sort(IEnumerable<T> collection);
    }
}