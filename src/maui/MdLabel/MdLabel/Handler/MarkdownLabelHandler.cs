using Microsoft.Maui.Handlers;
#if IOS || MACCATALYST
//using PlatformView = UIKit.UIView;
using PlatformView = Microsoft.Maui.Platform.MauiLabel;
#elif ANDROID
//using PlatformView = Android.Views.View;
using PlatformView = AndroidX.AppCompat.Widget.AppCompatTextView;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.TextBlock;
//using Microsoft.UI.Xaml.FrameworkElement;
#elif TIZEN
using PlatformView = Microsoft.Maui.Platform.ContentCanvas;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = Microsoft.Maui.Controls.Label;
#endif

namespace MdLabel.Handler
{
    //public partial class MarkdownLabelHandler : LabelHandler, IMarkdownLabelHandler
    public partial class MarkdownLabelHandler : ViewHandler<IMarkdownLabel, PlatformView>, IMarkdownLabelHandler
    {
        public static PropertyMapper<IMarkdownLabel, MarkdownLabelHandler> MarkdownLabelMapper = 
            new PropertyMapper<IMarkdownLabel, MarkdownLabelHandler>(LabelHandler.ViewMapper)
            {
                [nameof(IMarkdownLabel.Text)] = MapMarkdownText,
                [nameof(IContentView.Content)] = MapContent,
                
            };

#if (NET6_0 && !IOS && !MACCATALYST && !WINDOWS && !ANDROID && !TIZEN)
        protected override PlatformView CreatePlatformView() => new();
#endif

        public static void MapContent(IMarkdownLabelHandler handler, IMarkdownLabel label)
        {

        }

        public static void MapMarkdownText(IMarkdownLabelHandler handler, IMarkdownLabel label)
        {
            var markdownLabel = (MarkdownLabel)label;
            markdownLabel.FormattedText = handler.VirtualView.UpdateFormattedText();
        }

        public MarkdownLabelHandler() : base(MarkdownLabelMapper)
        {

        }

        public MarkdownLabelHandler(
            IPropertyMapper? mapper = null) : base(mapper ?? MarkdownLabelMapper)
        {

        }

        protected override void ConnectHandler(PlatformView platformView)
        {
            base.ConnectHandler(platformView);
        }

        protected override void DisconnectHandler(PlatformView platformView)
        {
            base.DisconnectHandler(platformView);
        }

        IMarkdownLabel IMarkdownLabelHandler.VirtualView => VirtualView;

        PlatformView IMarkdownLabelHandler.PlatformView => PlatformView;

    }
}
