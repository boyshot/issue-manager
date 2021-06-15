using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebIssueManagementApp.Data;
using WebIssueManagementApp.Interface;
using WebIssueManagementApp.Models;

namespace WebIssueManagementApp.Controllers
{
  public class IssueController : Controller
  {
    private IUnitOfWork unitOfWork { get; set; }
    private IRepository<Issue> issueRepository { get; set; }

    private int idUniqueUser = 1;

    public IssueController(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
      this.issueRepository = this.unitOfWork.IssueRepository;
    }

    public async Task<IActionResult> Index(string txtFind)
    {
      IEnumerable<Issue> issues = null;

      if (!string.IsNullOrWhiteSpace(txtFind))
        issues = await issueRepository.Get(x => x.IdUser == idUniqueUser &&
                                               (x.UrlIssue.Contains(txtFind) ||
                                                x.Abstract.Contains(txtFind)),
                                                y => y.OrderBy(z => z.DateBegin));

      if (issues == null || issues?.Count() <= 0)
        issues = await issueRepository.Get(x => x.IdUser == idUniqueUser,
          y => y.OrderBy(z => z.DateBegin), take: 10);

      return View(issues);
    }

    // GET: Issues/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
        return NotFound();

      var issue = await issueRepository.Get(x => x.IdUser == idUniqueUser && x.Id == id.Value);

      if (issue == null)
        return NotFound();

      return View(issue.FirstOrDefault());
    }

    // GET: Issues/Create
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DataBase,Server,UrlIssue,DateBegin,DateEnd,Text,Abstract,IdUser,Id")] Issue issue)
    {
      if (ModelState.IsValid)
      {
        issue.IdUser = idUniqueUser;
        issueRepository.Insert(issue);
        await unitOfWork.Save();
        return RedirectToAction(nameof(Index));
      }
      return View(issue);
    }

    // GET: Issues/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
        return NotFound();

      var issue = await issueRepository.Get(
        x => x.IdUser == idUniqueUser && x.Id == id.Value);

      if (issue == null)
        return NotFound();

      return View(issue.FirstOrDefault());
    }

    // POST: Issues/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("DataBase,Server,UrlIssue,DateBegin,DateEnd,Text,Abstract,Id")] Issue issue)
    {
      if (id != issue.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          issue.IdUser = idUniqueUser;
          issueRepository.Update(issue);
          await unitOfWork.Save();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!IssueExists(issue.Id).Result)
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(issue);
    }

    // GET: Issues/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
        return NotFound();

      var issue = await issueRepository.Get(x => x.IdUser == idUniqueUser && x.Id == id.Value);

      if (issue == null)
        return NotFound();

      return View(issue.FirstOrDefault());
    }

    // POST: Issues/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      issueRepository.Delete(id);
      await unitOfWork.Save();
      return RedirectToAction(nameof(Index));
    }

    private async Task<bool> IssueExists(int id)
    {
      var issue = await issueRepository.Get(x => x.IdUser == idUniqueUser && x.Id == id);

      return issue != null;
    }
  }
}
