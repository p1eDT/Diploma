using Api.RestCore;
using NLog;

namespace Api.RestCore
{
    public class BaseService
    {
        protected BaseApiClient apiClient;

        protected static Logger logger = LogManager.GetCurrentClassLogger();

        public BaseService(string url)
        {
            this.apiClient = new BaseApiClient(url);
        }
    }
}