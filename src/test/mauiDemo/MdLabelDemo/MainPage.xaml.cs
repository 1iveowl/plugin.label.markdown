namespace MdLabelDemo
{
    public partial class MainPage : ContentPage
    {
        bool originalStyle = true;

        int count = 0;
        public string Var1 { get; set; } = "Var1";

        public MainPage()
        {



            //var rd = new ResourceDictionary();

            //var baseStyle = new Style(typeof(Element))
            //{
            //    BaseResourceKey = "baseStyle",
            //};

            //rd.Add(baseStyle);

            //TestLabel1.Resources.MergedDictionaries.Add(rd);


            InitializeComponent();

            if (App.Current is not null &&
                App.Current.Resources.MergedDictionaries.Any(d => d.TryGetValue("StyleB", out var x)))
            {

            }
            else
            {
                
            }



            //var styleA = new Style(typeof(Span))
            //{
            //    BasedOn = baseStyle,
            //};

            //styleA.Setters.Add(new Setter { Property = Span.FontSizeProperty, Value = "24" });
            //styleA.Setters.Add(new Setter { Property = Span.TextColorProperty, Value = Colors.Red });

            //var styleB = new Style(typeof(Span))
            //{
            //    BasedOn = baseStyle,
            //};

            //styleB.Setters.Add(new Setter { Property = Span.FontSizeProperty, Value = "32" });
            //styleB.Setters.Add(new Setter { Property = Span.TextColorProperty, Value = Colors.Blue });

            //rd.Add("StyleA", styleA);
            //rd.Add("StyleB", styleB);

            //TestLabel1.Resources.MergedDictionaries.Add(rd);

            //TestLabel1.Resources["TestStyle"] = TestLabel1.Resources["StyleA"];
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

        private void OnChangeStyleButtonClicked(object sender, EventArgs e)
        {
            if (originalStyle)
            {
                TestLabel1.Resources["Header1StyleA"] = TestLabel1.Resources["StyleB"];
                originalStyle = false;
            }
            else
            {
                TestLabel1.Resources["Header1StyleA"] = TestLabel1.Resources["StyleC"];
                originalStyle = true;
            }
        }
    }
}