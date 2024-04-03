using Autofac;
using MerchantTest.Applicatiıon.Managers.Caches;
using MerchantTest.Applicatiıon.Services;
using MerchantTest.Applicatiıon.Strategies.Customer;
using MerchantTest.Infrastructure.Contexts;
using MerchantTest.Infrastructure.Repositories;

namespace MerchantTest.Api
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            LoadContext(builder);
            LoadRepositories(builder);
            LoadServices(builder);
        }
        private void LoadContext(ContainerBuilder builder)
        {

            builder.RegisterType<PostgreSqlContext>().InstancePerDependency();
        }

        private void LoadRepositories(ContainerBuilder builder)
        {

            builder.RegisterType<MerchantRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<PaymentMethodRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<CustomerRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<PaymentRequestRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();

        }

        private void LoadServices(ContainerBuilder builder)
        {
            builder.RegisterType<RedisCacheManager>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<ConfigurationStrategyFactory>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<GsmOperatorStrategy>().As<IConfigurationStrategy>().InstancePerLifetimeScope();
            builder.RegisterType<EmailStrategy>().As<IConfigurationStrategy>().InstancePerLifetimeScope();
            builder.RegisterType<RedisClient>().AsSelf().SingleInstance();
        }
    }
}
