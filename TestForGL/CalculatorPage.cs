using NUnit.Framework;
using TestStack.White;
using System.IO;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;

namespace TestForGL
{
    class CalculatorPage
    {
        static Window window;
        public CalculatorPage()
        {
            string applicationDirectory = TestContext.CurrentContext.TestDirectory;

            // Just add your AvalonCalculator path like @"D:\Files\AvalonCalculator"
            string applicationPath = Path.Combine(applicationDirectory, @"D:\PROJECTS\Global Logic Test Task\AvalonCalculator");
            Application application = Application.Launch(applicationPath);
            window = application.GetWindow("WPF Calculator", InitializeOption.NoCache);
        }

        public Button CloseDialogWindow
        {
            get
            {
                return (Button)window.Get(SearchCriteria.ByAutomationId("2"));
            }
            private set { }
        }

        public Button Btn0 {
            get
            {
                return (Button)window.Get(SearchCriteria.ByAutomationId("B0"));
            }
            private set { }
        }

        public Button BtnDivide
        {
            get
            {
                return (Button)window.Get(SearchCriteria.ByAutomationId("BDevide"));
            }
            private set { }
        }

        public Button BtnEqual
        {
            get
            {
                return (Button)window.Get(SearchCriteria.ByAutomationId("BEqual"));
            }
            private set { }
        }

        public Button[] BtnsToClick(string input)
        {
            Button[] result = new Button[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                string autoId = "B" + input[i];
                result[i] = (Button)window.Get(SearchCriteria.ByAutomationId(autoId));
            }
            return result;
        }

        public TextBox DividingResult
        {
            get
            {
                return (TextBox)window.Get(SearchCriteria.ByAutomationId("txtHistory"));
            }
            private set { }
        }

    }
}
