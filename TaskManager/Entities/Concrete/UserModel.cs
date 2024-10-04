using System.ComponentModel.DataAnnotations;
using TaskManagerClass.Core.Entities;


public class UserModel: IEntity
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}

