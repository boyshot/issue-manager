using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    private IRepository<Attachment> attachmentRepository { get; set; }
    
    private int idUniqueUser = 1;

    public IssueController(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
      this.issueRepository = this.unitOfWork.IssueRepository;
      this.attachmentRepository = this.unitOfWork.AttachmentRepository;
    }

    public async Task<IActionResult> Index(string txtFind)
    {
      IEnumerable<Issue> issues = null;

      if (!string.IsNullOrWhiteSpace(txtFind))
        issues = await issueRepository.Get(x => x.IdUser == idUniqueUser &&
                                               (x.UrlIssue.Contains(txtFind) ||
                                                x.Abstract.Contains(txtFind) ||
                                                x.Text.Contains(txtFind)),
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

    public async Task<IActionResult> Attachment(int? id)
    {
      if (id == null)
        return NotFound();

      var listIssues = await issueRepository.Get(x => x.IdUser == idUniqueUser && x.Id == id.Value);

      var issue = listIssues?.FirstOrDefault();

      if (issue == null)
        return NotFound();

      var listAttach = await attachmentRepository.Get(x => x.IdIssue == issue.Id);

      if (listAttach != null)
        issue.ListAttachment = listAttach.ToList();
      else
        issue.ListAttachment = new List<Attachment>();

      return View(issue);
    }

    public async Task<IActionResult> PostAttachment(int id, List<IFormFile> attachments)
    {
      if (attachments?.Any() == true)
      {
        foreach (var attach in attachments)
        {
          using (var memoryStream = new MemoryStream())
          {
            await attach.CopyToAsync(memoryStream);

            var newAttach = new Attachment();
            newAttach.IdIssue = id;
            newAttach.FileName = attach.FileName;
            newAttach.Content = memoryStream.ToArray();

            this.attachmentRepository.Insert(newAttach);
          }
        }

        await unitOfWork.Save();
      }

      return RedirectToAction(nameof(Attachment), new { id = id });
    }

    public async Task<IActionResult> DeleteAttachment(int IdIssue, int IdAttach)
    {
      this.attachmentRepository.Delete(IdAttach);
      await unitOfWork.Save();
      return RedirectToAction(nameof(Attachment), new { id = IdIssue });
    }

    public async Task<IActionResult> DownloadAttachment(int IdIssue, int IdAttach)
    {
      return RedirectToAction(nameof(Attachment), new { id = IdIssue });
    }
  }
}
