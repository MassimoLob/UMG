using System.Diagnostics;
using TechTalk.SpecFlow;

namespace TechTestUMG
{

    [Binding]
    public class HookInitialize
    {




        [BeforeScenario]
        public static void TestStart()
        {

        }

        [AfterScenario]

        public void TestStop()
        {
            foreach (var proc in Process.GetProcessesByName("chromedriver"))
            {
                proc.Kill();
            }
            foreach (var proc in Process.GetProcessesByName("chrome"))
            {
                proc.Kill();
            }
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
        }

        [AfterTestRun]
        public static void TearDownReport()
        {

        }

        [BeforeFeature]
        public static void BeforeFeature()
        {

        }

        [AfterStep]
        public void InsertReportingSteps()
        {


        }

    }
}
