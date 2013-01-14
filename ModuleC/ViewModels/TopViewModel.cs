﻿using System.ComponentModel;
using System.Windows.Input;
using ECH.Infrastructure;
using ECH.Infrastructure.Events;
using ECH.Infrastructure.Implementation;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;

namespace ECH.ModuleC.ViewModels
{
  public class TopViewModel : INotifyPropertyChanged
  {
      private readonly IUnityContainer _container;
      private readonly IEventAggregator _eventAggregator;

    public TopViewModel(IUnityContainer container, IEventAggregator eventAggregator)
    {
        _container = container;
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
        var motor = _container.Resolve<Motor>();
      motor.Activated = false;

      _eventAggregator.GetEvent<UpdateMotorEvent>().Publish(motor);
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