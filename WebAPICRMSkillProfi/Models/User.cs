using Microsoft.AspNetCore.Identity;

namespace WebAPICRMSkillProfi.Models
{
    public class User: IdentityUser
    {
        public string Role { get; set; }
        public string UserSurName { get; set; }
        public string UserMiddleName { get; set; }
        public string Desription { get; set; }
        public string Address { get; set; }
    }
}
