using System;

namespace MyPortfolioApp.Models;

public class HomePageModel
{
 public AppSetting? AppSettings { get; set; }
 public IEnumerable<Social>? Socials{get;set;}
 public IEnumerable<Job>? Jobs { get; set; }
 public IEnumerable<Category>? Categories { get; set; }
 public IEnumerable<Location>? Locations { get; set; }
 public IEnumerable<Education>? Educations { get; set; }


 

}
