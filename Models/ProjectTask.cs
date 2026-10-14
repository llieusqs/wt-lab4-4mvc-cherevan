using System.ComponentModel.DataAnnotations;
namespace wt_lab4_4mvc_cherevan.Models;

public class ProjectTask
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Название обязательно")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Название: от 3 до 100 символов")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите проект")]
    public string Project { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите исполнителя")]
    public string Assignee { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите приоритет")]
    public string Priority { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; } = DateTime.Today.AddDays(7);

    public bool IsCompleted { get; set; }
}