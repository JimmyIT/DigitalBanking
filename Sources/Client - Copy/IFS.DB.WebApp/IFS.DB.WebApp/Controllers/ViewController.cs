using Microsoft.AspNetCore.Mvc;

namespace IFS.DB.WebApp.Controllers;

[Route("[controller]/[action]")]
public class ViewController : Controller
{
    
    [Route("~/mobile-recommendation")]
    public IActionResult Mobile()
    {
        return View("Mobile");
    }
}