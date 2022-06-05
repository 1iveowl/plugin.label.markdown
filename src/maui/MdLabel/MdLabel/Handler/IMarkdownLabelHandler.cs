#if IOS || MACCATALYST
//using PlatformView = UIKit.UIView;
using PlatformView = Microsoft.Maui.Platform.MauiLabel;
#elif ANDROID
//using PlatformView = Android.Views.View;
using PlatformView = AndroidX.AppCompat.Widget.AppCompatTextView;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.TextBlock;
//using PlatformView = Microsoft.UI.Xaml.FrameworkElement;
#elif TIZEN
using PlatformView = Microsoft.Maui.Platform.ContentCanvas;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

//#if ANDROID
//using PlatformView = Android.Views.View;
//#elif IOS || MACCATALYST
//using PlatformView = Microsoft.Maui.Platform.View;
//#endif

namespace MdLabel.Handler
{
    public interface IMarkdownLabelHandler : IViewHandler
    {
        //new IMarkdownLabel VirtualView { get; }

        //new PlatformView PlatformView { get; }
    }
}
