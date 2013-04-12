using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtcAlarm.Model
{
    using Ninject;

    public partial class SqlRepository : IRepository
    {
        [Inject]
        public BtcAlertDbDataContext Db { get; set; }
    }
}
