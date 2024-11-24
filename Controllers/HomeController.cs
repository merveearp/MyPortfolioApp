using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioApp.Data;
using MyPortfolioApp.Models;

namespace MyPortfolioApp.Controllers;

public class HomeController : Controller
{
  
  private readonly IRepository<AppSetting> _appSettingRepository;
  private readonly IRepository<Social> _socialRepository;
  private readonly IRepository<Job> _jobRepository;
  private readonly IRepository<Category> _categoryRepository;
  private readonly IRepository<Education> _educationRepository;
  private readonly IRepository<Location> _locationRepository;

    public HomeController(
        IRepository<AppSetting> appSettingRepository, 
        IRepository<Social> socialRepository,
        IRepository<Job> jobRepository,
        IRepository<Category> categoryRepository,
        IRepository<Education> educationRepository,
        IRepository<Location> locationRepository
        
    )
    {
        _appSettingRepository = appSettingRepository;
        _socialRepository = socialRepository;
        _jobRepository = jobRepository;
        _categoryRepository = categoryRepository;
        _educationRepository=educationRepository;
        _locationRepository=locationRepository;



    }

    public async Task<IActionResult> Index()
    {   
        var appSettings = (await _appSettingRepository.GetAllAsync()).First();
        var socials = await _socialRepository.GetAllAsync();
        var jobs = await _jobRepository.GetAllAsync();
        var categories = await _categoryRepository.GetAllAsync();
        var educations = await _educationRepository.GetAllAsync();
        var locations = await _locationRepository.GetAllAsync();
        HomePageModel model=new(){

            AppSettings= appSettings,
            Socials=socials,
            Jobs=jobs,
            Categories=categories,
            Educations=educations,
            Locations=locations
        };

        return View(model);
    }

}

