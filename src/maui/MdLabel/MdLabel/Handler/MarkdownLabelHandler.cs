using Microsoft.Maui.Handlers;
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
//#endif

namespace MdLabel.Handler
{
    //public partial class MarkdownLabelHandler : ViewHandler<IMarkdownLabel, PlatformView>, IMarkdownLabelHandler
    public partial class MarkdownLabelHandler : LabelHandler, IMarkdownLabelHandler
    {
        public static PropertyMapper<IMarkdownLabel, IMarkdownLabelHandler> MarkdownLabelMapper = 
            new PropertyMapper<IMarkdownLabel, IMarkdownLabelHandler>(LabelHandler.ViewMapper)
        {
            [nameof(IMarkdownLabel.Text)] = MapText,
        };

        //IMarkdownLabel IMarkdownLabelHandler.VirtualView => VirtualView;
        //PlatformView IMarkdownLabelHandler.PlatformView => PlatformView;

#if (NET6_0 && !IOS && !MACCATALYST && !WINDOWS && !ANDROID && !TIZEN)
        protected override PlatformView CreatePlatformView() => new();
#endif

        public static void MapText(IMarkdownLabelHandler handler, IMarkdownLabel label)
        {

        }

        public MarkdownLabelHandler() : base(MarkdownLabelMapper)
        {

        }

        public MarkdownLabelHandler(
            IPropertyMapper? mapper = null) : base(mapper ?? MarkdownLabelMapper)
        {

        }

        //public MarkdownLabelHandler(
        //    IPropertyMapper mapper, 
        //    CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        //{

        //}

        protected override void ConnectHandler(PlatformView platformView)
        {
            base.ConnectHandler(platformView);
        }

        protected override void DisconnectHandler(PlatformView platformView)
        {
            base.DisconnectHandler(platformView);
        }


    }
}
