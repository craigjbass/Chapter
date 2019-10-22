using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chapter
{
    public static class DynamicAnonymousObjects
    {
        public static dynamic ToDynamic(this object obj)
        {
            var expando = new ExpandoObject();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj.GetType()))
            {
                var value = property.GetValue(obj);
                if (value != null && value.GetType().IsAnonymousType()) value = value.ToDynamic();
                expando.TryAdd(property.Name, value);
            }
            return expando;
        }

        public static bool IsAnonymousType(this Type type)
        {
            bool nameContainsAnonymousType = type.FullName.Contains("AnonymousType");

            return type.HasCompilerGeneratedAttribute() && nameContainsAnonymousType;
        }

        private static bool HasCompilerGeneratedAttribute(this Type type) 
            => type.GetCustomAttributes(typeof(CompilerGeneratedAttribute), false).Any();
    }
}