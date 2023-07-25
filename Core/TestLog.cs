using Core.Selenium;
using NLog;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class TestLog
    {
        public void Message(string message)
        {
            var prefix = GetCallerTestDescription();
            Browser.Logger.Info("[{0}] {1}", prefix, message);
        }

        private string GetCallerTestDescription()
        {
            var stack = new StackTrace(false).GetFrames();
            var result = "";
            if (stack != null)
            {
                foreach (var frame in stack)
                {
                    var method = frame.GetMethod();
                    var testAttributes = method.GetCustomAttributes<TestAttribute>();

                    if (testAttributes != null && testAttributes.Any())
                    {
                        return method.Name;
                    }

                    IEnumerable<TestCaseAttribute> tcAttributes = method.GetCustomAttributes<TestCaseAttribute>();
                    if (tcAttributes != null && tcAttributes.Any())
                    {
                        return method.Name;
                    }
                }
            }
            else
            {
                result = "stack is null";
            }
            return result;
        }
    }
}
