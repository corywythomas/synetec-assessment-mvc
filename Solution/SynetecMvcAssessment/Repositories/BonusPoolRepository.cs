using InterviewTestTemplatev2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Repositories
{
    public class BonusPoolRepository : IBonusPoolRepository
    {
        #region Fields
        private MvcInterviewV3Entities1 _bonusPoolContext;
        #endregion


        #region Constructors
        public BonusPoolRepository(MvcInterviewV3Entities1 bonusPoolContext)
        {
            _bonusPoolContext = bonusPoolContext;
        }

        public List<HrEmployee> GetEmployeeList()
        {
            return _bonusPoolContext.HrEmployees.ToList<HrEmployee>();
        }

        public int GetEmployeeTotalSalary()
        {
            return (int)_bonusPoolContext.HrEmployees.Sum(item => item.Salary);
        }

        public HrEmployee GetEmployeeByID(int selectedEmployeeId)
        {
            return (HrEmployee)_bonusPoolContext.HrEmployees.FirstOrDefault(item => item.ID == selectedEmployeeId);
        }
        #endregion


    }
}