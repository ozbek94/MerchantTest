using MerchantTest.Domain.Enums;

namespace MerchantTest.Applicatiıon.Strategies.Customer
{
    public class ConfigurationStrategyFactory
    {
        private readonly Dictionary<ConfigurationEnum, IConfigurationStrategy> _strategies;
        public ConfigurationStrategyFactory()
        {
            _strategies = new Dictionary<ConfigurationEnum, IConfigurationStrategy>
        {
            { ConfigurationEnum.GsmOperator, new GsmOperatorStrategy() },
            { ConfigurationEnum.Email, new EmailStrategy() }
        };

        }
        public IConfigurationStrategy GetStrategy(ConfigurationEnum Configuration)
        {

            if (!_strategies.TryGetValue(Configuration, out var strategy))
            {
                throw new ArgumentException("Invalid configuration");
            }

            return strategy;
        }

    }
}

