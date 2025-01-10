using FlashCards.Server.Models.Data;

namespace FlashCards.Server.Services.Interfaces
{
    public interface IDataService
    {
        Task<IList<Survey>?> GetSurveysAsync();
        Task<Survey?> GetSurveyAsync(int id);
        Task<IList<Question>?> GetQuestionsAsync(int id);
        //Task<int> ImportSurveysAsync(string filePath);
        //Task<int> ImportQuestionsAsync(int id, string filePath);
    }
}
