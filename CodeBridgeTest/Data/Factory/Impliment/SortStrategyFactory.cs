using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Model;
using CodeBridgeTest.Services.Managment;

namespace CodeBridgeTest.Data.Factory.Impliment
{
    public class SortStrategyFactory : ISortStrategyFactory<Dog>
    {
        private IServiceProvider provider { get; set; }
        public SortStrategyFactory(IServiceProvider _provider)
        {
            provider = _provider;
        }
        public ISortStrategy<Dog> Create(string attribute, string order)
        {
            var services = provider.GetServices<ISortStrategy<Dog>>();
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
