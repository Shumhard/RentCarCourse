using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEventArgs
{
    public class AuthorizedEventArgs : EventArgs
    {
        public bool IsAuthorized { get; set; }

        public AuthorizedEventArgs(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }
    }
}
