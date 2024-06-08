using Moq;
using UnitTest_MokApp.Controllers;
using UnitTest_MokApp.Model;
using UnitTest_MokApp.Services;

namespace NUnit_MokApp_TestProj
{
    public class EmployeeTest
    {
        public Mock<IEmployeeService> mock = new Mock<IEmployeeService>();

        [Test]
        [TestCase(1,"JK")]
        [TestCase(2, "PK")]
        [TestCase(3, "DK")]
        public async Task GetEmployeebyId(int id, string mockResult)
        {
            mock.Setup(p => p.GetEmployeebyId(id)).ReturnsAsync(mockResult);
            EmployeeController emp = new EmployeeController(mock.Object);
            string result = await emp.GetEmployeeById(id);
            Assert.AreEqual(mockResult, result);
        }

        
        
        [Test]
        [TestCase(1, "JK", "SDE")]
        [TestCase(2, "DK", "SE")]
        [TestCase(3, "PK", "DBA")]
        public async Task GetEmployeeDetails(int id, string name, string designation)
        {
            var employeeDTO = new Employee()
            {
                Id = id,
                Name = name,
                Desgination = designation
            };
            mock.Setup(p => p.GetEmployeeDetails(id)).ReturnsAsync(employeeDTO);
            EmployeeController emp = new EmployeeController(mock.Object);
            var result = await emp.GetEmployeeDetails(id);
            Assert.True(employeeDTO.Equals(result));
        }
    }
}

/*
 * // ****** Setting up parametrized test cases with conditioning ********
 * ****** In NUnit ******
    [Test]
    [TestCase(200,100)]
    [TestCase(200,150)]
    [TestCase(200,300)]

    public void funcName(balance, withdrawAmt)
    {
        var logMock = new Mock<InterfaceName>();

        // This func1 will return true for any string value
        logMock.Setup(u=>u.func1(It.IsAny<string>())).Returns(true);

        // This func2 will return true if there is an integer passed asnd the integer should be greater than 0
        logMock.Setup(u=>u.func2(It.Is<int>(x=>x>0))).Returns(true);

        testClass tc = new(logMock.Object);
        testClass.testFunc1(balance);
        var result = testClass.testFunc2(withdraw);
        Assert.IsTrue(result);
    }
 */