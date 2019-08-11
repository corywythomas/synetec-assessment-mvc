using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Services
{
    public class BonusPoolService : IBonusPoolService
    {
        #region Fields
        private IBonusPoolRepository _bonusPoolRepository;
        #endregion

        #region Constructors
        public BonusPoolService(IBonusPoolRepository bonusPoolRepository)
        {
            _bonusPoolRepository = bonusPoolRepository;
        }
        #endregion

        public List<HrEmployee> GetEmployeeList()
        {
            return _bonusPoolRepository.GetEmployeeList();
        }

        public int GetEmployeeTotalSalary()
        {
            return _bonusPoolRepository.GetEmployeeTotalSalary();
        }

        public HrEmployee GetEmployeeByID(int selectedEmployeeId)
        {
            return _bonusPoolRepository.GetEmployeeByID(selectedEmployeeId);
        }

        public BonusPoolCalculatorResultModel CalculateEmployeesBonusShare(BonusPoolCalculatorModel model)
        {
            int selectedEmployeeId = model.SelectedEmployeeId;
            int totalBonusPool = model.BonusPoolAmount;

            //load the details of the selected employee using the ID
            HrEmployee hrEmployee = this.GetEmployeeByID(selectedEmployeeId);

            int employeeSalary = hrEmployee.Salary;

            //get the total salary budget for the company
            int totalSalary = this.GetEmployeeTotalSalary();

            //calculate the bonus allocation for the employee
            decimal bonusPercentage = (decimal)employeeSalary / (decimal)totalSalary;
            int bonusAllocation = (int)(bonusPercentage * totalBonusPool);

            BonusPoolCalculatorResultModel result = new BonusPoolCalculatorResultModel();
            result.hrEmployee = hrEmployee;
            result.bonusPoolAllocation = bonusAllocation;

            return result;
        }
    }
}