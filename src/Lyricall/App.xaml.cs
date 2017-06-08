using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Data;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace Lyricall {
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper {
        public App() {
            InitializeComponent();
            ResourceLoader rl = ResourceLoader.GetForViewIndependentUse("AppKeys");
            string mobilecenterid = rl.GetString("MobileCenterId");
            if (!string.IsNullOrWhiteSpace(mobilecenterid)) {
                MobileCenter.Start(mobilecenterid, new Type[] {typeof(Analytics), typeof(Crashes) });
            }
            RequestedTheme = Windows.UI.Xaml.ApplicationTheme.Light;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args) {
            await NavigationService.NavigateAsync(typeof(Views.MainPage));
        }
    }
}
