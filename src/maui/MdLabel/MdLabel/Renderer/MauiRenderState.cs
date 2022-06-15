﻿namespace MdLabel.Renderer
{
    internal class MauiRenderState : IDisposable
    {      
        internal List<MauiSpanBlock> SpanBlocks { get; private set; } = new();
        internal Stack<MarkdownInlineFormatKind> InlineFormatStack { get; private set; } = new();

        internal MauiSpanBlock? CurrentSpanBlock { get; private set; } = default;
        internal MarkdownHeaderLevelKind CurrentHeaderLevel { get; private set; } = MarkdownHeaderLevelKind.None;

        internal Uri? Uri { get; private set; } = default;

        internal void SetHeaderStyle(int level)
        {
            if (level >= 1 && level <= 6)
            {
                CurrentHeaderLevel = (MarkdownHeaderLevelKind)level;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Header level must be between 1 and 6.");
            }
        }

        internal void ClearHeaderStyle()
        {
            CurrentHeaderLevel = MarkdownHeaderLevelKind.None;
        }

        internal void SetLink(Uri uri)
        {
            if (CurrentSpanBlock is null)
            {
                throw new NullReferenceException($"{nameof(MauiSpanBlock)} cannot be null");
            }

            PushInlineFromatType(MarkdownInlineFormatKind.Link);
            Uri = uri;
        }

        internal void ClearLink()
        {
            PopInlineFormatType();
            Uri = default;
        }

        internal void PushInlineFromatType(MarkdownInlineFormatKind markdownLineType)
        {
            InlineFormatStack.Push(markdownLineType);
        }

        internal void PopInlineFormatType()
        {
            if (InlineFormatStack.Count > 0)
            {
                InlineFormatStack.Pop();
            }
        }

        internal void AddNewLine()
        {
            if (CurrentSpanBlock is not null)
            {
                CurrentSpanBlock.TrailingNewLine++;
            }
            else
            {
                throw new NullReferenceException($"{nameof(MauiSpanBlock)} cannot be null");
            }
        }

        internal void OpenBlock()
        {
            if (CurrentSpanBlock is not null)
            {
                CloseBlock();
            }

            CurrentSpanBlock = new MauiSpanBlock();
        }

        internal void CloseBlock()
        {
            if (CurrentSpanBlock is not null)
            {
                SpanBlocks.Add(CurrentSpanBlock);
            }

            CurrentSpanBlock = default;
        }

        public void Dispose()
        {
            InlineFormatStack.Clear();
            SpanBlocks.Clear();
        }
    }
}