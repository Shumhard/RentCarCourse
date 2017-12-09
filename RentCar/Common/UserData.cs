using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public sealed class UserData
    {
        private UserData() { }

        private static readonly Lazy<UserData> instance = new Lazy<UserData>(() => new UserData());

        public static UserData User { get { return instance.Value; } }

        public Guid? UserGuid { get; set; }

        public bool IsAthorized { get { return UserGuid.HasValue; } }
    }
}
