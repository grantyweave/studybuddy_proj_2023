using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using studyBuddy_API_2023.Models;


namespace studyBuddy_API_2023.DAL
{
  public class StudyContext : DbContext
  {
    // Two constructors, first one is empty
    public StudyContext()
    {

    }

    // Second one injects the context options
    public StudyContext(DbContextOptions options) : base(options)
    {

    }

    // Create the table based off the model
    public DbSet<StudyQuestion> StudyQuestions { get; set; }
    public DbSet<FavoriteQuestion> FavoriteQuestions { get; set; }

    private static IConfigurationRoot _configuration;

    // Set the configuration to use the JSON file for the connection string
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        _configuration = builder.Build();
        string cnstr = _configuration.GetConnectionString("StudyDb");
        optionsBuilder.UseSqlServer(cnstr);
      }
    }
  }
}
