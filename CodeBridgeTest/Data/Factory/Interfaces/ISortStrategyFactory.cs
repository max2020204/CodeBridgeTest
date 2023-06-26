namespace CodeBridgeTest.Data.Factory.Interfaces
{
    public interface ISortStrategyFactory<T> where T : class
    {
        ISortStrategy<T> Create(string attribute, string order);
    }
}