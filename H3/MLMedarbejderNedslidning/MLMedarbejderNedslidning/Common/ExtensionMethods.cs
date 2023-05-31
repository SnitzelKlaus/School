using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MLMedarbejderNedslidning.Common
{
    public static class ExtensionMethods
    {
        public static List<string> ToPropertyList<T>(this Type type, string excludePropertyName = null)
        {
            var list = new List<string>();

            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                if (propertyInfo.GetIndexParameters().Length == 0 && propertyInfo.Name != excludePropertyName)
                {
                    list.Add(propertyInfo.Name);
                }
            }

            return list;
        }
    }
}
