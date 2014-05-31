using System;
using System.Windows;

namespace RuntimeTutorial
{
    public class TutorialStep
    {
        public TutorialStep(DependencyObject control, StepOptions options = null, Action preAction = null,
            Action postAction = null)
        {
            Control = control as UIElement;
            PreAction = preAction;
            PostAction = postAction;
            Options = options ?? new StepOptions("", "", false);
        }

        public UIElement Control { get; private set; }
        public Action PreAction { get; private set; }
        public Action PostAction { get; private set; }
        public StepOptions Options { get; set; }
    }
}