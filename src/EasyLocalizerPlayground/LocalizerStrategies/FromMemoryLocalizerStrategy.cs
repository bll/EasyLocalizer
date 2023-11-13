using EasyLocalizer.Abstract;

namespace LocalizerPlayground.LocalizerStrategies
{
    public class FromMemoryLocalizerStrategy : ILocalizerStrategy
	{
        public object Translate(object identifier ,string key)
        {
            return identifier + " " + key + " " +"FromMemory";
        }
    }
}

