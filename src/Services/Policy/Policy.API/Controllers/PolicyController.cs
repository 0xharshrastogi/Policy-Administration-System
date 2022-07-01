using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Policy.DTO;
using Policy.Models;

using PolicyMicroservice.DTO;
using PolicyMicroservice.Helper;
using PolicyMicroservice.Models;
using PolicyMicroservice.Repo;

namespace Policy.Controllers;

[ApiController]
[Route("api")]
public class PolicyController : ControllerBase
{
    private readonly IPolicyRepo<CustomerPolicy> _customerPolicyRepo;

    private readonly IIssuedPolicyRepo<IssuedPolicy> _issuedPolicyRepo;

    private readonly IPolicyMasterRepo _policyMasterRepo;

    private readonly IMapper _mapper;

    public PolicyController(IPolicyRepo<CustomerPolicy> repo, IMapper mapper, IIssuedPolicyRepo<IssuedPolicy> issuedPolicyRepo, IPolicyMasterRepo policyMasterRepo)
    {
        _customerPolicyRepo = repo;
        _mapper = mapper;
        _issuedPolicyRepo = issuedPolicyRepo;
        _policyMasterRepo = policyMasterRepo;
    }

    [HttpPost(nameof(CreatePolicy))]
    public async Task<IActionResult> CreatePolicy(CustomerPolicyWriteDTO customerPolicyWrite)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var customerPolicy = await _customerPolicyRepo.CreateAsync(_mapper.Map<CustomerPolicy>(customerPolicyWrite));

        return Created(nameof(CreatePolicy), new
        {

            PolicyStatus = customerPolicy.Status.ToString(),
            Description = "Policy Created Successfully",
            Data = customerPolicy
        });
    }

    [HttpGet(nameof(ViewPolicy))]
    public IActionResult ViewPolicy(Guid? policyId)
    {
        try
        {
            if (policyId != null)
            {
                var policy = _customerPolicyRepo.FindAll().Single(p => p.Id == policyId);
                return Ok(policy);
            }

            return Ok(_customerPolicyRepo.FindAll());
        }
        catch (InvalidOperationException)
        {
            return NotFound(new
            {
                PolicyId = policyId,
                Message = "Policy Not Found"
            });
        }
    }

    [HttpPut($"{nameof(IssuePolicy)}/{{id}}")]
    public async Task<IActionResult> IssuePolicy(Guid id, IssuePolicyCreateDTO issuePolicyCreate)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var mappedIssuedPolicy = _mapper.Map<IssuedPolicy>(issuePolicyCreate);
            mappedIssuedPolicy.PolicyId = id;

            var policy = await _customerPolicyRepo.UpdateStatusAsync(id, PolicyStatus.Issued);
            var issuePolicy = await _issuedPolicyRepo.CreateAsync(mappedIssuedPolicy);

            return Ok(new
            {
                Status = policy.Status.ToString(),
                Description = $"Policy status updated to {policy.Status.ToString().ToLower()}",
                Data = issuePolicy
            });
        }
        catch (PolicyNotFoundExpection)
        {
            return NotFound(new
            {
                PolicyId = id,
                Message = "Policy Not Found"
            });
        }
    }

    [HttpGet(nameof(GetPoliciesByBusinessValue))]
    public IActionResult GetPoliciesByBusinessValue(int businessValue)
    {
        var policyMasters = _policyMasterRepo.FindByBusinessValue(businessValue);
        return Ok(policyMasters);
    }
}