using Markdig;
using ResearchMarkDigParser;
using System.Text;

string? html = null;
var testString = @"# Header A

## Header B

### Header C _with italic_

_First Line is italic text._  

**New Line in bold**

~~New line strike through~~  

New line normal [test]

*Italic Link: [Microsoft Azure B2C login](https://blogs.msdn.microsoft.com/azureadb2c/2018/10/05/b2clogin-com-is-now-generally-available/)*

# Header 1 Link: [Microsoft Azure B2C login](https://blogs.msdn.microsoft.com/azureadb2c/2018/10/05/b2clogin-com-is-now-generally-available/)

1. Item 1
2. Item 2
    1. Indent Item 1.1
    2. Indent Item 1.2
3. Item 3

    > Block quote
   
4. Item 4

* Item a
* Item b

    Line in list
                    
* Item c
                    
[test]: Inserted variable
";

//var parsers = new MarkdownPipelineBuilder().DisableHtml().InlineParsers;

//var firstParser = parsers.FirstOrDefault();

var pipelineBuilder = new MarkdownPipelineBuilder()
    .UseEmojiAndSmiley()
    .UseEmphasisExtras()
    .UseReferralLinks();

var extensions = pipelineBuilder.Extensions;

html = Markdown.ToHtml(testString, pipelineBuilder.Build());

Console.WriteLine(html ?? "skip");

var writer = new StringWriter();

var markdown = Markdown.Convert(testString, new MauiRenderer(writer));

Console.WriteLine(markdown);
