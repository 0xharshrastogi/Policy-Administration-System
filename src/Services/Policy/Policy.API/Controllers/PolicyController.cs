using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using PolicyMicroservice.DTO;
using PolicyMicroservice.Helper;
using PolicyMicroservice.Models;
using PolicyMicroservice.Repo;

namespace PolicyMicroservice.Controllers;

[ApiController]
[Route("api")]
public class PolicyController : ControllerBase
{
    private readonly IPolicyRepo<CustomerPolicy> _customerPolicyRepo;

    private readonly IIssuedPolicyRepo<IssuedPolicy> _issuedPolicyRepo;

    private readonly IMapper _mapper;

    public PolicyController(IPolicyRepo<CustomerPolicy> repo, IMapper mapper, IIssuedPolicyRepo<IssuedPolicy> issuedPolicyRepo)
    {
        _customerPolicyRepo = repo;
        _mapper = mapper;
        _issuedPolicyRepo = issuedPolicyRepo;
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
    public IActionResult ViewPolicy(Guid policyId)
    {
        try
        {
            var policy = _customerPolicyRepo.FindAll().Single(p => p.Id == policyId);
            return Ok(policy);
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

            var updatePolicyTask = _customerPolicyRepo.UpdateStatusAsync(id, PolicyStatus.Issued);
            var issuePolicyCreateTask = _issuedPolicyRepo.CreateAsync(mappedIssuedPolicy);

            await Task.WhenAll(updatePolicyTask, issuePolicyCreateTask);

            var policy = updatePolicyTask.Result;
            var issuePolicy = issuePolicyCreateTask.Result;

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
}