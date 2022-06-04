﻿using Markdig.Syntax.Inlines;

namespace MdLabel.Renderer
{
    public class MauiLinkInlineRenderer : MauiObjectRenderer<LinkInline>
    {
        protected override void Write(MauiRenderer renderer, LinkInline link)
        {
            if (link is not null)
            {
                if (Uri.TryCreate(
                    link.GetDynamicUrl is not null ? link.GetDynamicUrl() : link.Url,
                    UriKind.RelativeOrAbsolute,
                    out var uri))
                {
                    renderer.OpenLink(uri);
                    renderer.WriteChildren(link);
                    renderer.CloseLink();
                }
            }
        }
    }
}