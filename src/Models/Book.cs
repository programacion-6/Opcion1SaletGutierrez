using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Opcion1SaletGutierrez.src.Enums;

namespace Opcion1SaletGutierrez.src.Models;

public class Book
{
    public string Title { get; set; }

    public string Author { get; set; }

    public string Isbn { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public Genre Genre { get; set; }

    public int PublicationYear { get; set; }

    public bool IsAvailable { get; set; } = true;

}