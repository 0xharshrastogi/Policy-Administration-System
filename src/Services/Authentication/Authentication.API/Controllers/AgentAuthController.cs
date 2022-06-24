using Authentication.DTO;
using Authentication.Models;
using Authentication.Repo;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers;

[Route("api/[controller]/Agent")]
[ApiController]
public class AuthController : ControllerBase
{
    private static readonly List<Agent> _agents = new()
    { };

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
    public ActionResult Login(AgentLoginDTO agentLogin)
    {
        if (!ModelState.IsValid) return BadRequest();

        var agent = _agents.SingleOrDefault(a => a.UserName == agentLogin.UserName);
        if (agent is null) return NotFound("User Not Found");

        // using var hmac = new HMACSHA256(agent.Salt);

        // var isValid = hmac
        //     .ComputeHash(Encoding.ASCII.GetBytes(agentLogin.Password))
        //     .SequenceEqual(agent.Password);

        return Ok(new { agent });
    }
}