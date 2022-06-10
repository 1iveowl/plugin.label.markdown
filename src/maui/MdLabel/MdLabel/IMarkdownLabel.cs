namespace MdLabel
{
    public interface IMarkdownLabel //: ILabel
    {
        new string Text { get; set; }

        Style Header1Style { get; set; }
        Style Header2Style { get; set; }
        Style Header3Style { get; set; }
        Style Header4Style { get; set; }
        Style Header5Style { get; set; }
        Style Header6Style { get; set; }

        bool IsExtraHeaderSpacing { get; set; }
        bool IsParagraphSpacing { get; set; }
        Color UrlLinkColor { get; set; }

        string Variable1 { get; set; }
        string Variable2 { get; set; }
        string Variable3 { get; set; }
        string Variable4 { get; set; }
        string Variable5 { get; set; }
        string Variable6 { get; set; }

        FormattedString? UpdateFormattedText();
    }
}