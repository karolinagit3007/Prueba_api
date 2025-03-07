using Newtonsoft.Json;

namespace EjemploMVC_MAT.Models;

public class CardModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Desc { get; set; }
    public string Race { get; set; }
    public string Attribute { get; set; }
    public int? Atk { get; set; }
    public int? Def { get; set; }
    public int? Level { get; set; }

    [JsonProperty("card_images")]
    public List<CardImage> CardImages { get; set; }
}

public class CardImage
{
    [JsonProperty("image_url")]
    public string ImageUrl { get; set; }
}
