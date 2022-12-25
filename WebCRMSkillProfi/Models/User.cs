using System;
using System.Collections.Generic;
using WebCRMSkillProfi.Interfaces;

namespace WebCRMSkillProfi.Models
{
    public class User : IUser
    {
        public enum SortedCriterion
        {
            Id,
            UserSurName,
            UserName,
            UserMiddleName,
            Email,
            PhoneNumber,
            Address,
            Role
        }
        public string Id { get; set; }
        public string UserSurName { get; set; }
        public string UserName { get; set; }
        public string UserMiddleName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Desription { get; set; }

        private class SortId : IComparer<User>
        {
            public int Compare(User x, User y)
            {
                User X = (User)x;
                User Y = (User)y;

                return String.Compare(X.Id, Y.Id);
            }
        }
        private class SortUserSurName : IComparer<User>
        {
            public int Compare(User x, User y)
            {
                User X = (User)x;
                User Y = (User)y;

                return String.Compare(X.UserSurName, Y.UserSurName);
            }
        }
        private class SortUserName : IComparer<User>
        {
            public int Compare(User x, User y)
            {
                User X = (User)x;
                User Y = (User)y;

                return String.Compare(X.UserName, Y.UserName);
            }
        }
        private class SortUserMiddleName : IComparer<User>
        {
            public int Compare(User x, User y)
            {
                User X = (User)x;
                User Y = (User)y;

                return String.Compare(X.UserMiddleName, Y.UserMiddleName);
            }
        }
        private class SortEmail : IComparer<User>
        {
            public int Compare(User x, User y)
            {
                User X = (User)x;
                User Y = (User)y;

                return String.Compare(X.Email, Y.Email);
            }
        }
        private class SortPhoneNumber : IComparer<User>
        {
            public int Compare(User x, User y)
            {
                User X = (User)x;
                User Y = (User)y;

                return String.Compare(X.PhoneNumber, Y.PhoneNumber);
            }
        }
        private class SortAddress : IComparer<User>
        {
            public int Compare(User x, User y)
            {
                User X = (User)x;
                User Y = (User)y;

                return String.Compare(X.Address, Y.Address);
            }
        }
        private class SortRole : IComparer<User>
        {
            public int Compare(User x, User y)
            {
                User X = (User)x;
                User Y = (User)y;

                return String.Compare(X.Role, Y.Role);
            }
        }
        public static IComparer<User> SortedBy(SortedCriterion _criterion)
        {
            switch (_criterion)
            {
                case SortedCriterion.Id:
                    return new SortId();
                case SortedCriterion.UserSurName:
                    return new SortUserSurName();
                case SortedCriterion.UserName:
                    return new SortUserName();
                case SortedCriterion.UserMiddleName:
                    return new SortUserMiddleName();
                case SortedCriterion.Email:
                    return new SortEmail();
                case SortedCriterion.PhoneNumber:
                    return new SortPhoneNumber();
                case SortedCriterion.Address:
                    return new SortAddress();
                case SortedCriterion.Role:
                    return new SortRole();

                default:
                    return null;
            }
        }
    }
}
