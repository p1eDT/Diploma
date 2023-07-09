using Api.RestCore;

namespace Api.RestCore
{
    public class BaseService
    {
        protected BaseApiClient apiClient;

        public BaseService(string url)
        {
            this.apiClient = new BaseApiClient(url);
        }
    }
}