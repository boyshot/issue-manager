using System;
using System.Threading.Tasks;

using WebIssueManagementApp.Data;
using WebIssueManagementApp.Interface;
using WebIssueManagementApp.Models;
using WebIssueManagementApp.Repositories;

namespace WebIssueManagementApp
{
  public class UnitOfWork : IUnitOfWork 
  {
    private readonly ManagementIssueContext _context;

    public UnitOfWork(ManagementIssueContext context)
    {
      _context = context;
    }

    public async Task Save()
    {
      await _context.SaveChangesAsync();
    }

    private bool disposed = false;

    public IRepository<User> UserRepository
    {
      get
      {
        if (userRepository == null)
          userRepository = new UserRepository(_context);

        return userRepository;
      }
    }
    private IRepository<User> userRepository = null;

    public IRepository<Issue> IssueRepository
    {
      get
      {
        if (issueRepository == null)
          issueRepository = new IssueRepository(_context);

        return issueRepository;
      }
    }
    private IRepository<Issue> issueRepository = null;

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
      }
      this.disposed = true;
    }

    public virtual void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
