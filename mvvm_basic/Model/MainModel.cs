using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace mvvm_basic.Model
{
    internal class MainModel : INotifyPropertyChanged
    {

        private int num = 1;
        private int num2 = 1;

        public int Num
        {
            get { return num; }
            set
            {
                num = value;
                OnPropertyChanged("Num");
            }
        }
        public int Num2
        {
            get { return num2; }
            set
            {
                num2 = value;
                OnPropertyChanged("Num2");
            }
        }




        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
