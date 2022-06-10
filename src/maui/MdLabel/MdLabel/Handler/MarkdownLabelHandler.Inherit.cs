//using Microsoft.Maui.Handlers;
//#if IOS || MACCATALYST
////using PlatformView = UIKit.UIView;
//using PlatformView = Microsoft.Maui.Platform.MauiLabel;
//#elif ANDROID
////using PlatformView = Android.Views.View;
//using PlatformView = AndroidX.AppCompat.Widget.AppCompatTextView;
//#elif WINDOWS
//using PlatformView = Microsoft.UI.Xaml.Controls.TextBlock;
////using Microsoft.UI.Xaml.FrameworkElement;
//#elif TIZEN
//using PlatformView = Microsoft.Maui.Platform.ContentCanvas;
//#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
//using PlatformView = Microsoft.Maui.Controls.Label;
//#endif

//namespace MdLabel.Handler
//{
//    public class MarkdownLabelHandler : LabelHandler, IMarkdownLabelHandler
//    {

//        IMarkdownLabel IMarkdownLabelHandler.VirtualView => (IMarkdownLabel)VirtualView;
//        PlatformView IMarkdownLabelHandler.PlatformView => PlatformView;

//        public static IPropertyMapper<IMarkdownLabel, IMarkdownLabelHandler> MarkdownLabelMapper = new PropertyMapper<IMarkdownLabel, MarkdownLabelHandler>(ViewMapper)
//        {
//            [nameof(IMarkdownLabel.Text)] = MapMarkdownText
//        };

//        public MarkdownLabelHandler() : base(MarkdownLabelMapper) { }

//        public MarkdownLabelHandler(IPropertyMapper? mapper = null) : base(mapper ?? MarkdownLabelMapper) { }

////#if (WINDOWS || IOS || MACCATALYST || ANDROID || TIZEN)
////        protected override void ConnectHandler(PlatformView platformView)
////        {
////            base.ConnectHandler(platformView);
////        }
////#endif
//        public static void MapMarkdownText(IMarkdownLabelHandler handler, IMarkdownLabel markdownLabel)
//        {
//            //handler.VirtualView.UpdateFormattedText();
//# if WINDOWS
//#endif
//        }

//        //public override void UpdateValue(string property)
//        //{
//        //    base.UpdateValue(property);
//        //}

//    }
//}
