using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlashCards.Server.Models.Data
{
    public class Survey : BaseData
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ICollection<Question>? Questions { get; set; } 
    }
}
