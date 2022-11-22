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
    public Models.Task task = new Models.Task();
    private BucHuntContext db = new BucHuntContext();
    public List<Models.Task> taskList = new List<Models.Task>();
    //List<User> teams = new List<User>();
    //List<List<User>> teamList = new List<List<User>>();

    private readonly BucHuntContext _context;

    public HuntController(BucHuntContext context)
    {
        _context = context;
        taskList = _context.Tasks.ToList();
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
        ViewBag.taskList = taskList;
        return View();
    }

    /// <summary>
    /// Returns Hunt page if code is correct will redirect if incorrect and will display invalid code.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Index(User user)
    {
        user.OpenDB(); //Generates the list of Users from the database
        task.OpenDB(); //Generates the list of Tasks from the database
        bool correct = true;
        ViewBag.taskList = taskList;


        foreach (User u in user.usersList)
        {
            if (user.AccessCode == u.AccessCode)
            {
                correct = true; 
                break;
            }
        }
        if (correct)
        {
            return View();
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
* Date last modified: Nov 15, 2022 <br>
* <hr>
* Notes on specifications, special algorithms, and assumptions: N/A
* <hr> 
* @returns View()
*/
    public IActionResult LeaderBoard()
    { 
        return View();
    }   //End public IActionResult LeaderBoard()

} //End public class HuntController : Controller


