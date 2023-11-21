using System;
using System.Linq;
using System.Text.Json.Nodes;
using AventStack.ExtentReports.Gherkin.Model;
using Dynamitey.Internal.Optimization;
using HomeTrack_API.Support;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

[Binding]
public class ProfanityParams_StepDef
{
    /*
     * Class : ProfanityParams_StepDef
     *     Contains Step definition functions for API Calls using Parameters 
     */



    // Globals
    RestClient client;
    private RestResponse response;
    private RestRequest request;
    private string inputText;
    private readonly ScenarioContext _scenarioContext;


    //Initializing senarioContext to access common client in the const
    public ProfanityParams_StepDef(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }



    // Step Definitions

    // SD 1

    [Given(@"the replacement text is ""(.*)""")]
    public void GivenTheInputTextIs(string input)
    {
        inputText = input;
    }

    // SD 2

    [When(@"the user chosees ""([^""]*)"" word to replace by ""([^""]*)""  word & execute")] 
    public void WhenTheUserChoseesWordAndExecute(string add, string target)
    {
        
        client = _scenarioContext.Get<Client>("client").clientMethod();
        var request = new RestRequest("xml", Method.Get);
        request.AddQueryParameter("text", inputText);
        request.AddQueryParameter("add", add);
        request.AddQueryParameter("fill_text", target);

        
        Console.WriteLine("start");
        response = client.Execute(request);
        TestContext.Out.WriteLine(response.Content);
        Console.WriteLine("response : -- "+response.Content.ToString());
        Console.WriteLine("end");
    }



}