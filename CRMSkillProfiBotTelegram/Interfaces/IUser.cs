namespace CRMSkillProfiBotTelegram.Interfaces
{
    public interface IUser
    {
        string Id { get; set; }
        string UserSurName { get; set; }
        string UserName { get; set; }
        string UserMiddleName { get; set; }
        string Email { get; set; }
        string PasswordHash { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string Role { get; set; }
        string Desription { get; set; }

    }
}
