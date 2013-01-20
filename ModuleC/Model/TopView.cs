using ECH.Infrastructure.Events;
using ECH.Infrastructure.Implementation;
using ECH.ModuleC.ViewModels;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;

namespace ECH.ModuleC.Model
{
    public class TopViewModel
    {
        private readonly IUnityContainer _container;
        private readonly IEventAggregator _eventAggregator;
        private SubscriptionToken _subscriptionToken;

        private readonly TopViewViewModel _vm;

        public TopViewModel(IUnityContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
            _vm = _container.Resolve<TopViewViewModel>();
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            var boardChanged = _eventAggregator.GetEvent<STKConnectionEvent>();

            if (_subscriptionToken != null)
            {
                boardChanged.Unsubscribe(_subscriptionToken);
            }

            _subscriptionToken = boardChanged.Subscribe(BoardChangeHandler, ThreadOption.BackgroundThread, false);
        }

        private void BoardChangeHandler(StkBoard obj)
        {
            
            if(obj.State == StkStateChange.Added)
            {
                _vm.AvailableBoards.Add(obj);

                if (_vm.SelectedBoard == null)
                    _vm.SelectedBoard = obj;
            }
            else
            {
                foreach(var board in _vm.AvailableBoards)
                {
                    if(board.ComPort == obj.ComPort)
                    {
                        _vm.AvailableBoards.Remove(board);
                        break;
                    }
                }
            }
        }
    }
}