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

        [Theory]
        [InlineData(1, "JK")]
        [InlineData(2, "DK")]
        [InlineData(3, "PK")]
        public async void GetEmployeebyId(int id, string res)
        {
            // Mok can also be initialized inside a function 
            // var mock = new Mock<interface_name>();

            // mock.Setup(p => p.NameOfTheFunc(Parameter_Value)).ReturnsAsync(The value it should return-);

            mock.Setup(p => p.GetEmployeebyId(id)).ReturnsAsync(res);
            EmployeeController emp = new EmployeeController(mock.Object);
            string result = await emp.GetEmployeeById(id);
            Assert.Equal(res, result);
        }

        [Theory]
        [InlineData(1, "JK", "SDE")]
        [InlineData(2, "DK", "SE")]
        [InlineData(3, "PK", "DBA")]
        public async void GetEmployeeDetails(int id, string name, string designation)
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