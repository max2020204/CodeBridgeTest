using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Model;
using CodeBridgeTest.Services.Managment;

namespace CodeBridgeTest.Data.Factory.Impliment
{
    public class SortStrategyFactory : ISortStrategyFactory<Dog>
    {
        private readonly IServiceProvider _provider;

        public SortStrategyFactory(IServiceProvider _provider)
        {
            this._provider = _provider;
        }

        public ISortStrategy<Dog> Create(string attribute, string order)
        {
            var services = _provider.GetServices<ISortStrategy<Dog>>();
            if (attribute == Attributes.TailLength)
            {
                if (order == Order.Desc)
                    return services.FirstOrDefault(x => x.GetType() == typeof(DogTailLengthDescendingSortStrategy));
                else
                    return services.FirstOrDefault(x => x.GetType() == typeof(DogTailLengthAscendingSortStrategy));
            }
            else if (attribute == Attributes.Weight)
            {
                if (order == Order.Desc)
                    return services.FirstOrDefault(x => x.GetType() == typeof(DogWeightDescendingSortStrategy));
                else
                    return services.FirstOrDefault(x => x.GetType() == typeof(DogWeightAscendingSortStrategy));
            }

            throw new ArgumentException("Invalid attribute or order.");
        }
    }
}