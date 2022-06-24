using System.IdentityModel.Tokens.Jwt;

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
        if (!ModelState.IsValid) return BadRequest();

        var agent = _mapper.Map<Agent>(agentCreate);

        if (false)
            await _agentRepo.CreateAsync(agent);

        var expires = DateTime
            .UtcNow
            .AddMinutes(1);

        var token = Jwt.CreateToken(
            keyValues: new Dictionary<string, string>
            {
                [nameof(agent.UserName)] = agent.UserName,
                [nameof(agent.Name)] = agent.Name,
                [nameof(agent.Id)] = agent.Id.ToString()
            },
            expires
        );

        Response
            .Cookies
            .Append("jwt_token", token, new() { Expires = expires });

        return Created(nameof(SignUpAsync), null);
    }

    [HttpGet("Login")]
    public async Task<ActionResult> Login(AgentCredential credential)
    {
        if (!ModelState.IsValid) return BadRequest();

        var agentDetail = await _agentRepo.FindByUserNameAsync(credential.UserName);

        if (agentDetail is null)
            return NotFound("InValid UserName");

        var isCorrect = agentDetail.Compare(credential);

        return Ok(new { isCorrect });
    }

    [HttpGet("Validate")]
    public IActionResult Validate()
    {
        var token = Request.Cookies["jwt_token"];
        if (string.IsNullOrEmpty(token) || string.IsNullOrWhiteSpace(token))
            return Unauthorized();

        var jwtSecurityHandler = new JwtSecurityTokenHandler();
        if (!jwtSecurityHandler.CanReadToken(token)) return BadRequest("Value is not a valid JWT token");

        var securityToken = jwtSecurityHandler.ReadJwtToken(token);

        if (DateTime.UtcNow > securityToken.ValidTo)
        {

        }

        return Ok(new { securityToken.Claims, securityToken.ValidTo });
    }
}