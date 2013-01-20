using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ECH.Infrastructure.Events;
using ECH.Infrastructure.Implementation;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;

namespace ECH.ModuleC.ViewModels
{
    public class TopViewViewModel : INotifyPropertyChanged
    {
        private readonly IUnityContainer _container;
        private readonly IEventAggregator _eventAggregator;

        public TopViewViewModel(IUnityContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
            StartCommand = new DelegateCommand(StartCommandExecute, StartCommandCanExecute);
            StopCommand = new DelegateCommand(StopCommandExecute, StopCommandCanExecute);

            AvailableBoards = new ObservableCollection<StkBoard>();
        }

        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }

        public ObservableCollection<StkBoard> AvailableBoards { get; set; }
        public StkBoard SelectedBoard { get; set; }

        #region Commands Execute

        private void StopCommandExecute()
        {
            var motor = _container.Resolve<Motor>();
            motor.Activated = false;

            _eventAggregator.GetEvent<UpdateMotorEvent>().Publish(motor);
        }

        private void StartCommandExecute()
        {
            var motor = _container.Resolve<Motor>();
            motor.Activated = true;

            _eventAggregator.GetEvent<UpdateMotorEvent>().Publish(motor);
        }

        #endregion

        #region Commands CanExecute


        private bool StartCommandCanExecute()
        {
            return SelectedBoard != null;
        }

        private bool StopCommandCanExecute()
        {
            return SelectedBoard != null;
            
        }

        #endregion

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}