using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebIssueManagementApp.Data;
using WebIssueManagementApp.Models;

namespace WebIssueManagementApp.Repositories
{
  public class AttachmentRepository : RepositoryBase<Attachment>
  {
    public AttachmentRepository(ManagementIssueContext context) : base(context) { }
  }
}
