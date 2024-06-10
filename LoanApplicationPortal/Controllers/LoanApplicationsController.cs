using LoanApplicationPortal.LoanContext;
using LoanApplicationPortal.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationPortal.Controllers
{
    public class LoanApplicationsController : Controller
    {
       private readonly LoanDbContext _context;

        public LoanApplicationsController(LoanDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
  
        [HttpPost] 
        [ValidateAntiForgeryToken]
       /* public async Task<IActionResult> Create([Bind("Name,Address,DateOfBirth,Email,HomeOwner,LoanRequestAmount")] LoanApplication loanApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loanApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Success), new { id = loanApplication.Id });
            }
            return View(loanApplication);
        }*/

        [HttpGet]
       /* public async Task<IActionResult> Success(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanApplication = await _context.LoanApplications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loanApplication == null)
            {
                return NotFound();
            }

            decimal monthlyInterestRate = 0.15m;
            int loanTermMonths = 18;
            decimal monthlyRepayment = (loanApplication.LoanRequestAmount * (1 + monthlyInterestRate * loanTermMonths)) / loanTermMonths;
            decimal totalAmountPayable = monthlyRepayment * loanTermMonths;

            ViewBag.MonthlyRepayment = monthlyRepayment;
            ViewBag.TotalAmountPayable = totalAmountPayable;

            return View(loanApplication);
        }*/

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoanApplications.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanApplication = await _context.LoanApplications.FindAsync(id);
            if (loanApplication == null)
            {
                return NotFound();
            }
            return View(loanApplication);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,DateOfBirth,Email,HomeOwner,LoanRequestAmount,Status")] LoanApplication loanApplication)
        {
            if (id != loanApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                /*try
                {*/
                    _context.Update(loanApplication);
                    await _context.SaveChangesAsync();
               /* }*/
               /* catch (DbUpdateConcurrencyException)
                {
                    if (!LoanApplicationExists(loanApplication.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }*/
                return RedirectToAction(nameof(Index));
            }
            return View(loanApplication);
        }

       /* private bool LoanApplicationExists(int id)
        {
            return _context.LoanApplications.Any(e => e.Id == id);
        }*/
    }
}
