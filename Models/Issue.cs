using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebIssueManagementApp.Models
{
  public class Issue : ModelBase
  {
    public string DataBase { get; set; }

    public string Server { get; set; }

    public string UrlIssue { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateBegin { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateEnd { get; set; }

    public string Text { get; set; }

    public string Abstract { get; set; }

    public int IdUser { get; set; }

    //public User User { get; set; }

    //public IList<Attachment> ListAttachment { get; set; }
  }
}
