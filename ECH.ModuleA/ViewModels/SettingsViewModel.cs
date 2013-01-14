using System.ComponentModel;
using System.Windows.Input;
using ECH.Infrastructure;
using ECH.Infrastructure.Events;
using ECH.Infrastructure.Implementation;
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
            RotationDirectionCommand = new DelegateCommand<object>(RotationDirectionCommandExecute, RotationDirectionCommandCanExecute);
            SaveSettings = new DelegateCommand(SaveSettingsExecute, SaveSettingsCanExecute);
        }

        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand RotationSpeedCommand { get; set; }
        public ICommand RotationDirectionCommand { get; set; }
        public ICommand SaveSettings { get; set; }

        public RotationDirection Clockwise
        {
            get { return RotationDirection.Clockwise; }
        }
        public RotationDirection AntiClockwise
        {
            get { return RotationDirection.AntiClockwise; }
        }

        public int SpeedPercentage { get; set; }
        public int SpeedRPM { get; set; }
        public string StatusText { get; set; }
        public RotationDirection Direction { get; set; }

        #region Commands Execute

        private void SaveSettingsExecute()
        {
            var motor = _container.Resolve<Motor>();
            motor.Rotation = Direction;
            motor.Speed = SpeedPercentage;
        
            _eventAggregator.GetEvent<UpdateMotorEvent>().Publish(motor);
        }

        private void StartCommandExecute()
        {
            var motor = _container.Resolve<Motor>();
            motor.Activated = true;

            _eventAggregator.GetEvent<UpdateMotorEvent>().Publish(motor);
        }

        private void StopCommandExecute()
        {
            var motor = _container.Resolve<Motor>();
            motor.Activated = false;

            _eventAggregator.GetEvent<UpdateMotorEvent>().Publish(motor);
        }

        private void RotationDirectionCommandExecute(object arg)
        {
            var motor = _container.Resolve<Motor>();
            motor.Speed = 100;
            motor.Activated = true;
            motor.Rotation = RotationDirection.Clockwise;

            _eventAggregator.GetEvent<UpdateMotorEvent>().Publish(motor);
        }

        #endregion

        #region Commands CanExecute

        private bool SaveSettingsCanExecute()
        {
            return SpeedPercentage != null
                && SpeedPercentage <= 100
                && SpeedPercentage >= 0
                && Direction != null;
        }

        private bool StartCommandCanExecute()
        {
            return true;
        }

        private bool StopCommandCanExecute()
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
