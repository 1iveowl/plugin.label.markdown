using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;
using Microsoft.Toolkit.Parsers.Markdown.Inlines;
using Microsoft.Toolkit.Parsers.Markdown.Render;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Plugin.Label.MarkDown.Renderer
{
    internal class LabelMarkdownRenderer : MarkdownRendererBase
    {
        private readonly Stack<MarkdownInlineType> _inlineTypeStack;

        private readonly IDictionary<int, Style> _headerStyles;
        private readonly Color _urlLinkColor;

        private int _headerLevel;

        public LabelMarkdownRenderer(
            MarkdownDocument document,
            Color urlLinkColor,
            IDictionary<int, Style> headerStyles) : base(document)
        {
            _inlineTypeStack = new Stack<MarkdownInlineType>();
            _headerStyles = headerStyles;
            _urlLinkColor = urlLinkColor;
        }
        
        protected override void RenderParagraph(ParagraphBlock element, IRenderContext context)
        {
            if (element.Inlines.Any())
            {
                if (element.Inlines.Any())
                {
                    RenderInlineChildren(element.Inlines, context);
                }
                
                if (context.Parent is FormattedString fs)
                {
                    //var span= new Span { Text = Environment.NewLine + Environment.NewLine };

                    //fs.Spans.Add(span);

                    var spanParagraphSpacing = new Span {Text = Environment.NewLine + Environment.NewLine };

                    fs.Spans.Add(spanParagraphSpacing);
                }
            }

        }

        protected override void RenderYamlHeader(YamlHeaderBlock element, IRenderContext context)
        {
            //throw new NotImplementedException();
        }

        protected override void RenderHeader(HeaderBlock element, IRenderContext context)
        {
            _headerLevel = element.HeaderLevel;
            RenderInlineChildren(element.Inlines, context);

            if (context.Parent is FormattedString fs)
            {
                if (fs.Spans?.Any() ?? false)
                {
                    fs.Spans.Last().Text += Environment.NewLine;
                }

            }

            _headerLevel = 0;
        }

        protected override void RenderListElement(ListBlock element, IRenderContext context)
        {
            //throw new NotImplementedException();
        }

        protected override void RenderHorizontalRule(IRenderContext context)
        {
            //throw new NotImplementedException();
        }

        protected override void RenderQuote(QuoteBlock element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderCode(CodeBlock element, IRenderContext context)
        {
            //throw new NotImplementedException();
        }

        protected override void RenderTable(TableBlock element, IRenderContext context)
        {
            //throw new NotImplementedException();
        }

        protected override void RenderEmoji(EmojiInline element, IRenderContext context)
        {
            if (context.Parent is FormattedString fs)
            {
                var span = new Span
                {
                    Text = element.Text
                };

                fs.Spans.Add(span);
            }
        }

        protected override void RenderTextRun(TextRunInline element, IRenderContext context)
        {
            if (context.Parent is FormattedString fs)
            {
                var span = new Span
                {
                    Text = element.Text.Replace("\n\r", Environment.NewLine)
                };

                if (_headerLevel > 0)
                {
                    span.Style = _headerStyles[_headerLevel];
                }

                RenderInlineSpan(span);
                
                fs.Spans.Add(span);
            }
        }

        protected override void RenderBoldRun(BoldTextInline element, IRenderContext context)
        {
            RenderInlineType(element.Inlines, MarkdownInlineType.Bold, context);
        }

        protected override void RenderMarkdownLink(MarkdownLinkInline element, IRenderContext context)
        {
            var text = string.Join(string.Empty, element.Inlines);

            RenderLink(text, element.Url, context);
        }

        protected override void RenderImage(ImageInline element, IRenderContext context)
        {
            //throw new NotImplementedException();
        }

        protected override void RenderHyperlink(HyperlinkInline element, IRenderContext context)
        {
            RenderLink(element.Text, element.Url, context);
        }

        protected override void RenderItalicRun(ItalicTextInline element, IRenderContext context)
        {
            RenderInlineType(element.Inlines, MarkdownInlineType.Italic, context);
        }

        protected override void RenderStrikethroughRun(StrikethroughTextInline element, IRenderContext context)
        {
            //throw new NotImplementedException();
        }

        protected override void RenderSuperscriptRun(SuperscriptTextInline element, IRenderContext context)
        {
            //throw new NotImplementedException();
        }

        protected override void RenderSubscriptRun(SubscriptTextInline element, IRenderContext context)
        {
            //throw new NotImplementedException();
        }

        protected override void RenderCodeRun(CodeInline element, IRenderContext context)
        {
            //throw new NotImplementedException();
        }

        private void RenderLink(string text, string url, IRenderContext context)
        {
            if (context.Parent is FormattedString fs)
            {
                var span = new Span
                {
                    Text = text,
                    TextDecorations = TextDecorations.Underline,
                    TextColor = _urlLinkColor
                };

                RenderInlineSpan(span);

                var tap = new TapGestureRecognizer
                {
                    Command = new Command<string>(async urlStr =>
                    {
                        await Launcher.OpenAsync(new Uri(urlStr));
                    }),
                    CommandParameter = url
                };
                
                span.GestureRecognizers.Add(tap);

                fs.Spans.Add(span);
            }
        }

        private void RenderInlineSpan(Span span)
        {
            foreach (var inlineType in _inlineTypeStack)
            {
                switch (inlineType)
                {
                    case MarkdownInlineType.Comment:
                    case MarkdownInlineType.TextRun:
                        break;
                    case MarkdownInlineType.Bold:
                        span.FontAttributes += (int)FontAttributes.Bold;
                        break;
                    case MarkdownInlineType.Italic:
                        span.FontAttributes += (int)FontAttributes.Italic;
                        break;
                    case MarkdownInlineType.MarkdownLink:
                        break;
                    case MarkdownInlineType.RawHyperlink:
                        break;
                    case MarkdownInlineType.RawSubreddit:
                        break;
                    case MarkdownInlineType.Strikethrough:
                        span.TextDecorations += (int)TextDecorations.Strikethrough;
                        break;
                    case MarkdownInlineType.Superscript:
                        break;
                    case MarkdownInlineType.Subscript:
                        break;
                    case MarkdownInlineType.Code:
                        break;
                    case MarkdownInlineType.Image:
                        break;
                    case MarkdownInlineType.Emoji:
                        break;
                    case MarkdownInlineType.LinkReference:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void RenderInlineType(IList<MarkdownInline> inlines, MarkdownInlineType markdownInlineType, IRenderContext context)
        {
            _inlineTypeStack.Push(markdownInlineType);
            RenderInlineChildren(inlines, context);
            _inlineTypeStack.Pop();
        }
    }
}
