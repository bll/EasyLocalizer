using System;
using System.Linq;
using System.Reflection;
using EasyLocalizer.Abstract;
using EasyLocalizer.Attributes;

namespace EasyLocalizer
{
    public class Localize
    {
        public T Translate<T>(ILocalizerStrategy localizerStrategy, T entityToLocalize)
        {
            if (localizerStrategy == null)
            {
                throw new NullReferenceException(nameof(localizerStrategy));
            }

            if (entityToLocalize == null)
            {
                throw new NullReferenceException(nameof(entityToLocalize));
            }

            var propertiesHasLocalizerAttribute = entityToLocalize
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .ToList()
                .Where(p => Attribute.IsDefined(p, typeof(LocalizerAttribute)));

            foreach (var property in propertiesHasLocalizerAttribute)
            {
                var localizerAttribute = property.GetCustomAttributes<LocalizerAttribute>(false).First();

                var identifierValue = localizerAttribute.Identifier;

                var identifierProperty = entityToLocalize
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .ToList()
                .Where(p => p.Name.Equals(identifierValue)).FirstOrDefault();

                if (identifierProperty != null)
                {
                    identifierValue = identifierProperty.GetValue(entityToLocalize).ToString();
                }

                property.SetValue(entityToLocalize, localizerStrategy.Translate(identifierValue, localizerAttribute.Key));
            }

            return entityToLocalize;
        }
    }
}

