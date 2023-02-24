using studyBuddy_API_2023.Models;
using Microsoft.EntityFrameworkCore;

namespace studyBuddy_API_2023.DAL
{
  public class StudyQuestionsRepository
  {
    private StudyContext _dbContext = new StudyContext();

    public StudyQuestions AddStudyQuestion(StudyQuestions study)
    {
      _dbContext.StudyQuestions.Add(study);
      _dbContext.SaveChanges();
      return GetLatestStudyQuestions();
    }

    public List<StudyQuestions> GetAllStudyQuestions()
    {
      return _dbContext.StudyQuestions.ToList();
    }


    private StudyQuestions GetLatestStudyQuestions()
    {
      return _dbContext.StudyQuestions.OrderByDescending(x => x.Id).FirstOrDefault();
    }

    public StudyQuestions FindById(int id)
    {
      return _dbContext.StudyQuestions.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public bool DeleteById(int id)
    {
      StudyQuestions studyQuestions = FindById(id);
      if (studyQuestions == null)
      {
        return false;
      }
      _dbContext.StudyQuestions.Remove(studyQuestions);
      _dbContext.SaveChanges();
      return true;
    }
    public bool UpdateStudyQuestions(StudyQuestions studyQuestionsToEdit)
    {
      if (FindById(studyQuestionsToEdit.Id) == null)
      {
        return false;
      }

      _dbContext.StudyQuestions.Update(studyQuestionsToEdit);
      _dbContext.SaveChanges();
      return true;
    }
  }
}
