using System;
namespace K23.Aeris.NetCore.Tests.Integration
{
    public static class DataRowAssertFailLogs
    {
        public static string AssertEqualLog(string param, string expected, string actual)
        {
            return $"{param} | failed: expected: {expected} and actual: {actual}";
        }

        internal static string AssertIsNotNullLog(string param1, string name)
        {
            return $"{param1} | failed: expected {name} to be null";
        }
    }
}
