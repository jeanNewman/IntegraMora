using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class MostrarError : INotifyPropertyChanged
    {
        private string myVar;
        public string MyProperty
        {
            [DebuggerStepThrough]
            get { return myVar; }
            [DebuggerStepThrough]
            set
            {
                if (value != myVar)
                {
                    myVar = value;
                    OnPropertyChanged("MyProperty");
                }
            }
        }
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Error
        {
            get { return String.Empty; }
        }
        public string this[string columnName]
        {
            get
            {
                if (columnName == "MyProperty")
                {
                    if (String.IsNullOrEmpty(MyProperty))
                    {
                        return "Should not be blank";
                    }
                }
                return null;
            }
        }
    }

        /****************************************************************************************/
        //    private string _MyError = "";
        //    public MostrarError() { }

        //    public MostrarError(string error)
        //    {
        //        _MyError = error;
        //    }

        //    public string MyError
        //    {
        //        get
        //        {
        //            return _MyError;
        //        }

        //        set
        //        {
        //            if (value != _MyError)
        //            {
        //                _MyError = value;
        //                OnPropertyChanged("MyError");
        //            }
        //        }
        //    }

        //    public event PropertyChangedEventHandler PropertyChanged;
        //    private void OnPropertyChanged(String info)
        //    {
        //        PropertyChangedEventHandler handler = PropertyChanged;
        //        if (handler != null)
        //        {
        //            handler(this, new PropertyChangedEventArgs(info));
        //        }
        //    }
        //    //public event PropertyChangedEventHandler PropertyChanged;

        //    //// This method is called by the Set accessor of each property.  
        //    //// The CallerMemberName attribute that is applied to the optional propertyName  
        //    //// parameter causes the property name of the caller to be substituted as an argument.  
        //    //private void NotifyPropertyChanged(String propertyName = "")
        //    //{
        //    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    //}
        //}
    }
