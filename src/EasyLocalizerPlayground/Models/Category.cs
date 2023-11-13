using EasyLocalizer.Attributes;

namespace LocalizerPlayground.Models
{
    public class Category
	{
		public Guid Id { get; set; }

		[Localizer(nameof(Id), "Category.Name")]
		public string Name { get; set; }

		public Category SubCategory { get; set; }
	}
}