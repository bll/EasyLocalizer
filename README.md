![alt tag](/img/EasyLocalizer.png)  

Simple localization library via to your localization strategy.

[![NuGet version](https://badge.fury.io/nu/EasyLocalizer.svg)](https://badge.fury.io/nu/EasyLocalizer)  ![Nuget](https://img.shields.io/nuget/dt/EasyLocalizer)

#### Usages:
----- 
 
```cs
// Model for localization

public class Category
{
	public Guid Id { get; set; }

	[LocalizerAttribute(nameof(Id), "Category.Name")] // Localization identifer key
	public string Name { get; set; }

	public Category SubCategory { get; set; }
}

// Example strategy

public class FromMemoryLocalizerStrategy : ILocalizerStrategy // Localization strategy defination interface
{
    public object Translate(object identifier ,string key)
    {
        return identifier + " " + key + " " +"FromMemory";
    }
}

// Example category

var category = new Category {
    Id = Guid.NewGuid(),
    Name = "Computer",
    SubCategory = new Category
    {
        Id = Guid.NewGuid(),
        Name = "Desktop"
    }
};

// Usage

var easyLocalizer = new EasyLocalizer.Localizer();

var localizedEntity = easyLocalizer.Translate(new FromMemoryLocalizerStrategy(), category);

/* 
Localization input: "Computer"
localization output: "Computer FromMemory"
 */
```
### Release Notes
#### 1.0.2
* Nuget version updated

#### 1.0.0
* Base Release
