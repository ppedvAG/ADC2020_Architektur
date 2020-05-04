using System.ComponentModel;

namespace ppedv.ADC2020.UI.WPF.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected void OnPropChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
