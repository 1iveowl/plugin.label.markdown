//using Microsoft.Maui.Handlers;
//using Microsoft.UI.Xaml.Controls;

//namespace MdLabel.Handler
//{
//    public partial class MarkdownLabelHandler : ViewHandler<IMarkdownLabel, TextBlock>//LabelHandler
//    {
//        protected override TextBlock CreatePlatformView() => new();

//        public override void SetVirtualView(IView view)
//        {

//            base.SetVirtualView(view);
//            _ = VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} should have been set by base class.");
//            _ = PlatformView ?? throw new InvalidOperationException($"{nameof(PlatformView)} should have been set by base class.");
//        }

//        public override void SetMauiContext(IMauiContext mauiContext)
//        {
//            base.SetMauiContext(mauiContext);
//        }
//    }
//}
