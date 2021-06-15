using System;
using System.Threading.Tasks;
using WebIssueManagementApp.Models;

namespace WebIssueManagementApp.Interface
{
  public interface IUnitOfWork : IDisposable
  {
    IRepository<User> UserRepository { get; }

    IRepository<Issue> IssueRepository { get; }

    Task Save();
  }
}
