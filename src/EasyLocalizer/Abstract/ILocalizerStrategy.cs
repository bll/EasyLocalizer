namespace EasyLocalizer.Abstract
{
    public interface ILocalizerStrategy
	{
		public object Translate(object identifier, string key);
	}
}

