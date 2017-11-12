using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Flags]
    public enum OrderStatus
    {
        [Description("Выполнен")]
        Complete = 1,
        [Description("Отменен")]
        Canceled = 2,
        [Description("В процессе (не оплачено)")]
        InProgressNotPaid = 3,
        [Description("В процессе (оплачено)")]
        InProgressPaid = 4
    }
}
