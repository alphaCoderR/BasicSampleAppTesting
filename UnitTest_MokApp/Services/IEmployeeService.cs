using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using UnitTest_MokApp.Model;  
  
namespace UnitTest_MokApp.Services
{
    public interface IEmployeeService
    {
        Task<string> GetEmployeebyId(int EmpID);
        Task<Employee> GetEmployeeDetails(int EmpID);
    }
}