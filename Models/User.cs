using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIssueManagementApp.Models
{
  /// <summary>
  /// User context class
  /// </summary>
  public class User : ModelBase
  {
    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
  }
}
