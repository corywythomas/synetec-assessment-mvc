using Bogus;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynetecMvcUnitTests.MockRepositories
{
    public class MockBonusPoolRepository : IBonusPoolRepository
    {
        #region Fields
        private List<HrEmployee> _bogusHrEmployees = new List<HrEmployee>();
        #endregion

        /// <summary>
        /// Creates a fake, in memory, set of data to be generated on the fly and used
        /// in unit tests.
        /// </summary>
        public MockBonusPoolRepository()
        {
            _bogusHrEmployees = new Faker<HrEmployee>()
                                .RuleFor(o => o.ID, f => f.IndexFaker)
                                .RuleFor(o => o.DateOfBirth, f => f.Person.DateOfBirth)
                                .RuleFor(o => o.FistName, f => f.Person.FirstName)
                                .RuleFor(o => o.SecondName, f => f.Person.LastName)
                                .RuleFor(o => o.Full_Name, f => f.Person.FullName)
                                .RuleFor(o => o.HrDepartmentId, f => f.Random.Int(0, 4))
                                .RuleFor(o => o.JobTitle, f => f.Name.JobTitle())
                                .RuleFor(o => o.Salary, f => f.Random.Int(30000, 120000))
                                .Generate(50);
        }

        public HrEmployee GetEmployeeByID(int selectedEmployeeId)
        {
            return _bogusHrEmployees.FirstOrDefault(e => e.ID == selectedEmployeeId);
        }

        public List<HrEmployee> GetEmployeeList()
        {
            return _bogusHrEmployees;
        }

        public int GetEmployeeTotalSalary()
        {
            return _bogusHrEmployees.Sum(e => e.Salary);
        }
    }
}
