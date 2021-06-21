using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIssueManagementApp.Models
{
  public class Attachment : ModelBase
  {
    public int IdIssue { get; set; }

    public string FileName { get; set; }

    public string ContentType { get; set; }

    public byte[] Content { get; set; }
  }
}
