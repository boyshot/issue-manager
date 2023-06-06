using System.ComponentModel.DataAnnotations;
using System;

namespace WebIssueManagementApp.ViewModel
{
  public class IssueViewModel
  {
    public int Id { get; set; }

   
    public string UrlIssue { get; set; }

    [MaxLength(20)]
    public string DataBase { get; set; }

    [MaxLength(30)]
    public string Server { get; set; }

    [Required(ErrorMessage = "The field begin date must be informed!")]
    [DataType(DataType.Date)]
    public DateTime DateBegin { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DateEnd { get; set; }

    public string Text { get; set; }

    [MaxLength(100)]
    [Required(ErrorMessage = "The field abstract must be informed!")]
    public string Abstract { get; set; }

    public int IdUser { get; set; }
  }
}
