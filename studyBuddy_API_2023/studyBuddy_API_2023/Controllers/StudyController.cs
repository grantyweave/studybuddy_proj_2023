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

  }
}
