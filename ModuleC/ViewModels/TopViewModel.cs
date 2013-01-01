using System.ComponentModel;
using System.Windows.Input;
using ECH.Infrastructure.Events;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;

namespace ECH.ModuleC.ViewModels
{
  public class TopViewModel : INotifyPropertyChanged
  {
    private readonly IEventAggregator _eventAggregator;

    public TopViewModel(IEventAggregator eventAggregator)
    {
      _eventAggregator = eventAggregator;
      StartCommand = new DelegateCommand(StartCommandExecute, StartCommandCanExecute);
      StopCommand = new DelegateCommand(StopCommandExecute, StopCommandCanExecute);
    }

    public ICommand StartCommand { get; set; }
    public ICommand StopCommand { get; set; }

    public bool activator;
    
    
    #region Commands

    private void StopCommandExecute()
    {
      var motor = new Motor();
      motor.Activated = false;

      _eventAggregator.GetEvent<ActivateMotorEvent>().Publish(motor);
    }

    private bool StopCommandCanExecute()
    {
      return true;
    }

    private void StartCommandExecute()
    {
      
    }

    private bool StartCommandCanExecute()
    {
      return true;
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