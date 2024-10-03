using System.ComponentModel.DataAnnotations;


public class UserModel
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}

