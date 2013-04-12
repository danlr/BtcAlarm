using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtcAlarm.Model
{
    public partial class SqlRepository
    {
        public IQueryable<UserRole> UserRoles
        {
            get
            {
                return Db.UserRoles;
            }
        }

        public bool CreateUserRole(UserRole instance)
        {
            if (instance.Id == 0)
            {
                Db.UserRoles.InsertOnSubmit(instance);
                Db.UserRoles.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUserRole(UserRole instance)
        {
            UserRole cache = this.Db.UserRoles.FirstOrDefault(p => p.Id == instance.Id);
            if (cache != null)
            {
                cache.RoleId = instance.RoleId;
                cache.UserId = instance.UserId;
                Db.UserRoles.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveUserRole(int idUserRole)
        {
            UserRole instance = this.Db.UserRoles.FirstOrDefault(p => p.Id == idUserRole);
            if (instance != null)
            {
                Db.UserRoles.DeleteOnSubmit(instance);
                Db.UserRoles.Context.SubmitChanges();
                return true;
            }

            return false;
        }

    }
}
