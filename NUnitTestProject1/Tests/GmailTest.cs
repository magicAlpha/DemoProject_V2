using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnitFramework.Common;
using NUnitFramework.Pages;
using NUnitFramework.Utils;

namespace NUnitFramework.Tests
{
    class GmailTest : TestBase
    {
        public GmailTest() : base()
        {

        }

        [Test]
        public void VerifyGmailLogin()
        {
            try
            {
                string emailID;
                string password;
                bool testResult;
                emailID = TestData.GetData("User_14EmailAddress");
                password = TestData.GetData("GmailUser_Test1Password");
                GmailPage gmailObj = new GmailPage(TestProgressLogger);
                testResult = gmailObj.Gmail(emailID, password);
                Assert.True(testResult, LogMessage.GMailAssertionFailed);
                TestProgressLogger.LogCheckPoint(LogMessage.GMailTestPassed);
            }
            catch (Exception ex)
            {
                TestProgressLogger.LogError(LogMessage.GMailTestFailed, ex);
                TestProgressLogger.TakeScreenshot();
                throw ex;
            }
        }

        [Test]

        public void VerifyUnreadEmail()
        {
            try
            {
                bool unreadEmail = false;
                Assert.True(unreadEmail, LogMessage.GMailUnreadEmailError);
            }
            catch (Exception ex)
            {
                TestProgressLogger.LogError(LogMessage.GMailTestFailed, ex);
                TestProgressLogger.TakeScreenshot();
                throw ex;
            }
        }

        // Add all the operation which needs to be performed post Test Execution 
        [TearDown]
        public void End()
        {
            
        }
    }
}
