using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Task19_Serialization;

/// <summary>
/// Represents a store product. Carries both System.Text.Json attributes
/// (for JSON key naming and null handling) and System.Xml.Serialization
/// attributes (for XML element/attribute naming), so a single class
/// round-trips through both formats with different wire representations.
/// </summary>
/// <remarks>
/// XmlSerializer requires a public, parameterless constructor on any type
/// it serializes. We don't declare one explicitly - the compiler generates
/// an implicit one because no other constructor is defined here.
/// </remarks>
[XmlType("Product")]
public class Product
{
    // Demonstrates XmlAttribute (renders as an XML attribute, e.g. id="1")
    // instead of a child element. JSON has no such distinction - it always
    // becomes a regular key.
    [XmlAttribute("id")]
    public int Id { get; set; }

    // --- Custom property naming ---
    // [JsonPropertyName] renames the JSON key; [XmlElement] independently
    // renames the XML element. The two formats can use completely
    // different names for the same C# property.
    [JsonPropertyName("product_name")]
    [XmlElement("ProductName")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("unit_price")]
    [XmlElement("UnitPrice")]
    public decimal Price { get; set; }

    // --- Missing-field handling ---
    // If a JSON key or XML element for Category is absent from the source
    // document entirely, both System.Text.Json and XmlSerializer leave the
    // property at this default value instead of throwing.
    [XmlElement("Category")]
    public string Category { get; set; } = "Uncategorized";

    // --- Null handling: reference type ---
    // Nullable string. On write, Program.cs configures
    // JsonIgnoreCondition.WhenWritingNull so a null Description is omitted
    // from the JSON entirely rather than written as "description": null.
    // XmlSerializer's default behavior already omits a null reference-type
    // element with no extra configuration needed.
    [XmlElement("Description")]
    public string? Description { get; set; }

    // --- Null handling: value type ---
    // Nullable<decimal>. Value types need IsNullable = true on the XML
    // attribute, or XmlSerializer throws when the value is null instead of
    // writing <DiscountPercent xsi:nil="true" />. System.Text.Json handles
    // Nullable<T> the same way it handles any other type - no extra
    // attribute required.
    [JsonPropertyName("discount_percent")]
    [XmlElement("DiscountPercent", IsNullable = true)]
    public decimal? DiscountPercent { get; set; }

    [JsonPropertyName("in_stock")]
    [XmlElement("InStock")]
    public bool InStock { get; set; } = true;

    // --- Collections ---
    // XmlArray names the wrapping element; XmlArrayItem names each item
    // inside it. System.Text.Json needs no equivalent - a List<T> just
    // becomes a JSON array using the property's own (possibly renamed) key.
    [XmlArray("Tags")]
    [XmlArrayItem("Tag")]
    public List<string> Tags { get; set; } = new();

    public override string ToString()
    {
        var tags = Tags.Count > 0 ? string.Join(", ", Tags) : "(none)";
        var discount = DiscountPercent.HasValue ? $"{DiscountPercent}%" : "(none)";
        var description = Description ?? "(none)";
        return $"[{Id}] {Name} - {Price:C} | Category: {Category} | InStock: {InStock} " +
               $"| Discount: {discount} | Description: {description} | Tags: {tags}";
    }
}
