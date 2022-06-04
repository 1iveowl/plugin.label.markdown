using Markdig;
using ResearchMarkDigParser;
using System.Text;

string? html = null;
var testString = "# {{2}}Header A  ## Header B  ### Header C _with italic_  _First Line is italic text._    New Line with Variable 1 in bold: **{{1}}**    New line with variable 3: {{3}}  *Italic Link: [Microsoft Azure B2C login](https://blogs.msdn.microsoft.com/azureadb2c/2018/10/05/b2clogin-com-is-now-generally-available/)*  ";

//var parsers = new MarkdownPipelineBuilder().DisableHtml().InlineParsers;

//var firstParser = parsers.FirstOrDefault();

html = Markdown.ToHtml(testString);

Console.WriteLine(html ?? "skip");

var writer = new StringWriter();

var markdown = Markdown.Convert(testString, new MauiRenderer(writer));

Console.WriteLine(markdown);
