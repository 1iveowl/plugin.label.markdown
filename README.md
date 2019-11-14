# Plugin Label Markdown for Xamarin Forms

[![NuGet Badge](https://buildstats.info/nuget/Plugin.Label.Markdown)](https://www.nuget.org/packages/Plugin.Label.Markdown/)

*Please star this project if you find it useful. Thank you!*

## Why this plugin
Wouldn't it be cool if the Xamarin Label control supported [Markdown](https://en.wikipedia.org/wiki/Markdown)?

And how cool would it be if it was possible to include bindable properties inside a Markdown text like this:
> `There are {{1}} apples in the basket.`

Where `{{1}}` represent a variable place-holder for the value of a bindable property.

Well, these are all scenarios introduced by this very light weigth plugin which extends the existing Xamarin Forms Label control. 

I hope others will find it useful too.

## Platforms supported

The plugin works on all platforms supported by Xamarin Forms and .NET Standard 2.0.

## Features: 

Markdown supported:
- Headers - H1, H2 and H3
- Bold
- Italic
- Bold-Italic
- Hyperlinks
- Basic emoji's

_Note_: The emoji's supported depend on the font used as far as I can tell. [Emoji Cheat Sheet](https://gist.github.com/roachhd/1f029bd4b50b8a524f3c)


Other features:
- Bindable Property place-holders (variables in the Markdown text).
- Header styling.
- An extra line is added by default being between paragraphs. To disable `IsParagraphSpacing="false"`. Default: true.
- Option for adding an extra line after headers. To enable: `IsParagraphSpacing="true"`. Default: false.

## XAML Sample
The easied way to introduce the features introduced by this plugin is by looking at a simple example:

<img src="https://github.com/1iveowl/plugin.label.markdown/blob/develop/images/sample2.png?raw=true" width="320" />

This screenshot above is generated using the XAML below. As you read through the XAML please notice the following:

- A paragraph is ended by adding two spaces and \&#x0a;. \&#x0a; is the unicode notation for New Line (aka. \n).
    - E.g. a paragraph ends on: `<space><space>\n`.
    - For convinience, it is also possible to end a paragraph using: `\r\n`.
- There are three styles defined in the ResourceDictionary. They are all set with `TargetType = "Span"`. These three styles is here used to specifically set the styles of each of the headings.
- `Variable1` and `Variable3` are used in the Markdown string. These are just two of the total of six Bindable Properties that can be utilized. By adding the placeholders `{{1}}` ... `{{6}}` in the Markdown text, each placeholder will be replaced by the value of the bindable property at run time. The bindable property is name `Variable1` ... `Variable6` accordingly.
- `UrlLinkColor` specifies the color of a hyper link. Default is Blue.


```xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:markDown="clr-namespace:Plugin.Label.MarkDown;assembly=Plugin.Label.MarkDown"
             mc:Ignorable="d"
             x:Name="This"
             x:Class="Sample.LabelMarkdown.MainPage">

    <ContentPage.Resources>
        <ResourceDictionary>

            <Style TargetType="Span" x:Key="Header1SpanStyle">
                <Setter Property="FontSize" Value="32"></Setter>
                <Setter Property="ForegroundColor"  Value="Purple"></Setter>
            </Style>

            <Style TargetType="Span" x:Key="Header2SpanStyle">
                <Setter Property="FontSize" Value="16"></Setter>
                <Setter Property="FontAttributes" Value="Italic"></Setter>
            </Style>

            <Style TargetType="Span" x:Key="Header3SpanStyle">
                <Setter Property="FontSize" Value="12"></Setter>
            </Style>

        </ResourceDictionary>
    </ContentPage.Resources>  

    <StackLayout>

        <markDown:LabelMd x:Name="LabelMarkdownTest1"
                          UrlLinkColor="Purple"
                          Variable1="Var1"
                          Variable3="Var3"
                          TextMarkdown="#Header A  &#x0a;##Header B  &#x0a;###Header C _with italic_  &#x0a;First Line with some _italic text_.  &#x0a;New Line with Variable 1 in bold: **{{1}}**  &#x0a;New line with variable 3: {{3}}  &#x0a;[Link to Google](https://www.google.com) &#x0a;"
                          Header1Style="{DynamicResource Header1SpanStyle}"
                          Header2Style="{DynamicResource Header2SpanStyle}"
                          Header3Style="{DynamicResource Header3SpanStyle}"
                          HorizontalOptions="Center"
                          VerticalOptions="CenterAndExpand">
        </markDown:LabelMd>

        <markDown:LabelMd x:Name="Emoji"
                          TextMarkdown="You rock! :thumbsup:"
                          LineHeight="2"
                          HorizontalOptions="Center"
                          VerticalOptions="Start"></markDown:LabelMd>

    </StackLayout>

</ContentPage>
```


