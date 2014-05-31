﻿namespace RuntimeTutorial
{
    public class StepOptions
    {
        public StepOptions(string description, string nextButtonText, bool autoExecuteCommand)
        {
            Description = description;
            NextButtonText = nextButtonText;
            AutoExecuteCommand = autoExecuteCommand;
        }

        public bool AutoExecuteCommand { get; set; }
        public string NextButtonText { get; set; }
        public string Description { get; set; }
    }
}