using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Label.MarkDown.CustomControl;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.Label.MarkDown
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelMarkdown : LabelMarkdownControl
    {
        public LabelMarkdown()
        {
            InitializeComponent();
        }
    }
}