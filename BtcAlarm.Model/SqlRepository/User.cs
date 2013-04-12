using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtcAlarm.Model
{
    public partial class SqlRepository
    {
        public IQueryable<User> Users
        {
            get
            {
                return Db.Users;
            }
        }

        public bool CreateUser(User instance)
        {
            if (instance.UserId == 0)
            {
                instance.IsPaid = false;
                instance.RegistrationDate = DateTime.UtcNow;
                instance.Token = User.GetToken();
                Db.Users.InsertOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUser(User instance)
        {
            User cache = this.Db.Users.FirstOrDefault(p => p.UserId == instance.UserId);
            if (cache != null)
            {
                cache.IsComplete = instance.IsComplete;
                cache.IsPaid = instance.IsPaid;
                cache.Password = instance.Password;
                cache.ActivatedDate = instance.ActivatedDate;
                cache.Name = instance.Name;
                Db.Users.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveUser(int userId)
        {
            User instance = this.Db.Users.FirstOrDefault(p => p.UserId == userId);
            if (instance != null)
            {
                Db.Users.DeleteOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public User GetUser(string email)
        {
            return Db.Users.FirstOrDefault(p => String.Compare(p.Email, email, StringComparison.OrdinalIgnoreCase) == 0);
        }

        public User Login(string email, string password)
        {
            return Db.Users.FirstOrDefault(p => String.Compare(p.Email, email, StringComparison.OrdinalIgnoreCase) == 0 && p.Password == password);
        }
    }
}
