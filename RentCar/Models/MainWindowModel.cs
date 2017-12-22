using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Models
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        private ObservableCollection<CarModel> _Cars;    
        public ObservableCollection<CarModel> Cars
        {
            get { return this._Cars; }
            set
            {
                this._Cars = value;
                this.OnPropertyChanged("Cars");
            }
        }

        public bool IsAuthorized { get; set; }

        public List<ReferenceValue> CityList { get; set; }
        public List<ReferenceValue> MarkList { get; set; }
        public List<ReferenceValue> ModelList { get; set; }
        public List<ReferenceValue> TypeList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
