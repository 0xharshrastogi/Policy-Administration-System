using Authentication.DTO;
using Authentication.Extensions;
using Authentication.Models;
using Authentication.Repo;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers;

[Route("api/[controller]/Agent")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAgentRepo _agentRepo;

    private readonly IMapper _mapper;

    public AuthController(IAgentRepo agentRepo, IMapper mapper)
    {
        _agentRepo = agentRepo;
        _mapper = mapper;
    }

    [HttpPost("Signup")]
    public async Task<ActionResult> SignUpAsync(AgentCreateDTO agentCreate)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _agentRepo.CreateAsync(_mapper.Map<Agent>(agentCreate));

        return Created(nameof(SignUpAsync), null);
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login(AgentCredential credential)
    {
        if (!ModelState.IsValid) return BadRequest();

        var agentDetail = await _agentRepo.FindByUserNameAsync(credential.UserName);

        if (agentDetail is null)
            return NotFound("InValid UserName");

        var isCorrect = agentDetail.Compare(credential);

        return Ok(new { isCorrect });
    }
}