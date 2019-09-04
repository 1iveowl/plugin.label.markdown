using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;
using Microsoft.Toolkit.Parsers.Markdown.Inlines;
using Microsoft.Toolkit.Parsers.Markdown.Render;
using Xamarin.Forms;

namespace Plugin.Label.MarkDown.Renderer
{
    internal class LabelMarkdownRenderer : MarkdownRendererBase
    {

        private readonly Stack<MarkdownInlineType> _inlineTypeStack;

        public LabelMarkdownRenderer(MarkdownDocument document) : base(document)
        {
            _inlineTypeStack = new Stack<MarkdownInlineType>();
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
                    if (fs.Spans?.Any() ?? false)
                    {
                        fs.Spans.Last().Text += Environment.NewLine;
                    }
                    
                }
            }
        }

        protected override void RenderYamlHeader(YamlHeaderBlock element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderHeader(HeaderBlock element, IRenderContext context)
        {
            
            throw new NotImplementedException();
        }

        protected override void RenderListElement(ListBlock element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderHorizontalRule(IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderQuote(QuoteBlock element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderCode(CodeBlock element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderTable(TableBlock element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderEmoji(EmojiInline element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderTextRun(TextRunInline element, IRenderContext context)
        {
            if (context.Parent is FormattedString fs)
            {
                var span = new Span
                {
                    Text = element.Text.Replace("\n\r", Environment.NewLine)
                };

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

                fs.Spans.Add(span);
            }
        }

        protected override void RenderBoldRun(BoldTextInline element, IRenderContext context)
        {
            RenderInlineType(element.Inlines, MarkdownInlineType.Bold, context);
        }

        protected override void RenderMarkdownLink(MarkdownLinkInline element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderImage(ImageInline element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderHyperlink(HyperlinkInline element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderItalicRun(ItalicTextInline element, IRenderContext context)
        {
            RenderInlineType(element.Inlines, MarkdownInlineType.Italic, context);
        }

        protected override void RenderStrikethroughRun(StrikethroughTextInline element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderSuperscriptRun(SuperscriptTextInline element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderSubscriptRun(SubscriptTextInline element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        protected override void RenderCodeRun(CodeInline element, IRenderContext context)
        {
            throw new NotImplementedException();
        }

        private void RenderInlineType(IList<MarkdownInline> inlines, MarkdownInlineType markdownInlineType, IRenderContext context)
        {
            _inlineTypeStack.Push(markdownInlineType);
            RenderInlineChildren(inlines, context);
            _inlineTypeStack.Pop();
        }

        //private void RendererRun(IEnumerable<MarkdownInline> inlines, IRenderContext context)
        //{
        //    foreach (var inline in inlines)
        //    {
        //        switch (inline.Type)
        //        {
        //            case MarkdownInlineType.Comment:
        //                break;
        //            case MarkdownInlineType.TextRun:
        //                RenderTextRun(inline as TextRunInline, context);
        //                break;
        //            case MarkdownInlineType.Bold:
        //                RenderBoldRun(inline as BoldTextInline, context);
        //                break;
        //            case MarkdownInlineType.Italic:
        //                break;
        //            case MarkdownInlineType.MarkdownLink:
        //                break;
        //            case MarkdownInlineType.RawHyperlink:
        //                break;
        //            case MarkdownInlineType.RawSubreddit:
        //                break;
        //            case MarkdownInlineType.Strikethrough:
        //                break;
        //            case MarkdownInlineType.Superscript:
        //                break;
        //            case MarkdownInlineType.Subscript:
        //                break;
        //            case MarkdownInlineType.Code:
        //                break;
        //            case MarkdownInlineType.Image:
        //                break;
        //            case MarkdownInlineType.Emoji:
        //                break;
        //            case MarkdownInlineType.LinkReference:
        //                break;
        //            default:
        //                throw new ArgumentOutOfRangeException();
        //        }
        //    }
        //}
    }
}
