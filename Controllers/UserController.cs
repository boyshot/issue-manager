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
  public class UserController : Controller
  {
    private IUnitOfWork unitOfWork { get; set; }
    private IRepository<User> userRepository { get; set; }

    public UserController(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
      this.userRepository = this.unitOfWork.UserRepository;
    }

    [HttpGet("user/create")]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(User user)
    {
      if (ModelState.IsValid)
      {
        bool userExist = await UserExists(user.Email);

        if (!userExist)
        {
          userRepository.Insert(user);
          await unitOfWork.Save();
          return RedirectToAction("UserLogin", "Login");
        }

        TempData["Message"] = "User exists!";
        return RedirectToAction("Create");
      }

      TempData["Message"] = "invalid data!";
      return RedirectToAction("Create");
    }

    private async Task<bool> UserExists(string email)
    {
      var user = await userRepository.Get(x => x.Email == email);
      return user?.Any() == true;
    }
  }
}
