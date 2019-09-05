using System.ComponentModel;
using Xamarin.Forms;

namespace Sample.LabelMarkdown
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public string Var1 { get; set; } = "Var1";

        public MainPage()
        {
            InitializeComponent();

            //LabelMarkdownTest2.TextMarkdown = "#Header 1\r\n" +
            //                                  "##Header 2\r\n" +
            //                                  "###Header 3 _with italic_\r\n" +
            //                                  "First Line with some _italic text_.\r\n" +
            //                                  "New Line with Variable 1 in italic-bold: ***{{1}}***\r\n" +
            //                                  "New line with variable 3: {{3}}\r\n" +
            //                                  "[Link to Bing](https://www.bing.com)";
        }
    }
}
