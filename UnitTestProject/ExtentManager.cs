using System;
using System.Collections.Generic;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;


namespace UnitTestProject
{
    class ExtentManager
    {

        /**
         * This method is used to create the Extent report.
         */
        public static ExtentReports SetReportPath(string path)
        {
            
            ExtentReports reports = new ExtentReports();
            reports.AddSystemInfo("Host Name", "YourHostName");
            reports.AddSystemInfo("Environment", "YourQAEnvironment");
            reports.AddSystemInfo("Username", "YourUserName");
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.ReportName = "WebServices Report";
            htmlReporter.Config.Theme = Theme.Dark;
            reports.AttachReporter(htmlReporter);
            return reports;
        }

        public static ExtentTest StartTest(ExtentReports reports, string testName)
        {
            return reports.CreateTest(testName);
        }

        /**
         * This method is to write the contents to the report
         */
        public static void EndTest(ExtentReports reports)
        {
            reports.Flush();
        }
    }
}
