using System.Xml.Serialization;

namespace Task19_Serialization;

/// <summary>
/// Root wrapper used only for XML serialization. XmlSerializer needs an
/// explicit container type to name the outer document element and the
/// element that wraps the product list.
/// </summary>
/// <remarks>
/// JSON needs no equivalent wrapper - System.Text.Json serializes a
/// List&lt;Product&gt; directly to a top-level JSON array. That asymmetry
/// (JSON: bare array, XML: named root + named wrapping element) is a real
/// difference between the two formats, not an oversight.
/// </remarks>
[XmlRoot("ProductCatalog")]
public class ProductCatalog
{
    [XmlArray("Products")]
    [XmlArrayItem("Product")]
    public List<Product> Products { get; set; } = new();

    // Parameterless constructor required by XmlSerializer.
    public ProductCatalog() { }

    public ProductCatalog(List<Product> products)
    {
        Products = products;
    }
}
