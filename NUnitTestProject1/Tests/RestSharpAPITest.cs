using System;
using System.Net;
using NUnit.Framework;
using NUnitFramework.Utils;
using RestSharp;
using RestSharp.Authenticators;
using RestSharpAPIAutomationTest;
using Assert = NUnit.Framework.Assert;

namespace NUnitFramework.Tests
{

    public class RestSharpAPITest : TestBase
    {
        public RestSharpAPITest() : base()
        {

        }

        RestAPIHelper restAPIHelper;
                
        [Test]
        public void VerifyGetRequest()
        {
            int responseStatusCode;
            string responseStatus;
            string baseURL = TestData.GetData("BaseURL");
            string endPointURL = TestData.GetData("GetRequestEndpoint");
            try
            {
                restAPIHelper = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreateGETRequest();
                IRestResponse response = RestAPIHelper.GetResponse();
                String responseFromGetRequest = response.Content;                
                Console.WriteLine(responseFromGetRequest);               
                HttpStatusCode statusCode = response.StatusCode;
                responseStatusCode = (int)statusCode;
                responseStatus = statusCode.ToString();
                TestProgressLogger.LogCheckPoint(String.Format(LogMessage.GETAPIResponseMessage, responseStatusCode, responseStatus));
                Assert.AreEqual(responseStatusCode, Const.HTTP_RESPONSE_CODE_200, LogMessage.IncorrectResponseStatusCode);
                Assert.AreEqual(responseStatus, Const.HTTP_RESPONSE_STATUS_OK, LogMessage.IncorrectResponseStatus);
                TestProgressLogger.LogCheckPoint(LogMessage.GETAPITestPassed);
            }
            catch (Exception ex)
            {
                TestProgressLogger.LogError(LogMessage.GETAPITestFailed, ex);
                TestProgressLogger.TakeScreenshot();
                throw ex;
            }
        }        

        [Test]
        public void VerifyPostRequest()
        {
            int responseStatusCode;
            string responseStatus;
            string baseURL = TestData.GetData("BaseURL");
            string endPointURL = TestData.GetData("PostRequestEndpoint");
            string enterIdNumber = TestData.GetData("PostRequestID");
            string activitiesNumber = TestData.GetData("PostRequestActivitiesNumber");
            try
            {
                restAPIHelper = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreatePOSTRequest(enterIdNumber, activitiesNumber);
                IRestResponse response = RestAPIHelper.GetResponse();
                String singleUserActivitiesInfo = response.Content;
                Console.WriteLine(singleUserActivitiesInfo);
                HttpStatusCode httpStatusCode = response.StatusCode;
                responseStatusCode = (int)httpStatusCode;
                responseStatus = response.StatusCode.ToString();
                TestProgressLogger.LogCheckPoint(String.Format(LogMessage.POSTAPIResponseMessage, responseStatusCode, responseStatus));
                Assert.AreEqual(responseStatusCode, Const.HTTP_RESPONSE_CODE_200, LogMessage.IncorrectResponseStatusCode);
                Assert.AreEqual(responseStatus, Const.HTTP_RESPONSE_STATUS_OK, LogMessage.IncorrectResponseStatus);
                TestProgressLogger.LogCheckPoint(LogMessage.POSTAPITestPassed);
            }
            catch (Exception ex)
            {
                TestProgressLogger.LogError(LogMessage.POSTAPITestFailed, ex);
                TestProgressLogger.TakeScreenshot();
                throw ex;
            }
        }


        [Test]
        public void VerifyDeleteRequest()
        {
            int responseStatusCode;
            string responseStatus;
            string baseURL = TestData.GetData("BaseURL");
            string endPointURL = TestData.GetData("DeleteRequestEndpoint");
            string userIdNumber = TestData.GetData("DeleteRequestID");
            string enterValue = Const.Backslash + userIdNumber;
            try
            {
                restAPIHelper = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreateDELETERequest(enterValue);
                IRestResponse response = RestAPIHelper.GetResponse();
                String responseFromGetRequest = response.Content;
                Console.WriteLine(responseFromGetRequest);
                HttpStatusCode statusCode = response.StatusCode;
                responseStatusCode=(int)statusCode;
                responseStatus = statusCode.ToString();
                TestProgressLogger.LogCheckPoint(String.Format(LogMessage.DELETEAPIResponseMessage, responseStatusCode, responseStatus));
                Assert.AreEqual(responseStatusCode, Const.HTTP_RESPONSE_CODE_200, LogMessage.IncorrectResponseStatusCode);
                Assert.AreEqual(responseStatus, Const.HTTP_RESPONSE_STATUS_OK, LogMessage.IncorrectResponseStatus);
                TestProgressLogger.LogCheckPoint(LogMessage.DELETEAPITestPassed);
            }
            catch (Exception ex)
            {
                TestProgressLogger.LogError(LogMessage.DELETEAPITestFailed, ex);
                TestProgressLogger.TakeScreenshot();
                throw ex;
            }
        }

        [Test]
        public void VerifyPutRequest()
        {
            int responseStatusCode;
            string responseStatus;
            string baseURL = TestData.GetData("PUTRequestURL");
            string endPointURL = TestData.GetData("PUTRequestEndpoint");
            string enterId = TestData.GetData("PutRequestID");
            string photoInfoURL = TestData.GetData("PutPhotoInfoURL");
            string photoInfoTitle = TestData.GetData("PutPhotoInfoTitle");
            try
            {
                restAPIHelper = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreatePUTRequest(enterId, photoInfoURL, photoInfoTitle);
                IRestResponse response = RestAPIHelper.GetResponse();
                // This will get content of executed requested method 
                String responseFromAPI = response.Content;
                HttpStatusCode statusCode = response.StatusCode;
                responseStatusCode = (int)statusCode;
                responseStatus = statusCode.ToString();
                TestProgressLogger.LogCheckPoint(String.Format(LogMessage.PUTAPIResponseMessage, responseStatusCode, responseStatus));
                if (!responseFromAPI.Contains(Const.PutAPIResponse))
                {
                    Assert.Fail(LogMessage.PUTAPIFailureResponseMessage);
                }
                Assert.AreEqual(responseStatusCode, Const.HTTP_RESPONSE_CODE_200, LogMessage.IncorrectResponseStatusCode);
                Assert.AreEqual(responseStatus, Const.HTTP_RESPONSE_STATUS_OK, LogMessage.IncorrectResponseStatus);
                TestProgressLogger.LogCheckPoint(LogMessage.PUTAPITestPassed);
            }
            catch (Exception ex)
            {
                TestProgressLogger.LogError(LogMessage.PUTAPITestFailed, ex);
                TestProgressLogger.TakeScreenshot();
                throw ex;
            }
        }

        [TearDown]
        public void End()
        {
            driver.Quit();
        }
    }
}
