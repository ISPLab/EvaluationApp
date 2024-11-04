namespace App;
public class UserDto : User
{
    public bool IsActive { get; set; }
    public string? Token { get;  set; }
}