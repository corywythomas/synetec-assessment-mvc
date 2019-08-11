using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Repositories;
using InterviewTestTemplatev2.Services;
using System.Web.Mvc;


namespace InterviewTestTemplatev2.Controllers
{
    public class BonusPoolController : Controller
    {
        private BonusPoolService _bonusPoolService;

        //public BonusPoolController(BonusPoolRepository bonusPoolRepository)
        //{
        //    _bonusPoolRepostiory = bonusPoolRepository;
        //}

        public BonusPoolController()
        {
            _bonusPoolService = new BonusPoolService(new BonusPoolRepository(new MvcInterviewV3Entities1()));
        }

        // GET: BonusPool
        public ActionResult Index()
        {
            BonusPoolCalculatorModel model = new BonusPoolCalculatorModel();

            model.AllEmployees = _bonusPoolService.GetEmployeeList();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(BonusPoolCalculatorModel model)
        {
            BonusPoolCalculatorResultModel result = _bonusPoolService.CalculateEmployeesBonusShare(model);
            
            return View(result);
        }
    }
}