using System;
using System.Linq;
using System.Text.Json.Nodes;
using AventStack.ExtentReports.Gherkin.Model;
using HomeTrack_API.Support;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

[Binding]
public class ProfanityMethods_StepDef
{
    /*
    * Class : ProfanityParams_StepDef
    *     Contains Stepdefinition functions for API Calls using Parameters 
    */


    // Globals
    RestClient client;
    private RestResponse response;
    private RestRequest request;
    private string inputText;
    private readonly ScenarioContext _scenarioContext;



    //Initializing senarioContext to access common client in the const
    public ProfanityMethods_StepDef(ScenarioContext scenarioContext) {
        _scenarioContext = scenarioContext;
        }



    /// Step Definitions :

    
    // StepDef 1

    [Given(@"the input text is ""(.*)""")]
    public void GivenTheInputTextIs(string input)
    {
        inputText = input;
    }

    // StepDef 2

    [When(@"the user calls ""(.*)"" endpoint")]
    public void WhenTheUserCallsEndpoint(string endPoint_type)
    {
        client = _scenarioContext.Get<Client>("client").clientMethod();
        request = new RestRequest(endPoint_type, Method.Get);
        request.AddQueryParameter("text", inputText);
        response = client.Execute(request);
    }


    [When(@"the user calls containsprofanity endpoint")]
    public void WhenTheUserCallsContainsprofanityEndpoint()
    {
        client = new RestClient("https://www.purgomalum.com/service/containsprofanity?");
        request = new RestRequest("json", Method.Get);
        request.AddQueryParameter("text", inputText);
        response = client.Execute(request);

    }


    // StepDef 3

    [Then(@"the response should contain valid XML")]
    public void ThenTheResponseShouldContainValidXML()
    {
        Console.WriteLine("xml verify :  "+response.ContentType);
        Assert.That(response.ContentType.Contains("application/xml"));
    }

    // StepDef 4

    [Then(@"the response should contain valid JSON")]
    public void ThenTheResponseShouldContainValidJSON()
    {
        //JObject obs = JObject.Parse(response.Content);
        Console.WriteLine("JSON verify :  " + response.ContentType);
        Assert.That(response.ContentType.Contains("application/json"));
    }


    // StepDef 5

    [Then(@"the response should contain valid TXT")]
    public void ThenTheResponseShouldContainValidTXT()
    {
        Console.WriteLine("TXT verify :  " + response.ContentType);
        Assert.That(response.ContentType.Contains("text"));
    }

    // StepDef 6

    [Then(@"the response should contain  False value")]
    public void ThenTheResponseShouldContainFalseValue()
    {
        JObject obj = JObject.Parse(response.Content);
        Assert.AreEqual(obj["result"].ToString(), inputText);
    }

    // StepDef 7

    [Then(@"the response should contain  True value")]
    public void ThenTheResponseShouldContainTrueValue()
    {
        JObject obj = JObject.Parse(response.Content);
        Assert.AreNotEqual(obj["result"].ToString(), inputText);
    }

    // StepDef 8 

    [Then(@"the response should contain asterix")]
    public void ShouldContainAsterix() 
    {
        if (response.ContentType.Contains("application/json"))
        {
            JObject obj = JObject.Parse(response.Content);
            Assert.AreNotEqual(obj["result"].ToString(), inputText);
        }
        else if (response.ContentType.Contains("text"))
        {
            Assert.AreNotEqual(response.Content.ToString(), inputText);
        }
        else if (response.ContentType.Contains("application/xml"))
        {
            Console.WriteLine("   need to parse xml ");
        }
        else 
        { Console.WriteLine("Type error (xml,txt, json) "); }
    }

    // StepDef 9

    [Then(@"the response should not contain asterix")]
    public void ShouldNotContainAsterix()
    {
        if (response.ContentType.Contains("application/json"))
        {
            JObject obj = JObject.Parse(response.Content);
            Assert.AreEqual(obj["result"].ToString(), inputText);
        }
        else if (response.ContentType.Contains("text"))
        {
            Console.WriteLine("Debugging ......   " +response.ContentType+"   ----    "+ response.Content);
            Assert.AreEqual(response.Content, inputText);
        }
        else if (response.ContentType.Contains("application/xml"))
        {
            Console.WriteLine("   need to parse xml ");
        }
        else
        { Console.WriteLine("Type error (xml,txt, json) "); }
    }


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///














}

