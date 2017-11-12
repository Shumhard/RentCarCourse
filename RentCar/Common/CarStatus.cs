using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Flags]
    public enum CarStatus
    {
        [Description("Свободен")]
        Free = 1,
        [Description("Занят")]
        Busy = 2,
        [Description("Неисправен")]
        Faulty = 3,
        [Description("Тех. обслуживание")]
        Maintenance = 4
    }
}
