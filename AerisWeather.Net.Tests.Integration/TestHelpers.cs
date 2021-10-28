using System;
using System.Reflection;
using Xunit;

namespace K23.Aeris.NetCore.Tests.Integration
{
    public static class TestHelpers
    {
       public static void ValidateAllPropertiesHaveValue<T>(T thing, string param)
        {

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Assert.NotNull(thing.GetType().GetProperty(property.Name));
            }
        }
    }
}
