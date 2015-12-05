using System;
using System.Reflection;

namespace SCOUT.Core.Data
{
    public static class Reflection
    {
        public static string GetPropertyValue(object caller, string propertyName)
        {
            PropertyInfo info = caller.GetType().GetProperty(propertyName);

            object propertyValue;
            if (info != null)
            {
                propertyValue = info.GetValue(caller, null);

                if (propertyValue == null)
                    return null;

                return propertyValue.ToString();
            }

            return null;
        }

        public static void ClearPublicProperties(object obj)
        {
            Type type = obj.GetType();
            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.GetSetMethod() != null)
                    property.SetValue(obj, null, null);
            }
        }

        public static T CreateInstanceOfType<T>(string type)
        {
            if (string.IsNullOrEmpty(type))
                return default(T);

            return (T)Activator.CreateInstance(Type.GetType(type));
        }

        public static T CreateInstanceOfType<T>(params object[] constructorArgs)
        {
            return (T) Activator.CreateInstance(typeof (T), constructorArgs);
        }
    }

    public class PropertyMapper<TFrom, TKTo>
    {
        public void MapFrom(TFrom input, TKTo output)
        {
            Type outputType = typeof (TKTo);
            Type inputType = typeof (TFrom);

            foreach (PropertyInfo info in outputType.GetProperties())
            {
                PropertyInfo inputProperty = inputType.GetProperty(info.Name,
                                                                   info.
                                                                       PropertyType);

                if (inputProperty != null)
                {
                    if (inputProperty.GetGetMethod() != null)
                    {
                        object inputValue = inputProperty.GetValue(input, null);

                        try
                        {
                            if (inputValue != null)
                                info.SetValue(output, inputValue, null);
                        }
                        catch (Exception)
                        {
                            // TODO : Fix this issue with the image mapping to byte steams.
                            // ImageService
                            // Do Nothing
                            // Horrible, I know. I cannot figure out why mapping a image from memory into a byte stream
                            // fails even after i clone it.
                           
                        }
                    }
                }
            }
        }
    }
}