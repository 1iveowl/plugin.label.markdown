using Markdig.Helpers;
using Markdig.Renderers;
using Markdig.Syntax;
using MdLabel.Factory;
using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer
{
    public class MauiRenderer : TextRendererBase<MauiRenderer>, IDisposable
    {
        private readonly ISpanFactory _spanFactory;
        private readonly MauiRenderState _state = new();

        public MauiRenderer(ISpanFactory spanFactory) : base(new StringWriter())
        {
            _spanFactory = spanFactory;

            ObjectRenderers.Add(new MauiParagraphRenderer());
            ObjectRenderers.Add(new MauiLiteralInlineRenderer());
            ObjectRenderers.Add(new MauiEmphasisInlineRenderer());
            ObjectRenderers.Add(new MauiHeadingRenderer());
            ObjectRenderers.Add(new MauiLineBreakInlineRenderer());
            ObjectRenderers.Add(new MauiLinkInlineRenderer());
            ObjectRenderers.Add(new MauiListRenderer());

            ObjectWriteBefore += MdRenderer_ObjectWriteBefore;
            ObjectWriteAfter += MdRenderer_ObjectWriteAfter;
        }

        internal FormattedString GetFormattedString()
        {
            var formattedString = new FormattedString();

            foreach (var span in _state.SpanBlocks.SelectMany(block => block.GetSpans()))
            {
                formattedString.Spans.Add(span);
            }

            return formattedString;
        }

        internal void WriteSpan(ref StringSlice slice)
        {
            if (_state.CurrentSpanBlock is null)
            {
                throw new NullReferenceException($"{nameof(MauiSpanBlock)} cannot be null");
            }

            var text = slice.ToString();

            var markdownSpan = _spanFactory.GetSpan(
                spanBlock: _state.CurrentBlockKind,
                inlineFormats: _state.InlineFormatStack,
                linkAction: span => AddGestureAction(span));

            markdownSpan.Text = text;

            _state.CurrentSpanBlock?.AddSpan(markdownSpan);

            void AddGestureAction(MarkdownSpanBase span)
            {
                if (_state.Uri is not null)
                {
                    span.GestureRecognizers.Add(new TapGestureRecognizer()
                    {
                        Command = new Command<string>(async _ =>
                        {
                            await Launcher.OpenAsync(_state.Uri);
                        }),
                        CommandParameter = text
                    });
                }
                else
                {
                    throw new ArgumentNullException("Uri missing for link.");
                }
            }
        }

        internal void SetHeaderStyle(int level) => _state.SetHeaderLevel(level);

        internal void ClearHeaderStyle() => _state.ClearHeader();

        internal void SetLink(Uri uri) => _state.SetLink(uri);

        internal void ClearLink() => _state.ClearLink();

        internal void PushInlineFormatType(MarkdownInlineFormatKind markdownLineType) => _state.PushInlineFormatType(markdownLineType);

        internal void PopInlineFormatType() => _state.PopInlineFormatType();

        internal void AddNewLine() => _state.AddNewLine();

        internal void OpenBlock() => _state.OpenBlock();

        internal void CloseBlock() => _state.CloseBlock();

        private void MdRenderer_ObjectWriteAfter(IMarkdownRenderer arg1, MarkdownObject arg2)
        {

        }

        private void MdRenderer_ObjectWriteBefore(IMarkdownRenderer arg1, MarkdownObject arg2)
        {

        }

        public void Dispose() => _state.Dispose();
    }
}


