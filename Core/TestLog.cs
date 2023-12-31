﻿using NLog;
using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;

namespace Core
{
    public class TestLog
    {
        public static Logger Logger;

        public TestLog()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }

        public void Message(string message)
        {
            var prefix = GetCallerTestDescription();
            Logger.Info("[{0}] {1}", prefix, message);
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
                return "stack is null";
        }
    }
}
