using Markdig.Helpers;
using Markdig.Renderers;
using MdLabel.Factory;
using MdLabel.Spans;
using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer
{
    public class MauiRenderer : TextRendererBase<MauiRenderer>, IMauiRenderer
    {
        private readonly ISpanFactory _spanFactory;
        public virtual IRendererState State { get; private set; }

        public MauiRenderer(ISpanFactory spanFactory, IRendererState? state = default) : base(new StringWriter())
        {
            _spanFactory = spanFactory;

            State = state is not null 
                ? state 
                : new MauiRenderState();

            Initialize();

            //ObjectWriteBefore += MdRenderer_ObjectWriteBefore;
            //ObjectWriteAfter += MdRenderer_ObjectWriteAfter;
        }

        protected virtual void Initialize()
        {
            ObjectRenderers.Add(new MauiParagraphRenderer());
            ObjectRenderers.Add(new MauiLiteralInlineRenderer());
            ObjectRenderers.Add(new MauiEmphasisInlineRenderer());
            ObjectRenderers.Add(new MauiHeadingRenderer());
            ObjectRenderers.Add(new MauiLineBreakInlineRenderer());
            ObjectRenderers.Add(new MauiLinkInlineRenderer());
            ObjectRenderers.Add(new MauiListRenderer());
        }

        public virtual FormattedString GetFormattedString()
        {
            var formattedString = new FormattedString();

            foreach (var span in State.MarkdownSpans)
            {
                formattedString.Spans.Add(span);
            }

            return formattedString;
        }

        public virtual void WriteSpan(ref StringSlice slice)
        {
            var text = slice.ToString();

            var markdownSpan = _spanFactory.GetSpan(
                spanBlock: State.CurrentTextBlockKind,
                inlineFormats: State.InlineFormats,
                linkAction: span => AddGestureAction(span));

            markdownSpan.Text = text;

            State.AddSpanToBlock(markdownSpan);

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

        //private void MdRenderer_ObjectWriteAfter(IMarkdownRenderer arg1, MarkdownObject arg2)
        //{
        //}

        //private void MdRenderer_ObjectWriteBefore(IMarkdownRenderer arg1, MarkdownObject arg2)
        //{
        //}

        public virtual void Dispose() => State.Dispose();
    }
}


