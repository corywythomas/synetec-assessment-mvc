using System.Collections.Generic;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;

namespace InterviewTestTemplatev2.Services
{
    public interface IBonusPoolService
    {
        BonusPoolCalculatorResultModel CalculateEmployeesBonusShare(BonusPoolCalculatorModel model);
        HrEmployee GetEmployeeByID(int selectedEmployeeId);
        List<HrEmployee> GetEmployeeList();
        int GetEmployeeTotalSalary();
    }
}