using Moq;
using System.Reflection.Metadata;
using UnitTest_MokApp.Controllers;  
using UnitTest_MokApp.Model;  
using UnitTest_MokApp.Services;  
using Xunit;  
  
namespace UnitTest_MokApp_TestProj
{
    public class EmployeeTest
    {
        #region Property  
        public Mock<IEmployeeService> mock = new Mock<IEmployeeService>();
       
        #endregion

        [Fact]
        
        public async void GetEmployeebyId()
        {
            // Mok can also be initialized inside a function 
            // var mock = new Mock<interface_name>();

            // mock.Setup(p => p.NameOfTheFunc(Parameter_Value)).ReturnsAsync(The value it should return-);

            mock.Setup(p => p.GetEmployeebyId(1)).ReturnsAsync("JK");
            EmployeeController emp = new EmployeeController(mock.Object);
            string result = await emp.GetEmployeeById(1);
            Assert.Equal("JK", result);
        }
        [Fact]
        public async void GetEmployeeDetails()
        {
            var employeeDTO = new Employee()
            {
                Id = 1,
                Name = "JK",
                Desgination = "SDE"
            };
            mock.Setup(p => p.GetEmployeeDetails(1)).ReturnsAsync(employeeDTO);
            EmployeeController emp = new EmployeeController(mock.Object);
            var result = await emp.GetEmployeeDetails(1);
            Assert.True(employeeDTO.Equals(result));
        }
    }
}