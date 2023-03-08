using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studyBuddy_API_2023.DAL;
using studyBuddy_API_2023.Models;
using System.Net;

namespace studyBuddy_API_2023.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FavoriteQuestionsController : ControllerBase
  {
    StudyQuestionsRepository repo = new StudyQuestionsRepository();

    [HttpPost("add")]
    public FavoriteQuestion AddFavoriteQuestion(int questionId, int userId)
    {
      FavoriteQuestion newFavoriteQuestion = new FavoriteQuestion
      {
        UserId = userId,
        QuestionId = questionId
      };
      return repo.AddFavoriteQuestion(newFavoriteQuestion);
    }

    [HttpGet()]
    public List<StudyQuestion> GetAll(int userId)
    {
      return repo.GetAllUserFavoriteQuestions(userId);
    }

    [HttpDelete()]
    public IActionResult DeleteFavoriteQuestion(int userId, int questionId)
    {
      try
      {
        repo.DeleteFavoriteQuestion(userId, questionId);
        return Ok();
      }
      catch (Exception ex)
      {
        return NotFound();
      }
    }
  }
}

