using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace RuntimeTutorial
{
    public partial class TutorialWindow : Window
    {
        private readonly Tutorial _tutorial;

        public TutorialWindow(Tutorial tutorial)
        {
            InitializeComponent();

            _tutorial = tutorial;
            TxtContent.Text = _tutorial.StartText;
            BtnClose.Content = _tutorial.CloseButtonText;
        }

        private void GotoNextStep()
        {
            var step = _tutorial.GetNextStep();
            if (step == null)
            {
                TxtContent.Text = _tutorial.EndText;
                BtnNext.Visibility = Visibility.Hidden;
                return;
            }

            BtnNext.Content = String.IsNullOrEmpty(step.Options.NextButtonText) ? "Next" : step.Options.NextButtonText;
            TxtContent.Text = step.Options.Description;

            var control = step.Control as ICommandSource;

            if (step.Options.AutoExecuteCommand && control != null)
            {
                if (control.Command != null)
                {
                    control.Command.Execute(control);
                }
            }

            if (step.PostAction != null)
            {
                step.PostAction();
            }
        }


        private void BtnNext_OnClick(object sender, RoutedEventArgs e)
        {
            GotoNextStep();
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TutorialWindow_OnClosing(object sender, CancelEventArgs e)
        {
            _tutorial.Clear();
        }
    }
}