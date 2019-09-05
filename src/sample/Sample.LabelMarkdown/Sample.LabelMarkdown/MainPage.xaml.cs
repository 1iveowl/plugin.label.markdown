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
            
            //LabelMarkdownTest2.TextMarkdown = "Line one\nLine two\n";

            //LabelMarkdownTest.TextMarkdown= "Start _bold text_ stop  \r\n" +
            //                                "Next line";
        }
    }
}
