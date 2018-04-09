using System.Collections.Generic;
using System.Diagnostics;
using HierarhyTest.Services;
using HierarhyTest.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HierarchyProgram.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      //var criteriasMatrix = new double[,]
      //{
      //  {1,7,1.0/2.0,3,3 },
      //  {1.0/7.0,1,1.0/8.0,1.0/5.0,1.0/5.0 },
      //  { 2,8,1,3,2},
      //  { 1.0/3.0,5,1.0/3.0,1,1},
      //  { 1.0/3.0,5,1.0/2.0,1,1}
      //};

      //var criteriasMatrix = new double[,]
      //{
      //  {1  , 1.0/2.0   , 1.0/5.0 },
      // {2,1,0.5},
      // {5,2,1 },
      //};

      var criteriasMatrix = new double[,]
     {
        {1  ,3,7 },
       {1.0/3.0,1,3},
       {1.0/7.0,1.0/3.0,1},
     };

      var alternative0matrix = new double[,]
      {
        { 1,1.0/3.0},
        { 3,1}
      };

      var alternative1matrix = new double[,]
      {
        { 1,5},
        { 1.0/5.0,1}
      };
      var alternative2matrix = new double[,]
      {
        { 1,1.0/2.0},
        { 2,1}
      };
      var alternative3matrix = new double[,]
{
        { 1,1},
        { 1,1}
};
      var alternative4matrix = new double[,]
{
        { 1,1.0/3.0},
        { 3,1}
};

      var list = new List<Matrix>()
      {
        new Matrix(alternative0matrix),
        new Matrix(alternative1matrix),
        new Matrix(alternative2matrix),
        new Matrix(alternative3matrix),
        new Matrix(alternative4matrix)
      };

      var saatiService = new SaatiService();
      var result = saatiService.DetermineTheBestAlternative(new Matrix(criteriasMatrix), list, 2);

      return View();
    }

    public IActionResult Error()
    {
      ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
      return View();
    }
  }
}
