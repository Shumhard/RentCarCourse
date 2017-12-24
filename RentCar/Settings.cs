using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public static class Settings
    {
        private static string _attachedFiles;

        public static string AttachedFiles
        {
            get
            {
                if (string.IsNullOrEmpty(_attachedFiles))
                {
                    _attachedFiles = ConfigurationSettings.AppSettings["AttachedFiles"];
                }

                return _attachedFiles;
            }
        }
    }
}
