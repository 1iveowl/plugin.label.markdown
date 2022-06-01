using Markdig;
using ResearchMarkDigParser;
using System.Text;

string? html = null;
var testString = "This is a *test*.";

//var parsers = new MarkdownPipelineBuilder().DisableHtml().InlineParsers;

//var firstParser = parsers.FirstOrDefault();

//html = Markdown.ToHtml(testString);

Console.WriteLine(html ?? "skip");

var writer = new StringWriter();

var markdown = Markdown.Convert(testString, new MauiRenderer(writer));

Console.WriteLine(markdown);
