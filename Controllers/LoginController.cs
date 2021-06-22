using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebIssueManagementApp.Interface;
using WebIssueManagementApp.Models;

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

    [HttpGet]
    [AllowAnonymous]
    public ActionResult UserLogin()
    {
      return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(User userLogin, string returnUrl)
    {
      var users = await userRepository.Get(u => u.Email == userLogin.Email
      && u.Password == userLogin.Password);

      if (users?.Any() == true)
      {
        var userClaims = new List<Claim>()
        {
            //define o cookie
            new Claim(ClaimTypes.Name, users.FirstOrDefault().Name),
            new Claim(ClaimTypes.Email, users.FirstOrDefault().Email),
            new Claim(ClaimTypes.PrimarySid, users.FirstOrDefault().Id.ToString()),
        };

        var myIdentity = new ClaimsIdentity(userClaims, "User");

        var userMain = new ClaimsPrincipal(new[] { myIdentity });

        //cria o cookie
        await HttpContext.SignInAsync(userMain);

        if (!string.IsNullOrWhiteSpace(returnUrl))
          return Redirect(returnUrl);

        return RedirectToAction("Index", "Home");
      }
      ViewBag.Message = "Credenciais inválidas...";

      return RedirectToAction("UserLogin", "Login");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
      await HttpContext.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }
  }
}
