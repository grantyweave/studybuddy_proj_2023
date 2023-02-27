using studyBuddy_API_2023.DAL;
using studyBuddy_API_2023.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
  options.AddPolicy(name: "CorsPolicy",
    builder =>
    {
      builder.SetIsOriginAllowed(origin => true);
      builder.AllowAnyMethod();
      builder.AllowAnyHeader();
      builder.AllowCredentials();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();

using (var context = new StudyContext())
{
  context.Database.EnsureCreated();

  var testBlog = context.StudyQuestions.FirstOrDefault(b => b.Question == "NaCl is more commonly known as");
  if (testBlog == null)
  {
    context.StudyQuestions.AddRange(
      new[]
      {
      new StudyQuestion { Question = "NaCl is more commonly known as", Answer = "Salt" },
      new StudyQuestion { Question = "If there are three quarts of gas in a gallon container, how full is the container?", Answer = "75%" },
      new StudyQuestion { Question = "Observe most nearly means", Answer = "Watch" }
      });
  }

  context.SaveChanges();
}

app.Run();
