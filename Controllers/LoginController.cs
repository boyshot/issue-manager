using Microsoft.AspNetCore.Authentication;
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
    public ActionResult UserLogin()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login([Bind] User userLogin, [FromRoute] string returnurl)
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
        };

        var myIdentity = new ClaimsIdentity(userClaims, "User");

        var userMain = new ClaimsPrincipal(new[] { myIdentity });

        //cria o cookie
        await HttpContext.SignInAsync(userMain);

        //Ajustar para pegar QueryString do Parâmetros

        return RedirectToAction("Index", "Issue");
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
