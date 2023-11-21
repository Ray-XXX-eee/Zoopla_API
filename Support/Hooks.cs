using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using RestSharp;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;

namespace HomeTrack_API.Support
{
    [Binding]
    class Hooks
    {
        /// <summary>
        /// Class : Hooks 
        /// 
        /// Consisting common functions for test manipulation, setup, teardown, reporting etc. 
        /// Can consist any common function rquiring sharing eg : webdriver object | in this problem Rest Client, reporting etc
        /// 
        /// </summary>


        //Globals

        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        static AventStack.ExtentReports.ExtentTest scenario, step;
        private readonly ScenarioContext _scenarioContext;

        static string reportPath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
            + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyy_HHmmss");

        // Constructor : Initialize Scenario context for decoupling
        public Hooks(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }


        [BeforeTestRun]
        public static void BeforeTestRun()
        {   
            //Reporting-initialize
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(reportPath); //*\\HomeTrack_API\\HomeTrack_API\\Report\\"
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        }



        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }



        [BeforeScenario]
        public void BeforeScenario(ScenarioContext _scenarioContext)
        {
            //Common Rest_client instance creation
            Client client = new Client(_scenarioContext);
            _scenarioContext.Set(client, "client");

            //report-related
            scenario = feature.CreateNode(_scenarioContext.ScenarioInfo.Title);

        }
        [BeforeStep]
        public void beforeStep()
        {
            //report-related
            step = scenario;
        }
        [AfterStep]
        public void afterStep(ScenarioContext context)
        {
            //report-related
            if (context.TestError == null)
            {
                step.Log(AventStack.ExtentReports.Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                step.Log(AventStack.ExtentReports.Status.Fail, context.StepContext.StepInfo.Text);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            //report-related
            extent.Flush();

        }


        // implement logic that has to run before executing each scenario


        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}