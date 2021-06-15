using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIssueManagementApp.Models
{
  public class Attachment : ModelBase
  {
    public string IdIssue { get; set; }

    public string Archive { get; set; }
  }
}
