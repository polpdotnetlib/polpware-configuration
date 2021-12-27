using System.Collections.Generic;
using System.Reflection;

namespace Polpware.Configuration.Binder
{
    public static class Extensions
    {
        public static U ToTypeSafeObject<U, TValue>(this IDictionary<string, TValue> input) 
            where U : class, new()
        {
            var someObject = new U();
            var someObjectType = someObject.GetType();

            foreach (PropertyInfo propertyInfo in someObjectType.GetProperties())
            {
                var value = input[propertyInfo.Name];
                if (value != null)
                {
                    propertyInfo.SetValue(someObject, value.ToString(), null);
                }
            }

            return someObject;
        }
    }
}
