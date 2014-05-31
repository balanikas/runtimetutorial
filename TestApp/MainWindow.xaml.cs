using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RuntimeTutorial;

namespace TestApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenTutorial(object sender, RoutedEventArgs e)
        {
            //setup tutorial
            var tutorial = new Tutorial(this);
            tutorial.StartText = "Welcome to this tutorial. We will show you how you can use the app";
            tutorial.EndText = "Thank you! You may restart the tutorial at any time";
            tutorial.CloseButtonText = "Ok, got it";


            //setup tutorial steps
            var step1Options = new StepOptions("This button opens the tutorial", "", false);
            var step2Options = new StepOptions("This part describes what the app does", "Ok", false);
            var step3Options = new StepOptions("Select the 'Capitalize' tab", "", false);
            var step4Options = new StepOptions("This text will be CAPITALIZED in the next step", "Reverse text", false);
            var step5Options = new StepOptions("By clicking here the text is CAPITALIZED", "", false);

            //define steps
            tutorial.AddStep<Button>("BtnOpenTutorial", 0, step1Options);
            tutorial.AddStep<TextBlock>("TxtSample", 1, step2Options);
            tutorial.AddStep(TabControl, 2, step3Options, () => { TabControl.SelectedIndex = 1; });
            tutorial.AddStep<TextBox>("TxtCapitalize", 3, step4Options);
            tutorial.AddStep<Button>("BtnCapitalize", 4, step5Options,
                () => { TxtCapitalize.Text = CapitalizeString(TxtReverse.Text); });

            //create and show tutorial
            var tutorialWindow = new TutorialWindow(tutorial);
            tutorialWindow.ShowDialog();
        }


        private void BtnReverse_OnClick(object sender, RoutedEventArgs e)
        {
            TxtReverse.Text = ReverseString(TxtReverse.Text);
        }

        private string ReverseString(string value)
        {
            return new string(value.Reverse().ToArray());
        }

        private string CapitalizeString(string value)
        {
            return value.ToUpper();
        }

        private void BtnCapitalize_OnClick(object sender, RoutedEventArgs e)
        {
            TxtCapitalize.Text = CapitalizeString(TxtCapitalize.Text);
        }
    }
}