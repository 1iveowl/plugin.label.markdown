using Markdig.Helpers;
using Markdig.Renderers;
using Markdig.Syntax;
using MdLabel.Factory;
using MdLabel.Spans;
using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer
{
    public class MauiRenderer : TextRendererBase<MauiRenderer>, IMauiRenderer
    {
        private readonly ISpanFactory _spanFactory;
        internal virtual IRendererState State { get; private set; } = new MauiRenderState();

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

        public virtual FormattedString GetFormattedString()
        {
            var formattedString = new FormattedString();

            foreach (var span in State.SpanBlocks.SelectMany(block => block.GetSpans()))
            {
                formattedString.Spans.Add(span);
            }

            return formattedString;
        }

        public virtual void WriteSpan(ref StringSlice slice)
        {
            if (State.CurrentSpanBlock is null)
            {
                throw new NullReferenceException($"{nameof(MauiSpanBlock)} cannot be null");
            }

            var text = slice.ToString();

            var markdownSpan = _spanFactory.GetSpan(
                spanBlock: State.CurrentBlockKind,
                inlineFormats: State.InlineFormatStack,
                linkAction: span => AddGestureAction(span));

            markdownSpan.Text = text;

            State.CurrentSpanBlock?.AddSpan(markdownSpan);

            void AddGestureAction(MarkdownSpanBase span)
            {
                if (State.Uri is not null)
                {
                    span.GestureRecognizers.Add(new TapGestureRecognizer()
                    {
                        Command = new Command<string>(async _ =>
                        {
                            await Launcher.OpenAsync(State.Uri);
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

        private void MdRenderer_ObjectWriteAfter(IMarkdownRenderer arg1, MarkdownObject arg2)
        {

        }

        private void MdRenderer_ObjectWriteBefore(IMarkdownRenderer arg1, MarkdownObject arg2)
        {

        }

        public virtual void Dispose() => State.Dispose();
    }
}


