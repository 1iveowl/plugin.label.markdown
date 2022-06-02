using Markdig.Helpers;
using Markdig.Renderers;
using Markdig.Syntax;
using System.Runtime.CompilerServices;

namespace MdLabel.Renderer
{
    public class MauiRenderer : TextRendererBase<MauiRenderer>
    {
        private readonly Stack<MarkdownInlineFormatKind> _markdownInlineFormatStack;

        private static readonly char[] s_writeEscapeIndexOfAnyChars = new[] { '<', '>', '&', '"' };

        internal FormattedString FormattedString { get; private set; } = new();

        public MauiRenderer(TextWriter writer) : base(writer)
        {
            _markdownInlineFormatStack = new();

            ObjectRenderers.Add(new MauiParagraphRenderer());
            ObjectRenderers.Add(new MauiLiteralInlineRenderer());
            ObjectRenderers.Add(new MauiEmphasisInlineRenderer());

            ObjectWriteBefore += MdRenderer_ObjectWriteBefore;
            ObjectWriteAfter += MdRenderer_ObjectWriteAfter;

            EnableHtmlForBlock = true;
            EnableHtmlForInline = true;
            EnableHtmlEscape = false;
        }

        private void MdRenderer_ObjectWriteAfter(IMarkdownRenderer arg1, MarkdownObject arg2)
        {

        }

        private void MdRenderer_ObjectWriteBefore(IMarkdownRenderer arg1, MarkdownObject arg2)
        {

        }

        internal void PushInlineType(MarkdownInlineFormatKind markdownLineType)
        {
            _markdownInlineFormatStack.Push(markdownLineType);
        }

        internal void PopInlineType()
        {
            _markdownInlineFormatStack.Pop();
        }

        //public override object Render(MarkdownObject markdownObject)
        //{
        //    Write(markdownObject);


        //    return "Bla bla.";
        //}

        public bool EnableHtmlForBlock { get; set; }

        public bool EnableHtmlForInline { get; set; }

        public bool EnableHtmlEscape { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use implicit paragraph (optional &lt;p&gt;)
        /// </summary>
        public bool ImplicitParagraph { get; set; }


        /// <summary>
        /// Gets a value to use as the base url for all relative links
        /// </summary>
        public Uri BaseUrl { get; set; }

        /// <summary>
        /// Writes the content escaped for HTML.
        /// </summary>
        /// <param name="slice">The slice.</param>
        /// <param name="softEscape">Only escape &lt; and &amp;</param>
        /// <returns>This instance</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MauiRenderer WriteTextToSpan(string slice, bool softEscape = false)
        {
            var span = new Span
            {
                Text = slice.Replace("\n\r", Environment.NewLine)
            };

            SetFormating(span);

            FormattedString.Spans.Add(span);

            return this;
        }

        private void SetFormating(Span span)
        {
            foreach(var attr in _markdownInlineFormatStack)
            {
                switch (attr)
                {
                    case MarkdownInlineFormatKind.Comment:
                    case MarkdownInlineFormatKind.TextRun:
                        break;
                    case MarkdownInlineFormatKind.Bold:
                        span.FontAttributes += (int)FontAttributes.Bold;
                        break;
                    case MarkdownInlineFormatKind.Italic:
                        span.FontAttributes += (int)FontAttributes.Italic;
                        break;
                    case MarkdownInlineFormatKind.MarkdownLink:
                        break;
                    case MarkdownInlineFormatKind.RawHyperLink:
                        break;
                    case MarkdownInlineFormatKind.RawSubreditKink:
                        break;
                    case MarkdownInlineFormatKind.StrikeThrough:
                        span.TextDecorations += (int)TextDecorations.Strikethrough;
                        break;
                    case MarkdownInlineFormatKind.SuperScript:
                        break;
                    case MarkdownInlineFormatKind.Subscript:
                        break;
                    case MarkdownInlineFormatKind.Code:
                        break;
                    case MarkdownInlineFormatKind.Image:
                        break;
                    case MarkdownInlineFormatKind.Emoji:
                        break;
                    case MarkdownInlineFormatKind.LinkReference:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Writes the content escaped for HTML.
        /// </summary>
        /// <param name="slice">The slice.</param>
        /// <param name="softEscape">Only escape &lt; and &amp;</param>
        /// <returns>This instance</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MauiRenderer WriteEscape(ref StringSlice slice, bool softEscape = false)
        {
            WriteEscape(slice.AsSpan(), softEscape);
            return this;
        }

        /// <summary>
        /// Writes the content escaped for HTML.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="softEscape">Only escape &lt; and &amp;</param>
        public void WriteEscape(ReadOnlySpan<char> content, bool softEscape = false)
        {
            if (!content.IsEmpty)
            {
                int nextIndex = content.IndexOfAny(s_writeEscapeIndexOfAnyChars);
                if (nextIndex == -1)
                {
                    Write(content);
                }
                else
                {
                    WriteEscapeSlow(content, softEscape);
                }
            }
        }

        private void WriteEscapeSlow(ReadOnlySpan<char> content, bool softEscape = false)
        {
            WriteIndent();

            int previousOffset = 0;
            for (int i = 0; i < content.Length; i++)
            {
                switch (content[i])
                {
                    case '<':
                        WriteRaw(content[previousOffset..i]);
                        //if (EnableHtmlEscape)
                        //{
                        //    WriteRaw("&lt;");
                        //}
                        previousOffset = i + 1;
                        break;
                    case '>':
                        if (!softEscape)
                        {
                            WriteRaw(content[previousOffset..i]);
                            //if (EnableHtmlEscape)
                            //{
                            //    WriteRaw("&gt;");
                            //}
                            previousOffset = i + 1;
                        }
                        break;
                    case '&':
                        WriteRaw(content[previousOffset..i]);
                        //if (EnableHtmlEscape)
                        //{
                        //    WriteRaw("&amp;");
                        //}
                        previousOffset = i + 1;
                        break;
                    case '"':
                        if (!softEscape)
                        {
                            WriteRaw(content[previousOffset..i]);
                            //if (EnableHtmlEscape)
                            //{
                            //    WriteRaw("&quot;");
                            //}
                            previousOffset = i + 1;
                        }
                        break;
                }
            }

            WriteRaw(content[previousOffset..]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private protected void WriteIndent()
        {
            if (previousWasLine)
            {
                //WriteIndentCore();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteRaw(ReadOnlySpan<char> content)
        {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
            Writer.Write(content);
#else
            if (content.Length > buffer.Length)
            {
                buffer = content.ToArray();
            }
            else
            {
                content.CopyTo(buffer);
            }
            Writer.Write(buffer, 0, content.Length);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteRaw(char content) => Writer.Write(content);
    }
}


