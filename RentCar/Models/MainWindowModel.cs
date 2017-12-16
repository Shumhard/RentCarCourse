using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Models
{
    public class MainWindowModel
    {
        public bool IsAuthorized { get; set; }

        public List<CarModel> Cars { get; set; } 
        
        public List<ReferenceValue> CityList { get; set; }
        
        public List<ReferenceValue> MarkList { get; set; }

        public List<ReferenceValue> ModelList { get; set; }

        public List<ReferenceValue> TypeList { get; set; } 
        
         
    }
}
