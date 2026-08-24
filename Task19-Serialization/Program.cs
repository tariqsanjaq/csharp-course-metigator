using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Task19_Serialization;

public static class Program
{
    private const string JsonFilePath = "products.json";
    private const string XmlFilePath = "products.xml";

    public static void Main()
    {
        var products = BuildSampleProducts();

        Section("1. In-memory objects");
        foreach (var p in products) Console.WriteLine(p);

        // ==================== JSON ====================

        Section("2. JSON serialization (System.Text.Json)");

        // WriteIndented: pretty-print for readability.
        // DefaultIgnoreCondition.WhenWritingNull: any property that is null
        // at write time (Description, DiscountPercent) is left out of the
        // JSON entirely instead of appearing as "key": null.
        var jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        string json = JsonSerializer.Serialize(products, jsonOptions);
        Console.WriteLine(json);

        File.WriteAllText(JsonFilePath, json);
        Console.WriteLine($"\nSaved to {Path.GetFullPath(JsonFilePath)}");

        Section("3. JSON deserialization (round-trip)");
        var jsonRoundTrip = JsonSerializer.Deserialize<List<Product>>(json, jsonOptions);
        foreach (var p in jsonRoundTrip!) Console.WriteLine(p);

        Section("4. JSON with missing fields");
        // Deliberately omits "category", "discount_percent", "in_stock" and
        // "tags". None of these are required - System.Text.Json just
        // leaves the corresponding properties at their class defaults.
        const string sparseJson = """
            {
                "id": 99,
                "product_name": "Mystery Gadget",
                "unit_price": 19.99
            }
            """;
        var sparseProduct = JsonSerializer.Deserialize<Product>(sparseJson, jsonOptions);
        Console.WriteLine("Deserialized from sparse JSON (missing keys fall back to property defaults):");
        Console.WriteLine(sparseProduct);

        Section("5. JSON with a type mismatch (error handling)");
        // "unit_price" is sent as a JSON string, not a number. System.Text.Json
        // does not silently coerce types by default, so this throws.
        const string badJson = """{ "id": 1, "product_name": "Bad Data", "unit_price": "not-a-number" }""";
        try
        {
            JsonSerializer.Deserialize<Product>(badJson, jsonOptions);
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Caught JsonException as expected: {ex.Message}");
        }

        // ==================== XML ====================

        Section("6. XML serialization (XmlSerializer)");

        // XmlSerializer serializes a plain List<Product> too, but it uses a
        // generic <ArrayOfProduct> root. ProductCatalog gives us an explicit,
        // readable root and wrapper element name instead.
        var catalog = new ProductCatalog(products);
        var xmlSerializer = new XmlSerializer(typeof(ProductCatalog));
        var writerSettings = new XmlWriterSettings { Indent = true };

        using (var stringWriter = new StringWriter())
        using (var xmlWriter = XmlWriter.Create(stringWriter, writerSettings))
        {
            xmlSerializer.Serialize(xmlWriter, catalog);
            Console.WriteLine(stringWriter.ToString());
        }

        using (var xmlWriter = XmlWriter.Create(XmlFilePath, writerSettings))
        {
            xmlSerializer.Serialize(xmlWriter, catalog);
        }
        Console.WriteLine($"\nSaved to {Path.GetFullPath(XmlFilePath)}");
        Console.WriteLine("\nNote: XmlSerializer adds xmlns:xsi / xmlns:xsd namespace declarations " +
                           "on the root element by default. The xsi namespace is what makes " +
                           "xsi:nil=\"true\" (used for the null DiscountPercent) meaningful.");

        Section("7. XML deserialization (round-trip)");
        ProductCatalog xmlRoundTrip;
        using (var fileStream = File.OpenRead(XmlFilePath))
        {
            xmlRoundTrip = (ProductCatalog)xmlSerializer.Deserialize(fileStream)!;
        }
        foreach (var p in xmlRoundTrip.Products) Console.WriteLine(p);

        Section("8. XML with missing elements");
        // Omits <Category>, <Description>, <DiscountPercent>, <InStock> and
        // <Tags> entirely - all optional, all fall back to defaults.
        const string sparseXml = """
            <Product id="98">
                <ProductName>Mystery Widget</ProductName>
                <UnitPrice>9.99</UnitPrice>
            </Product>
            """;
        using (var reader = new StringReader(sparseXml))
        {
            var productSerializer = new XmlSerializer(typeof(Product));
            var sparseXmlProduct = (Product)productSerializer.Deserialize(reader)!;
            Console.WriteLine("Deserialized from sparse XML (missing elements fall back to property defaults):");
            Console.WriteLine(sparseXmlProduct);
        }

        Section("9. XML with a malformed document (error handling)");
        // Unclosed <Product> tag - not well-formed XML at all.
        const string malformedXml = "<Product id=\"1\"><ProductName>Broken</ProductName>";
        try
        {
            var productSerializer = new XmlSerializer(typeof(Product));
            using var reader = new StringReader(malformedXml);
            productSerializer.Deserialize(reader);
        }
        catch (InvalidOperationException ex)
        {
            // XmlSerializer wraps the underlying XmlException raised by the
            // XML reader in an InvalidOperationException.
            Console.WriteLine($"Caught InvalidOperationException as expected: " +
                               $"{ex.InnerException?.Message ?? ex.Message}");
        }

        Section("Done");
    }

    private static List<Product> BuildSampleProducts() => new()
    {
        new Product
        {
            Id = 1,
            Name = "Wireless Mouse",
            Price = 24.99m,
            Category = "Electronics",
            Description = "Ergonomic 2.4GHz wireless mouse",
            DiscountPercent = 10m,
            InStock = true,
            Tags = new List<string> { "wireless", "accessory" }
        },
        new Product
        {
            Id = 2,
            Name = "Mechanical Keyboard",
            Price = 89.50m,
            Category = "Electronics",
            Description = null,          // null reference value
            DiscountPercent = null,       // null value type
            InStock = false,
            Tags = new List<string>()     // empty collection, not null
        },
        new Product
        {
            Id = 3,
            Name = "Notebook",
            Price = 3.25m
            // Category, Description, DiscountPercent, InStock and Tags are
            // all left at their property defaults, to show what an
            // "unset" object looks like once serialized.
        }
    };

    private static void Section(string title)
    {
        Console.WriteLine();
        Console.WriteLine(new string('=', 70));
        Console.WriteLine(title);
        Console.WriteLine(new string('=', 70));
    }
}
