using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace MdLabel.Handler
{
    public partial class MarkdownLabelHandler : ViewHandler<IMarkdownLabel, MauiLabel>//LabelHandler
    {
        protected override MauiLabel CreatePlatformView() => new();
    }
}
