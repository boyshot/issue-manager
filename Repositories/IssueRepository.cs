using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebIssueManagementApp.Data;
using WebIssueManagementApp.Models;

namespace WebIssueManagementApp.Repositories
{
  public class IssueRepository : RepositoryBase<Issue>
  {
    public IssueRepository(ManagementIssueContext context) : base(context) { }
  }
}
