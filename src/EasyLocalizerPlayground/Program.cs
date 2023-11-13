// See https://aka.ms/new-console-template for more information
using LocalizerPlayground.LocalizerStrategies;
using LocalizerPlayground.Models;

var category = new Category {
    Id = Guid.NewGuid(),
    Name = "Computer",
    SubCategory = new Category
    {
        Id = Guid.NewGuid(),
        Name = "Desktop"
    }
};

var easyLocalizer = new EasyLocalizer.Localize();

var localizedEntity = easyLocalizer.Translate(new FromMemoryLocalizerStrategy(), category);
localizedEntity.SubCategory = easyLocalizer.Translate(new FromMemoryLocalizerStrategy(), category.SubCategory);


Console.WriteLine("Localized....");