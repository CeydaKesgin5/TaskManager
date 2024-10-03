using System.ComponentModel.DataAnnotations;

public class Task
{
    [Key]
    public int Id { get; set; }

    public int CategoryID { get; set; } //gün:1, ay:2, yıl:3

    public string TaskName { get; set; }

    public string ProjectName { get; set; }

    public string Description { get; set; }

    public string Status { get; set; } //tamamlandı, devam ediyor..

    public string PriorityLevel { get; set; } //öncelik sıralaması 1,2,3...


}

