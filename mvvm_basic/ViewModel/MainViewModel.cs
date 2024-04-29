using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvm_basic.Model;



namespace mvvm_basic.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        //*************************************************************
        // private Field

        // ViewModel의 역할
        // 1) Event의 전달자
        // 2) Model의 전달자
        private Command _btn_cmd = null;
        private MainModel _model = null;


        //*************************************************************
        // public Propery

        public Command Btn_cmd 
        {
            get => _btn_cmd;
            set => _btn_cmd = value;
        }


        public MainModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }


        //*************************************************************
        // public Constructor


        public MainViewModel()
        {
            _model = new MainModel();
            _btn_cmd = new Command(Execute_func, CanExecute_func);
        }



        //*************************************************************
        // Event Handler


        private void Execute_func(object obj)
        {
            // Model의 Property를 통해서 연산을 하고, 
            // 연산의 결과는 INotifyPropertyChanged를 통해
            // View에 즉각 반영된다.
            // *****************************************
            // Command 받고, Notify 돌려준다.
            // View -> ViewModel -> Model
            // Model -> 
            _model.Num2 = _model.Num * 2;
        }

        private bool CanExecute_func(object obj)
        {
            return true;
        }



        //*************************************************************
        // Event Notifier

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
