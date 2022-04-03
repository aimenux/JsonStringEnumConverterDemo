using System.ComponentModel;
using Example05.Application;
using Example05.Converters;

namespace Example05
{
    public static class Extensions
    {
        public static IMvcBuilder AddTypeConverters(this IMvcBuilder builder)
        {
            TypeDescriptor.AddAttributes(typeof(Country), new TypeConverterAttribute(typeof(StringEnumConverter<Country>)));
            return builder;
        }
    }
}
