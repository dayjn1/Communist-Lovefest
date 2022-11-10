/**
* --------------------------------------------------------------------------- 
* File name: HomeController.cs
* Project name: 404 Industries BucHunt
* --------------------------------------------------------------------------- 
* Author’s name and email: Dante Hays, haysdc@etsu.edu
* Creation Date: Oct 27, 2022
* Last modified: Dante Hays haysdc@etsu.edu Nov 02, 2022
* --------------------------------------------------------------------------- 
*/

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Team_3_BucHunt_WebApp.Models;

namespace Team_3_BucHunt_WebApp.Controllers;

/**
* Class Name: HomeController <br>
* Class Purpose: Holds the logic for the Home page<br>
* <hr>
* Date created: Oct 27, 2022 <br>
* Date last modified: Nov 02, 2022 
* @author Dante Hays
*/

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    } //End public HomeController(ILogger<HomeController> logger)

/**
* Method Name: Index <br>
* Method Purpose: Returns the view of the Home page <br>
* <hr>
* Date created: Oct 27, 2022 <br>
* Date last modified: Nov 03, 2022 <br>
* <hr>
* Notes on specifications, special algorithms, and assumptions: N/A
* <hr> 
* @returns View()
*/
    public IActionResult Index()
    {
        return View();
    } //End public IActionResult Index()

/**
* Method Name: JoinHunt <br>
* Method Purpose: Returns the view of the JoinHunt page <br>
* <hr>
* Date created: Oct 27, 2022 <br>
* Date last modified: Nov 03, 2022 <br>
* <hr>
* Notes on specifications, special algorithms, and assumptions: N/A
* <hr> 
* @returns View()
*/
    public IActionResult JoinHunt()
    {
        return View();
    } //End public IActionResult JoinHunt()

/**
* Method Name: Error <br>
* Method Purpose: Returns the view of the Error page when an error is encountered <br>
* <hr>
* Date created: Oct 27, 2022 <br>
* Date last modified: Oct 27, 2022 <br>
* <hr>
* Notes on specifications, special algorithms, and assumptions: N/A
* <hr> 
* @returns View()
*/
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    } //End public IActionResult Error()

} //End public class HomeController : Controller

