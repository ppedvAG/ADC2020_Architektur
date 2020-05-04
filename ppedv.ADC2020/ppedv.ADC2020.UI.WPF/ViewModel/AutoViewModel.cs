using ppedv.ADC2020.Logic;
using ppedv.ADC2020.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.ADC2020.UI.WPF.ViewModel
{

    public class AutoViewModel : ViewModelBase
    {
        public ObservableCollection<Auto> AutoListe { get; set; }

        public Auto SelectedAuto
        {
            get => selectedAuto;
            set
            {
                selectedAuto = value;
                //   OnPropChanged("SelectedAuto");
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public string LetzerKunde
        {
            get
            {
                if (SelectedAuto == null)
                    return "---" + DateTime.Now.Second;

                return SelectedAuto.Vermietungen?.OrderBy(x => x.Ende).FirstOrDefault()?.Kunde?.Name;

            }
        }

        Core core = new Core();
        private Auto selectedAuto;


        public AutoViewModel()
        {
            AutoListe = new ObservableCollection<Auto>(core.Repository.Query<Auto>());
            SaveCommand = new RelayCommand(x => core.Repository.Save());
            NewCommand = new RelayCommand(UserWantsToCreateNewAuto);
        }

        private void UserWantsToCreateNewAuto(object obj)
        {
            var a = new Auto() { Farbe = "rot" };
            core.Repository.Add(a);
            AutoListe.Add(a);
            SelectedAuto = a;
        }
    }
}
