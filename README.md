# Plugin Label Markdown for Xamarin Forms

[![NuGet Badge](https://buildstats.info/nuget/Plugin.SegmentedControl.Netstandard)](https://www.nuget.org/packages/Plugin.SegmentedControl.Netstandard/)

*Please star this project if you find it useful. Thank you!*

## Why this plugin
Wouldn't it be cool if the Xamarin Label control supported (Markdown)[https://en.wikipedia.org/wiki/Markdown]? 

And how cool would it be if it was possible to include bindable properties inside a Markdown text like this: 
> `There are {{1}} apples in the basket.`


Where `{{1}}` represent the place-holder for the value of the bindable property?

## Platform support

The plugin works on all platforms supported by Xamarin Forms and .NET Standard 2.0.

## Features: 

Markdown supported:
- Headers - H1, H2 & H3
- Bold
- Italic
- Bold-Italic
- Hyperlinks

## XAML Sample
The easied way to introduce the features is by looking at a simple example:

<!-- ![Sample image](https://raw.githubusercontent.com/1iveowl/plugin.label.markdown/develop/images/sample1.png?token=ADCGLUEGHFAPFOSUOVSWFDK5OEZQY =250x) -->

<img src="https://raw.githubusercontent.com/1iveowl/plugin.label.markdown/develop/images/sample1.png?token=ADCGLUEGHFAPFOSUOVSWFDK5OEZQY" width="150"/>



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
                <Setter Property="ForegroundColor"  Value="Blue"></Setter>
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
        <Label Text="Welcome to Xamarin.Forms!" 
           HorizontalOptions="Center"
           VerticalOptions="CenterAndExpand" />

        <markDown:LabelMd x:Name="LabelMarkdownTest1"
                                UrlLinkColor="Purple"
                                Variable1="Var1"
                                Variable3="Var3"
                                TextMarkdown="#Header A  &#x0a;##Header B  &#x0a;###Header C _with italic_  &#x0a;First Line with some _italic text_.  &#x0a;New Line with Variable 1 in bold: **{{1}}**  &#x0a;New line with variable 3: {{3}}  &#x0a;[Link to Google](https://www.google.com) &#x0a;"
                                Header1Style="{DynamicResource Header1SpanStyle}"
                                Header2Style="{DynamicResource Header2SpanStyle}"
                                Header3Style="{DynamicResource Header3SpanStyle}"
                                HorizontalOptions="Center"
                                VerticalOptions="CenterAndExpand"></markDown:LabelMd>
    </StackLayout>

</ContentPage>
```


