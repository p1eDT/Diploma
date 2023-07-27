using Api.RestCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObject.Api.Services
{
    internal class TestSuiteService : BaseService
    {
        public string TestSuitesEndpoint = "test-suites";
        public string TestSuiteById = "test-suites/{testSuiteId}";
        public TestSuiteService(string url) : base(url)
        {
        }
    }
}
