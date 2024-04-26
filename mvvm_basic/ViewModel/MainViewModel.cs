using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_basic.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private Model.MainModel model = null;

        public Model.MainModel Model
        {
            get { 
                return model; 
            }
            set { 
                model = value; 
                OnPropertyChanged("Model"); 
            }
        }


        public MainViewModel()
        {
            model = new Model.MainModel();
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
