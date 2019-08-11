using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Repositories;
using InterviewTestTemplatev2.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SynetecMvcUnitTests.MockRepositories;
using System;

namespace SynetecMvcUnitTests
{
    [TestClass]
    public class BonusPoolServiceTests
    {
        private BonusPoolService _bonusPoolService;

        [TestInitialize]
        public void TestInitialize()
        {
            IBonusPoolRepository bonusPoolRepository = new MockBonusPoolRepository();
            _bonusPoolService = new BonusPoolService(bonusPoolRepository);
        }

        [TestMethod]
        public void TestBonusPoolCalculations()
        {
            int totalBonusPool = 50000;

            BonusPoolCalculatorModel bonusPoolCalculatorModel = new BonusPoolCalculatorModel
            {
                AllEmployees = _bonusPoolService.GetEmployeeList(),
                SelectedEmployeeId = _bonusPoolService.GetEmployeeByID(25).ID,
                BonusPoolAmount = totalBonusPool
            };

            decimal? totalSalaryAmount = (decimal)_bonusPoolService.GetEmployeeTotalSalary();
            Assert.IsNotNull(totalSalaryAmount);

            decimal? employeeSalary = (decimal)_bonusPoolService.GetEmployeeByID(25).Salary;
            Assert.IsNotNull(employeeSalary);

            BonusPoolCalculatorResultModel calculatedBonusShared = _bonusPoolService.CalculateEmployeesBonusShare(bonusPoolCalculatorModel);
            Assert.IsNotNull(calculatedBonusShared);
            Assert.IsTrue(calculatedBonusShared.bonusPoolAllocation > 0);
            Assert.IsTrue(calculatedBonusShared.hrEmployee.Salary > 0);


            decimal totalBonusPercentage = (decimal)employeeSalary / (decimal)totalSalaryAmount;
            Assert.IsTrue(totalBonusPercentage > 0 && totalBonusPercentage < 100);

            decimal totalBonus = totalBonusPercentage * totalBonusPool;
            Assert.IsTrue(totalBonus > 0);

            Assert.AreEqual((int)totalBonus, calculatedBonusShared.bonusPoolAllocation);
        }
    }
}
