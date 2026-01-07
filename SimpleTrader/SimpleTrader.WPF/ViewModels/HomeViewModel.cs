using SimpleTrader.FinancialModelingPrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public AssetSummaryViewModel AssetSummaryViewModel { get; } //汇总ViewModel
        public MajorIndexListingViewModel MajorIndexListingViewModel { get; } //MajorIndex ViewModel

        public HomeViewModel(AssetSummaryViewModel assetSummaryViewModel, MajorIndexListingViewModel majorIndexListingViewModel)
        {
            AssetSummaryViewModel = assetSummaryViewModel;
            MajorIndexListingViewModel = majorIndexListingViewModel;
        }

        public override void Dispose()
        {
            AssetSummaryViewModel.Dispose();
            MajorIndexListingViewModel.Dispose();

            base.Dispose();
        }
    }
}
