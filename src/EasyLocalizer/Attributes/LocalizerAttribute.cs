using System;

namespace EasyLocalizer.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
    public class LocalizerAttribute : Attribute
	{
		public	string Key { get; set; }
        public string Identifier { get; set; }

        public LocalizerAttribute(string identifier, string key)
		{
			Key = key;
            Identifier = identifier;
        }
	}
}

