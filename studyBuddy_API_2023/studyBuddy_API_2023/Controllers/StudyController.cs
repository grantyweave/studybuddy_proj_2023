using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studyBuddy_API_2023.DAL;
using studyBuddy_API_2023.Models;
using System.Net;

namespace studyBuddy_API_2023.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudyController : ControllerBase
  {
    StudyQuestionsRepository repo = new StudyQuestionsRepository();

    [HttpPost("add")]
    public StudyQuestions AddStudyQuestion(StudyQuestions study)
    {
      StudyQuestions newStudyQuestion = new StudyQuestions
      {
        Id = study.Id,
        Question = study.Question,
        Answer = study.Answer

  };
      return repo.AddStudyQuestion(newStudyQuestion);
    }

    [HttpGet()]
    public List<StudyQuestions> GetAll()
    {
      return repo.GetAllStudyQuestions();
    }

    [HttpGet("{id}")]
    public StudyQuestions GetById(int id)
    {
      return repo.FindById(id);
    }

    [HttpPost("delete/{id}")]
    public HttpResponseMessage DeleteById(int id)
    {
      try
      {
        if (repo.DeleteById(id) == true)
        {
          return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
        else
        {
          return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
      }
      catch (Exception ex)
      {
        return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
      }
    }
    [HttpPost("update")]
    public HttpResponseMessage UpdateStudyQuestions(int id, string question, string answer)
    {
      StudyQuestions studyQuestionsToUpdate = new StudyQuestions
      {
        Id = id,
        Question = question,
        Answer = answer
      };

      try
      {
        if (repo.UpdateStudyQuestions(studyQuestionsToUpdate) == true)
        {
          return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
        else
        {
          return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
      }
      catch (Exception ex)
      {
        return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
      }
    }
  }
}
