﻿using Api.TestCase.Steps;
using BussinesObject.UI.Pages;
using Core;
using Core.Selenium;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.UiTests
{
    public class DeleteTestCaseTests : BaseTest
    {
        //[Test]
        //[AllureTag("Positive tests")]
        //[AllureOwner("NotNikita")]
        //[AllureSuite("TestMonitor")]
        //public void DeleteTCTest()
        //{
        //    var testCaseNameForDelete = "Change Account using an Invalid New Password";
        //    var testCaseCodeForDelete = "TC15";
        //    var testSuite = "Feature: My Account";
        //    logger.Message($"Test case for delete: {testCaseNameForDelete}");

        //    var cases = new LoginPage()
        //                .OpenPage()
        //                .Login()
        //                .SelectProject()
        //                .OpenSuites()
        //                .OpenTestSuite(testSuite)
        //                .DeleteTestCase(testCaseNameForDelete)
        //                .DeleteTestCase(testCaseCodeForDelete);

        //    Assert.Throws<NoSuchElementException>(() => cases.GetTestCaseCode(testCaseNameForDelete));
        //    Assert.Throws<NoSuchElementException>(() => cases.GetTestCaseCode(testCaseCodeForDelete));
        //}


        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        public void DeleteTCWithCreatedTestCasesTest()
        {
            var testCase = new ApiTestCaseSteps().CreateTestCase(5);
            logger.Message($"Test case for delete: {testCase.Name}");

            var testSuite = "Feature: My Account";

            var cases = new LoginPage()
                        .OpenPage()
                        .Login()
                        .SelectProject()
                        .OpenSuites()
                        .OpenTestSuite(testSuite);

            cases.DeleteTestCase(testCase.Code);

            Assert.Throws<NoSuchElementException>(() => cases.GetTestNameByCode(testCase.Code));
            Assert.Throws<NoSuchElementException>(() => cases.GetTestCaseCode(testCase.Name));
        }
    }
}