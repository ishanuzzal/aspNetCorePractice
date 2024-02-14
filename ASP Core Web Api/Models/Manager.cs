using System.Text.Json.Serialization;

namespace ASP_Core_Web_Api.Models
{
    public class Manager
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Order> Orders { get; set; } = new();

    }
}
