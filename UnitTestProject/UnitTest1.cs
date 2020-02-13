using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using AventStack.ExtentReports;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1 
    {

        private ExtentReports reports;
        private ExtentTest test;

        [TestMethod]
        public void PostMethodTest()
        {
            reports = ExtentManager.SetReportPath(@"E:\Reports\");
            ExtentManager.StartTest(reports, "API POST TEST");
            RestClient client = null;
            RestRequest request = null;
            JObject jObjectbody = null;
            client = new RestClient("http://restapi.demoqa.com/customer");
            request = new RestRequest("/register", Method.POST, DataFormat.Json);
            jObjectbody = new JObject();
            jObjectbody.Add("FirstName", "Naraaayn");
            jObjectbody.Add("LastName", "Kaluri");
            jObjectbody.Add("UserName", "NaraaaynKasdfsdfluri");
            jObjectbody.Add("Password", "Passwovasdfsdaf23");
            jObjectbody.Add("Email", "abcdafssad@hotmail.com");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.BadRequest, response.Content.ToString());
            ExtentManager.EndTest(reports);
        }
    }
}
