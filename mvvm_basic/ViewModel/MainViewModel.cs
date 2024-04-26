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

        // 여기서 중요한 것은 Auto-Implemented Properties이라는 것이다.
        public Command btn_cmd { get; set; }

        // 이렇게 하면, command 바인딩이 안 된다.
        // public Command btn_cmd;



        public MainViewModel()
        {
            model = new Model.MainModel();
            btn_cmd = new Command(Execute_func, CanExecute_func);
        }

        private void Execute_func(object obj)
        {
            // Model의 Property를 통해서 연산을 하고, 
            // 연산의 결과는 INotifyPropertyChanged를 통해
            // View에 즉각 반영된다.
            // *****************************************
            // Command 받고, Notify 돌려준다.
            // View -> ViewModel -> Model
            // Model -> 
            model.Num2 = model.Num * 2;
        }

        private bool CanExecute_func(object obj)
        {
            return true;
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
