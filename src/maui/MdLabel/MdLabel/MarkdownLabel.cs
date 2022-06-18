﻿using MdLabel.Factory;
using MdLabel.Renderer;

namespace MdLabel
{
    public class MarkdownLabel : MarkdownLabelBase
    {
        protected override MauiRenderer GetRenderer() => SpanFactory is not null 
            ? new(SpanFactory) 
            : throw new NullReferenceException("SpanFactory cannot be null.");

        public MarkdownLabel()
        {
            // Use default SpanFactory
            SpanFactory = new SpanFactory();
        }

        public MarkdownLabel(ISpanFactory spanFactory)
        {
            // Provide custom SpanFactory
            SpanFactory = spanFactory;
        }
    }
}
