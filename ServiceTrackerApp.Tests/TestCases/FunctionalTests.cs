
using ServiceTrackerApp.DAL;
using ServiceTrackerApp.DAL.Interface;
using ServiceTrackerApp.DAL.Repository;
using ServiceTrackerApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ServiceTrackerApp.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IServiceTrackerInterface _serviceTrackerService;
        public readonly Mock<IServiceTrackerRepository> servicetrackerservice = new Mock<IServiceTrackerRepository>();
        private readonly Service _Service;
        private readonly IEnumerable<Service> ServiceList;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _serviceTrackerService = new ServiceTrackerService(servicetrackerservice.Object);
            _output = output;
            _Service = new Service
            {
                Id = 1,
                Date = DateTime.Now,
                ServiceName = "Exercise",
                IsCompleted = true,
                Notes = "30 minutes of jogging in the park."
            };
             ServiceList = new List<Service>
        {
            new Service
            {
               Id = 1,
                Date = DateTime.Now,
                ServiceName = "Exercise",
                IsCompleted = true,
                Notes = "30 minutes of jogging in the park."
            },
            new Service
            {
                Id = 1,
                Date = DateTime.Now,
                ServiceName = "Exercise",
                IsCompleted = true,
                Notes = "30 minutes of jogging in the park."
            },
        };

        }

        [Fact]
        public async Task<bool> Testfor_Get_Service()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                 servicetrackerservice.Setup(repos => repos.GetServices()).Returns(ServiceList);
                var result =  _serviceTrackerService.GetServices();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Get_Service_ById()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                servicetrackerservice.Setup(repos => repos.GetServiceByID(_Service.Id)).Returns(_Service);
                var result = _serviceTrackerService.GetServiceByID(_Service.Id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Update_Service()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                servicetrackerservice.Setup(repos => repos.UpdateService(_Service)).Returns(true);
                var result=_serviceTrackerService.UpdateService(_Service);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Delete_Service()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                servicetrackerservice.Setup(repos => repos.DeleteService(_Service.Id)).Returns(1);
                var result=_serviceTrackerService.DeleteService(_Service.Id);

                //Assertion
                if (result!= null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}