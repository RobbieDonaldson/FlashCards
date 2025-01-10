using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlashCards.Server.Models.Data
{
    public class Question : BaseData
    {
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public int SurveyId { get; set; }   
        public required string QuestionText { get; set; }
        public required string AnswerText { get; set; }
    }
}
