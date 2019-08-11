using System.Collections.Generic;
using InterviewTestTemplatev2.Data;

namespace InterviewTestTemplatev2.Repositories
{
    public interface IBonusPoolRepository
    {
        HrEmployee GetEmployeeByID(int selectedEmployeeId);
        List<HrEmployee> GetEmployeeList();
        int GetEmployeeTotalSalary();
    }
}