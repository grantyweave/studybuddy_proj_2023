using studyBuddy_API_2023.Models;
using Microsoft.EntityFrameworkCore;

namespace studyBuddy_API_2023.DAL
{
  public class StudyQuestionsRepository
  {
    private StudyContext _dbContext = new StudyContext();

    public StudyQuestion AddStudyQuestion(StudyQuestion study)
    {
      _dbContext.StudyQuestions.Add(study);
      _dbContext.SaveChanges();
      return GetLatestStudyQuestions();
    }

    public List<StudyQuestion> GetAllStudyQuestions()
    {
      return _dbContext.StudyQuestions.ToList();
    }


    private StudyQuestion GetLatestStudyQuestions()
    {
      return _dbContext.StudyQuestions.OrderByDescending(x => x.Id).FirstOrDefault();
    }

    public StudyQuestion FindById(int id)
    {
      return _dbContext.StudyQuestions.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public bool DeleteById(int id)
    {
      StudyQuestion studyQuestions = FindById(id);
      if (studyQuestions == null)
      {
        return false;
      }
      _dbContext.StudyQuestions.Remove(studyQuestions);
      _dbContext.SaveChanges();
      return true;
    }
    public bool UpdateStudyQuestions(StudyQuestion studyQuestionsToEdit)
    {
      if (FindById(studyQuestionsToEdit.Id) == null)
      {
        return false;
      }

      _dbContext.StudyQuestions.Update(studyQuestionsToEdit);
      _dbContext.SaveChanges();
      return true;
    }

    public FavoriteQuestion AddFavoriteQuestion(FavoriteQuestion newFavoriteQuestion)
    {
      _dbContext.FavoriteQuestions.Add(newFavoriteQuestion);
      _dbContext.SaveChanges();
      return newFavoriteQuestion;
    }

    public List<StudyQuestion> GetAllUserFavoriteQuestions(int userId)
    {
      var usersQuestions = _dbContext.FavoriteQuestions.Where(x => x.UserId == userId).Select(x => x.QuestionId).ToList();
      return _dbContext.StudyQuestions.Where(x => usersQuestions.Contains(x.Id)).ToList();
      
    }

    public void DeleteFavoriteQuestion(int userId, int questionId)
    {
      var favorite = _dbContext.FavoriteQuestions.FirstOrDefault(x => x.UserId == userId && x.QuestionId == questionId);
      if (favorite != null)
      {
        _dbContext.FavoriteQuestions.Remove(favorite);
        _dbContext.SaveChanges();
      }
    }
  }
}
