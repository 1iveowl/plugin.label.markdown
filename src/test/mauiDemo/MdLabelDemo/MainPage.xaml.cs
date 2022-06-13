namespace MdLabelDemo
{
    public partial class MainPage : ContentPage
    {
        bool originalStyle = true;

        int count = 0;
        public string Var1 { get; set; } = "Var1";

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void OnMarkdownUpdate(object sender, EventArgs e)
        {
            Markdown.Text = "# Header 0  " + Markdown.Text;
            //if (originalStyle)
            //{
            //    Resources["Header1Style"] = TestLabel1.Resources["StyleB"];
            //    originalStyle = false;
            //}
            //else
            //{
            //    Resources["Header1Style"] = Resources["StyleC"];
            //    originalStyle = true;
            //}
        }
    }
}