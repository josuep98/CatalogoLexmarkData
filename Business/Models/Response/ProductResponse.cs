using Newtonsoft.Json;

namespace Business.Models.Response
{
    public class ProductResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("numberPart")]
        public string NumberPart { get; set; }

        [JsonProperty("printSpeed")]
        public int? PrintSpeed { get; set; }

        [JsonProperty("maximumMonthly")]
        public int? MaxMonthly { get; set; }

        [JsonProperty("recommendedMonthly")]
        public int? RecMonthly { get; set; }

        [JsonProperty("details")]
        public string Detail { get; set; }

        [JsonProperty("pvp")]
        public decimal? Pvp { get; set; }

        [JsonProperty("categoryId")]
        public int? CategoryId { get; set; }
    }
}
