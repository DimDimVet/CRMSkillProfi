using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPICRMSkillProfi.Models
{
    public class CustomUserValidator : IUserValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> _manager, User _user)
        {
            List<IdentityError> _errors = new List<IdentityError>();

            if (_user.Email.ToLower().EndsWith("@primer.com"))
            {
                _errors.Add(new IdentityError
                {
                    Description = "Данный домен находится в спам-базе. Выберите другой почтовый сервис"
                });
            }
            if (_user.UserName.Contains("primer"))
            {
                _errors.Add(new IdentityError
                {
                    Description = "Ник пользователя не должен содержать слово 'primer'"
                });
            }
            return Task.FromResult(_errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(_errors.ToArray()));
        }
    }
}
