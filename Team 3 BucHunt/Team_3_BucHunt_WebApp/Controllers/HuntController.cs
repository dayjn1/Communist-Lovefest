/**
* --------------------------------------------------------------------------- 
* File name: HuntController.cs
* Project name: 404 Industries BucHunt
* --------------------------------------------------------------------------- 
* Author’s name and email: Dante Hays, haysdc@etsu.edu
* Creation Date: Nov 01, 2022
* Last modified: Dante Hays haysdc@etsu.edu Nov 02, 2022
* --------------------------------------------------------------------------- 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Team_3_BucHunt_WebApp.Models;

namespace Team_3_BucHunt_WebApp.Controllers;

/**
* Class Name: HuntController <br>
* Class Purpose: Holds the logic for the Hunt page<br>
* <hr>
* Date created: Oct 27, 2022 <br>
* Date last modified: Nov 02, 2022 
* @author Dante Hays
*/

public class HuntController : Controller
{
    public Models.User user = new Models.User();
    private readonly List<Models.User> allUsers;
    private readonly List<Models.Task> taskList;
    private readonly List<Models.Location> locations;
    //public Models.Task task = new Models.Task();
    //private BucHuntContext db = new BucHuntContext();
    //List<User> teams = new List<User>();
    //List<List<User>> teamList = new List<List<User>>();


    /* This is used to create a "local" connection to the 
       database that can be reused for different purposes.
        it takes advantage of the database connection string in
        the appsettings.json file and the builder.Services settings
        in the Program.cs file > these settings allow for one connection
        established to the database on load of the project that can be
        called at any point from the controllers using the local var below
        - Hannah*/
    private readonly BucHuntContext _context;

    //nothing is calling this yet, but _context is still getting a connection to the database? - Hannah (I need to remind myself the details of how this works)
    public HuntController(BucHuntContext context)
    {
        _context = context;
        allUsers = _context.Users.ToList(); //initializing this here allows for the same functionality as calling it in the Index method below
        taskList = _context.Tasks.ToList(); //db call every time -- possibly tied to the page reloading after the button is hit
        locations = _context.Locations.ToList();                                    
    }

    /**
* Method Name: Index <br>
* Method Purpose: Returns the view of the Hunt page <br>
* <hr>
* Date created: Oct 27, 2022 <br>
* Date last modified: Nov 03, 2022 <br>
* <hr>
* Notes on specifications, special algorithms, and assumptions: N/A
* <hr> 
* @returns View()
*/

    [HttpGet]
    public ActionResult Index()
    {
        ViewBag.locations = locations;
        ViewBag.taskList = taskList;
            return View(model: HttpContext.Session.GetString("currentUser"));
    }

    /// <summary>
    /// Returns Hunt page if code is correct will redirect if incorrect and will display invalid code.
    /// </summary>
    /// 
    /// NOTES: These should probably 
    /// 
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Index(User user)
    {
        //List<Models.User> allUsers = _context.Users.ToList();
        //user.OpenDB(); //Generates the list of Users from the database
        //task.OpenDB(); //Generates the list of Tasks from the database
        bool correct = true;
        ViewBag.taskList = taskList;
        ViewBag.locations = locations;

        foreach (User u in allUsers)
        {
            if (user.AccessCode == u.AccessCode)
            {
                HttpContext.Session.SetString("currentUser", u.Email);
                correct = true;
                break;
            }
        }
        if (correct)
        {
            List<Models.Task> taskList = _context.Tasks.ToList();
            ViewBag.taskList = taskList;
            return View(model: HttpContext.Session.GetString("currentUser"));
        }
        else
        {

            TempData["Message"] = "Invalid Code";
            return RedirectToAction("JoinHunt", "Home");
        }
    } //End public IActionResult Index()

/**
* Method Name: LeaderBoard <br>
* Method Purpose: Returns the view of the Hunt page <br>
* <hr>
* Date created: Nov 15, 2022 <br>
* Date last modified: Nov 29, 2022 <br>
* <hr>
* Notes on specifications, special algorithms, and assumptions: N/A
* <hr> 
* @returns View()
*/
    public IActionResult LeaderBoard()
    {
        ViewBag.allUsers = allUsers;
        return View();
    }   //End public IActionResult LeaderBoard()

    /**
* Method Name: AnswerForm <br>
* Method Purpose: Returns the view answer form for a question <br>
* <hr>
* Date created: Nov 26,2022 <br>
* Date last modified: Nov 28,2022 <br>
* <hr>
* Notes on specifications, special algorithms, and assumptions: N/A
* <hr> 
* @returns View()
*/
    public IActionResult AnswerForm(int taskId, bool incorrect)
    {
        string Question = taskList[taskId].Question;
        //return PartialView(_TaskAnswerForm, Question, incorrect);
         
        //(The incorrect bool tracks if they got the question wrong so
        // a message can be displayed accordingly)
 
        return RedirectToAction("Index", "Hunt");
    }


    /**
    * Method Name: CheckAnswer <br>
    * Method Purpose: Checks a passed answer to see if it is correct <br>
    * <hr>
    * Date created: Nov 26,2022 <br>
    * Date last modified: Nov 28,2022 <br>
    * <hr>
    * Notes on specifications, special algorithms, and assumptions: N/A
    * <hr> 
    * @returns View()
*/
    public IActionResult CheckAnswer(Team_3_BucHunt_WebApp.Models.Task task)
    {       
        string correctAnswer = "";

        foreach(var t in taskList)
        {
            if (t.TaskId == task.TaskId)
                correctAnswer = t.Answer;
        }

        // either pull the task from the list so they can answer again
        // or pass a var to make it inaccessible
        if (task.Answer == correctAnswer)
        {
            TempData["Message"] = "Correct!";
            return RedirectToAction("Index", "Hunt");
        }
        else
        {
            //return RedirectToAction("AnswerForm", "Hunt", false);
            TempData["Message"] = "Incorrect Answer";
            return RedirectToAction("Index", "Hunt");
        }
        
    }

} //End public class HuntController : Controller


