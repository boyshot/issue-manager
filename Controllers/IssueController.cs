﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebIssueManagementApp.Interface;
using WebIssueManagementApp.Models;
using WebIssueManagementApp.Repositories;
using WebIssueManagementApp.ViewModel;

namespace WebIssueManagementApp.Controllers
{
  [Authorize]
  public class IssueController : Controller
  {
    private IUnitOfWork unitOfWork { get; set; }
    private IRepository<Issue> issueRepository { get; set; }
    private IRepository<Attachment> attachmentRepository { get; set; }

    public IssueController(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
      this.issueRepository = this.unitOfWork.IssueRepository;
      this.attachmentRepository = this.unitOfWork.AttachmentRepository;
    }

    public async Task<IActionResult> Index(string txtFind)
    {
      IEnumerable<Issue> issues = null;

      int idUniqueUser = GetIdUserSession();

      if (!string.IsNullOrWhiteSpace(txtFind))
        issues = await issueRepository.Get(x => x.IdUser == idUniqueUser &&
                                               (x.UrlIssue.Contains(txtFind) ||
                                                x.Abstract.Contains(txtFind) ||
                                                x.Text.Contains(txtFind)),
                                                y => y.OrderBy(z => z.DateBegin));

      if (issues == null || issues?.Count() <= 0)
        issues = await issueRepository.Get(x => x.IdUser == idUniqueUser,
          y => y.OrderByDescending(z => z.DateBegin), take: 6);


      if (issues?.Count() > 0)
      {
        var VmIssues = new List<IssueViewModel>();

        foreach (Issue issue in issues)
        {
          VmIssues.Add(issue.ToViewModel());
        }

        return View(VmIssues);
      }

      return View(new List<IssueViewModel>());
    }

    // GET: Issues/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
        return NotFound();

      int idUniqueUser = GetIdUserSession();

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

    // POST: Issues/Create
    // create a new issue
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IssueViewModel issueViewModel)
    {
      int idUniqueUser = GetIdUserSession();

      if (ModelState.IsValid && idUniqueUser > 0)
      {
        var issue = new Issue();
        issue.IdUser = idUniqueUser;
        issue.UrlIssue = issueViewModel.UrlIssue;
        issue.Abstract = issueViewModel.Abstract;
        issue.Text = issueViewModel.Text;
        issue.DateBegin = issueViewModel.DateBegin;
        issue.DateEnd = issueViewModel.DateEnd;
        issue.Server = issueViewModel.Server;
        issue.DataBase = issueViewModel.DataBase;

        issueRepository.Insert(issue);
        await unitOfWork.Save();

        return RedirectToAction(nameof(Index));
      }
      return View(issueViewModel);
    } 

    // GET: Issues/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
        return NotFound();

      int idUniqueUser = GetIdUserSession();

      var issue = await issueRepository.Get(
        x => x.IdUser == idUniqueUser && x.Id == id.Value);

      if (issue == null)
        return NotFound();

      return View(issue.FirstOrDefault()?.ToViewModel());
    }

    // POST: Issues/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, IssueViewModel issueViewModel)
    {
      if (id != issueViewModel.Id)
      {
        return NotFound();
      }

      int idUniqueUser = GetIdUserSession();

      if (ModelState.IsValid && idUniqueUser > 0)
      {
        try
        {
          var issue = issueRepository.GetById(idUniqueUser).Result;
          issue.UrlIssue = issueViewModel.UrlIssue;
          issue.Abstract = issueViewModel.Abstract;
          issue.Text = issueViewModel.Text;
          issue.DateBegin = issueViewModel.DateBegin;
          issue.DateEnd = issueViewModel.DateEnd;
          issue.Server = issueViewModel.Server;
          issue.DataBase = issueViewModel.DataBase;
          issueRepository.Update(issue);
          await unitOfWork.Save();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!IssueExists(issueViewModel.Id).Result) return NotFound();
          throw;
        }
        return RedirectToAction(nameof(Index));
      }
      return View(issueViewModel);
    }


    // GET: Issues/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
        return NotFound();

      int idUniqueUser = GetIdUserSession();

      var issue = await issueRepository.Get(x => x.IdUser == idUniqueUser && x.Id == id.Value);

      if (issue == null)
        return NotFound();

      return View(issue.FirstOrDefault().ToViewModel());
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
      int idUniqueUser = GetIdUserSession();

      var issue = await issueRepository.Get(x => x.IdUser == idUniqueUser && x.Id == id);

      return issue != null;
    }


    public async Task<IActionResult> Attachment(int? id)
    {
      if (id == null)
        return NotFound();

      int idUniqueUser = GetIdUserSession();

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

            var newAttach = new Attachment
            {
              IdIssue = id,
              FileName = attach.FileName,
              Content = memoryStream.ToArray(),
              ContentType = attach.ContentType
            };

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

    public FileResult DownloadAttachment(int IdAttach)
    {
      var attach = this.attachmentRepository.GetById(IdAttach)?.Result;

      if (attach != null)
      {
        return File(attach.Content, attach.ContentType, attach.FileName);
      }

      return null;
    }

    private int GetIdUserSession()
    {
      if (HttpContext?.User?.Identity?.IsAuthenticated == true)
      {
        var claim = HttpContext.User?.Claims.FirstOrDefault(x => x.Type.Contains("primarysid"));
        if (claim != null && !string.IsNullOrWhiteSpace(claim?.Value))
          return Convert.ToInt32(claim.Value);
      }

      return -1;
    }
  }
}
