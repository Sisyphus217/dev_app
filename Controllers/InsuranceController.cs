using InsuranceManagementSystem.Data;
using InsuranceManagementSystem.Models;
using InsuranceManagementSystem.Factories;
using InsuranceManagementSystem.Observers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InsuranceController : ControllerBase
{
    private readonly InsuranceDbContext _context;
    private readonly IPolicyFactory _factory;
    private readonly InsuranceCaseService _caseService;

    public InsuranceController(InsuranceDbContext context, CreatePolicyFactory factory, InsuranceCaseService caseService,
        LoggingService loggingService)
    {
        _context = context;
        _factory = factory;
        _caseService = caseService;

    }

    [HttpPost("create-policy")]
    public async Task<IActionResult> CreatePolicy([FromBody] InsurancePolicy request)
    {
        var policy = _factory.CreatePolicy(request.PolicyType, request.PolicyHolderName);
        _context.Policies.Add(policy);
        await _context.SaveChangesAsync();

        return Ok(policy);
    }

    [HttpPost("create-case")]
    public async Task<IActionResult> CreateCase(int policyId)
    {
        var policy = await _context.Policies.FindAsync(policyId);
        if (policy == null) return NotFound("Policy not found");

        var insuranceCase = new InsuranceCase
        {
            PolicyId = policyId,
            Policy = policy,
            Status = CaseStatus.Pending
        };
        _context.Cases.Add(insuranceCase);
        await _context.SaveChangesAsync();

        return Ok(insuranceCase);
    }

    [HttpPut("update-status/{id}")]
    public async Task<IActionResult> UpdateStatus(int id, int statusCode)
    {
        var insuranceCase = await _context.Cases.Include(c => c.Policy).FirstOrDefaultAsync(c => c.Id == id);
        if (insuranceCase == null) return NotFound("Case not found");

        insuranceCase.Status = (CaseStatus)statusCode;
        _context.Cases.Update(insuranceCase);
        await _context.SaveChangesAsync();

        // Уведомляем наблюдателей
        await _caseService.NotifyAsync(insuranceCase);

        return Ok(insuranceCase);
    }
}