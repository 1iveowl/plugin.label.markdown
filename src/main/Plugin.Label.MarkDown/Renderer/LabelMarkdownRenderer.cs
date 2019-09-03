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
        public LabelMarkdownRenderer(MarkdownDocument document) : base(document)
        {

        }
        
        protected override void RenderParagraph(ParagraphBlock element, IRenderContext context)
        {

            if (element.Inlines.Any())
            {
                RenderInlineChildren(element.Inlines, context);

                if (context.Parent is FormattedString fs)
                {
                    if (fs.Spans?.Any() ?? false)
                    {
                        fs.Spans.Last().Text += "&#10;";
                    }
                    
                }
            }

            //if (_currentSpan is null)
            //{
            //    _currentSpan = new Span();
            //}
            //else
            //{
            //    _currentSpan.Text += "&#10;";

            //    if (context.Parent is FormattedString fs)
            //    {
            //        fs.Spans.Add(_currentSpan);
            //    }

            //    _currentSpan = new Span();
            //}
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
                    Text = element.Text
                };
                //if (_currentSpan is null)
                //{
                //    _currentSpan = new Span();
                //}

                //_currentSpan.Text = element.Text;

                fs.Spans.Add(span);
            }
        }

        protected override void RenderBoldRun(BoldTextInline element, IRenderContext context)
        {
            if (context.Parent is FormattedString fs)
            {
                var span = new Span
                {
                    Text = element.
                };
                //if (_currentSpan is null)
                //{
                //    _currentSpan = new Span();
                //}

                //_currentSpan.Text = element.Text;

                fs.Spans.Add(span);
            }

            //if (_currentSpan is null)
            //{
            //    _currentSpan = new Span();
            //}

            //_currentSpan.FontAttributes = FontAttributes.Bold;
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
            throw new NotImplementedException();
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
