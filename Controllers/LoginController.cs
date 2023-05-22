using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebIssueManagementApp.Interface;
using WebIssueManagementApp.Models;
using WebIssueManagementApp.ViewModel;

namespace WebIssueManagementApp.Controllers
{
  public class LoginController : Controller
  {
    private IUnitOfWork unitOfWork { get; set; }
    private IRepository<User> userRepository { get; set; }

    public LoginController(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
      this.userRepository = this.unitOfWork.UserRepository;
    }

    [HttpGet("login/user")]
    [AllowAnonymous]
    public ActionResult UserLogin()
    {
      if (HttpContext.User.Identity.IsAuthenticated)
        return RedirectToAction("Index", "Home");

      return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel userLogin, string returnUrl)
    {
      if (HttpContext.User.Identity.IsAuthenticated)
        return RedirectToAction("Index", "Home");


      if (!ModelState.IsValid)
      {
        TempData["Message"] = "Invalid data to login!";
        return RedirectToAction("UserLogin");
      }

      var users = await userRepository.Get(u => u.Email == userLogin.Email
      && u.Password == userLogin.Password);

      if (users?.Any() == true)
      {
        await CreateCookie(users);

        if (!string.IsNullOrWhiteSpace(returnUrl)) return Redirect(returnUrl);

        return RedirectToAction("Index", "Home");
      }

      TempData["Message"] = "Invalid credentials!";
      return RedirectToAction("UserLogin");
    }

    private async Task CreateCookie(IEnumerable<User> users)
    {
      var userClaims = new List<Claim>()
        {
            //define o cookie
            new Claim(ClaimTypes.Name, users.FirstOrDefault().Name),
            new Claim(ClaimTypes.Email, users.FirstOrDefault().Email),
            new Claim(ClaimTypes.PrimarySid, users.FirstOrDefault().Id.ToString()),
        };

      //cria o cookie
      await HttpContext.SignInAsync(
        new ClaimsPrincipal(
          new[] { new ClaimsIdentity(userClaims, "User") }));
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
      await HttpContext.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }
  }
}
