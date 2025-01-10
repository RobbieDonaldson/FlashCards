using FlashCards.Server.Data;
using FlashCards.Server.Models.Data;
using FlashCards.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FlashCards.Server.Services.Classes
{
    public class DataService : IDataService
    {
        readonly ApplicationDbContext _context;
        public DataService(ApplicationDbContext context)
        {
            _context = context;
        }    
        public async Task<IList<Question>?> GetQuestionsAsync(int id)
        {
            try
            {
                return await _context.Questions.Where(i  => i.SurveyId == id && i.Active).ToListAsync();
            }
            catch(Exception ex)
            {
                // log exception
                return null;
            }
        }

        public async Task<Survey?> GetSurveyAsync(int id)
        {
            try
            {
                return await _context.Surveys.Where(i => i.Id == id && i.Active).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log exception
                return null;
            }
        }

        public async Task<IList<Survey>?> GetSurveysAsync()
        {
            try
            {
                return await _context.Surveys.Where(i => i.Active == true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log exception
                return null;
            }
        }

        //public async Task<int> ImportQuestionsAsync(int id, string filePath)
        //{
            
        //    try
        //    {
        //        IList<Question> questions = new List<Question>();
        //        var readcsv = File.ReadAllText(filePath);
        //        string[] csvfilerecord = readcsv.Split('\n');
        //        questions.Clear();

        //        foreach (var row in csvfilerecord)
        //        {
        //            if (!string.IsNullOrEmpty(row))
        //            {
        //                var cells = row.Split(',');
        //                questions.Add(new Question() { SurveyId = Convert.ToInt32(cells[0]), Active = Convert.ToBoolean(cells[1]), QuestionText = cells[2], AnswerText = cells[3] });
        //            }
        //        }

        //        await _context.Questions.AddRangeAsync(questions);
        //        _context.SaveChanges();

        //        return questions.Count;
        //    }
        //    catch (Exception ex)
        //    {
        //        // log exception
        //        return -1;
        //    }
        //}

        //public async Task<int> ImportSurveysAsync(string filePath)
        //{
        //    try
        //    {
        //        IList<Survey> surveys = new List<Survey>();
        //        var readcsv = File.ReadAllText(filePath);
        //        string[] csvfilerecord = readcsv.Split('\n');
        //        surveys.Clear();

        //        foreach (var row in csvfilerecord)
        //        {
        //            if (!string.IsNullOrEmpty(row))
        //            {
        //               var cells = row.Split(',');
        //               surveys.Add(new Survey() { Active = Convert.ToBoolean(cells[0]), Name = cells[1], Description = cells[2] });
        //            }
        //        }

        //        await _context.Surveys.AddRangeAsync(surveys);
        //        _context.SaveChanges();

        //        return surveys.Count;
        //    }
        //    catch (Exception ex)
        //    {
        //        // log exception
        //        return -1;
        //    }
        //}
    }
}
