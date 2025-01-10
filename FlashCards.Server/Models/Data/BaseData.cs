using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlashCards.Server.Models.Data
{
    public class BaseData
    {
        [JsonIgnore] 
        public bool Active { get; set; }
        [JsonIgnore]
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [JsonIgnore]
        public string? CreatedBy { get; set; }
        [JsonIgnore]
        [Column(TypeName = "datetime")]
        public DateTime? Updated { get; set; }
        [JsonIgnore]
        public string? UpdatedBy { get; set; }
    }
}
