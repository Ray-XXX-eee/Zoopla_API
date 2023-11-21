using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HomeTrack_API.Support
{
    [Binding]
    public class Client
    {
        /// <summary>
        /// Class : Client 
        /// 
        /// Setting up Class for base url & Rest Client abstraction
        /// Can be further extended to be driven by sql or excel as data store (eg : several endpoints POST/GET/UPDATE & chaining)
        /// 
        /// </summary>
        

        //Globals
        private RestClient _client;
        private readonly ScenarioContext _scenarioContext;
        private string _baseUrl;

        public Client(ScenarioContext scenarioContext)
        {

            _scenarioContext = scenarioContext;
            _baseUrl = "https://www.purgomalum.com/service";
            _scenarioContext.Set(_baseUrl, "_baseUrl");

        }

        public RestClient clientMethod()
        {
            _client = new RestClient(_baseUrl);
            _scenarioContext.Set(_client, "client");
            return _client;
        }
    }
}
