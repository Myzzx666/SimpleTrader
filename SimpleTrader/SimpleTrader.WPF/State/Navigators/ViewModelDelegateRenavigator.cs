using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.State.Navigators
{
    /// <summary>
    /// 自定义导航Navigation功能
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public class ViewModelDelegateRenavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly CreateViewModel<TViewModel> _createViewModel;

        public ViewModelDelegateRenavigator(INavigator navigator, CreateViewModel<TViewModel> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public void Renavigate()
        {
            //每次都创建一个新的ViewModel对象实例
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}
