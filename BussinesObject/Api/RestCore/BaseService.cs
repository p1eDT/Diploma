using Bogus;
using NLog;

namespace Api.RestCore
{
    public class BaseService
    {
        protected BaseApiClient apiClient;

        protected static Logger logger = LogManager.GetCurrentClassLogger();

        protected static Faker faker = new Faker();

        public BaseService(string url)
        {
            this.apiClient = new BaseApiClient(url);
        }
    }
}