using System.ComponentModel;
using System.Windows.Input;
using ECH.Infrastructure.Events;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;

namespace ECH.ModuleA.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IUnityContainer _container;

        public SettingsViewModel(IEventAggregator eventAggregator, IUnityContainer container)
        {
            _eventAggregator = eventAggregator;
            _container = container;

            StartCommand = new DelegateCommand(StartCommandExecute, StartCommandCanExecute);
            StopCommand = new DelegateCommand(StopCommandExecute, StopCommandCanExecute);
            RotationSpeedCommand = new DelegateCommand(RotationSpeedCommandExecute, RotationSpeedCommandCanExecute);
            RotationDirectionCommand = new DelegateCommand<object>(RotationDirectionCommandExecute, RotationDirectionCommandCanExecute);
        }
        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand RotationSpeedCommand { get; set; }
        public ICommand RotationDirectionCommand { get; set; }

        public RotationDirection Clockwise
        {
            get { return RotationDirection.Clockwise; }
        }
        public RotationDirection AntiClockwise
        {
            get { return RotationDirection.AntiClockwise; }
        }

        #region Commands Execute

        private void StartCommandExecute()
        {
            var motor = new Motor();
            motor.Activated = true;

            _eventAggregator.GetEvent<ActivateMotorEvent>().Publish(motor);
        }

        private void StopCommandExecute()
        {
            var motor = new Motor();
            motor.Activated = false;

            _eventAggregator.GetEvent<ActivateMotorEvent>().Publish(motor);
        }

        private void RotationSpeedCommandExecute()
        {
            var motor = new Motor();
            motor.Activated = false;

            _eventAggregator.GetEvent<ActivateMotorEvent>().Publish(motor);
        }

        private void RotationDirectionCommandExecute(object arg)
        {
            var motor = _container.Resolve<Motor>();
            motor.Speed = 100;
            motor.Activated = true;
            motor.Rotation = RotationDirection.Clockwise;

            _eventAggregator.GetEvent<ActivateMotorEvent>().Publish(motor);
        }

        #endregion

        #region Commands CanExecute

        private bool StartCommandCanExecute()
        {
            return true;
        }

        private bool StopCommandCanExecute()
        {
            return true;
        }

        private bool RotationSpeedCommandCanExecute()
        {
            return true;
        }

        private bool RotationDirectionCommandCanExecute(object arg)
        {
            return true;
        }

        #endregion

        #region PropertyChanged
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
