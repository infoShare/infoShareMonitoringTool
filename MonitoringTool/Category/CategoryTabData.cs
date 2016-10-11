using Newtonsoft.Json;

namespace MonitoringTool.Category
{
   public class CategoryTabData
   {
      [JsonProperty(PropertyName = "id")]
      public string Id { get; set; }

      [JsonProperty(PropertyName = "name")]
      public string Name { get; set; }
   }
}