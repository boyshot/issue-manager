using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebIssueManagementApp.Data;
using WebIssueManagementApp.Models;

namespace WebIssueManagementApp.Repositories
{
  public class UserRepository : RepositoryBase<User>
  {
    public UserRepository(ManagementIssueContext context) : base(context) { }
  }
}
