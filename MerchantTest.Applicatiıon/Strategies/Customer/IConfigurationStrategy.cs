namespace MerchantTest.Applicatiıon.Strategies.Customer
{
    public interface IConfigurationStrategy
    {
        Task<string> Execute();
    }
    public class GsmOperatorStrategy : IConfigurationStrategy
    {
        public async Task<string> Execute()
        {
            return ("OTP");
        }
    }

    public class EmailStrategy : IConfigurationStrategy
    {
        public async Task<string> Execute()
        {
            return ("Email");
        }

        //Execute string değil de integer döndürüyorsa nasıl yaparım?
    }
}
