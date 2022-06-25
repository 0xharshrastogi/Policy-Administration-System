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

    private static string CreateJWT(IDictionary<string, string> keyValues)
    {
        var expires = DateTime
                .UtcNow
                .AddMinutes(15);

        return Jwt.CreateToken(keyValues, expires);
    }

    private void InsertTokenToCookie(string token) => Response
            .Cookies
            .Append("jwt_token", token, new()
            {
                Expires = DateTime
                .UtcNow
                .AddMinutes(15)
            });

    [HttpPost(nameof(Signup))]
    public async Task<ActionResult> Signup(AgentCreateDTO agentCreate)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest();

            var agent = _mapper.Map<Agent>(agentCreate);

            await _agentRepo.CreateAsync(agent);

            var expires = DateTime
                .UtcNow
                .AddMinutes(15);

            var token = CreateJWT(new Dictionary<string, string>
            {
                [nameof(agent.UserName)] = agent.UserName,
                [nameof(agent.Id)] = agent.Id.ToString()
            });

            InsertTokenToCookie(token);

            return Created(nameof(Signup), null);
        }
        catch (Exception ex) when (ex.Message == AgentRepo.DUPLICATEUSERNAME)
        {
            return Conflict($"Duplicate UserName : {agentCreate.UserName}");
        }
    }

    [HttpPost(nameof(Login))]
    public async Task<ActionResult> Login(AgentCredential credential)
    {
        if (!ModelState.IsValid) return BadRequest();

        var agent = await _agentRepo.FindByUserNameAsync(credential.UserName);

        if (agent is null) return NotFound("InValid UserName");

        var isCorrectCredential = agent.Compare(credential);

        if (!isCorrectCredential) return Unauthorized("Invalid Credentials");

        var token = CreateJWT(new Dictionary<string, string>
        {
            [nameof(agent.UserName)] = agent.UserName,
            [nameof(agent.Name)] = agent.Name,
        });

        InsertTokenToCookie(token);
        return Ok();
    }

    [HttpGet(nameof(Signout))]
    public IActionResult Signout()
    {
        var isValidToken = Request.Cookies.TryGetValue("jwt_token", out var token)
            && string.IsNullOrEmpty(token!.Trim());

        if (isValidToken) return BadRequest("Already Signout");

        Response
            .Cookies
            .Append("jwt_token", string.Empty, new() { Expires = DateTimeOffset.MinValue });

        return Ok();
    }

    [HttpGet("Validate")]
    public IActionResult Validate()
    {
        var token = Request.Cookies["jwt_token"];
        if (string.IsNullOrEmpty(token) || string.IsNullOrWhiteSpace(token))
            return Unauthorized();

        var jwtSecurityHandler = new JwtSecurityTokenHandler();
        if (!jwtSecurityHandler.CanReadToken(token))
            return BadRequest("Value is not a valid JWT token");

        var securityToken = jwtSecurityHandler.ReadJwtToken(token);

        if (DateTime.UtcNow > securityToken.ValidTo)
        {
            Response
                .Cookies
                .Append("jwt_token", string.Empty, new() { Expires = DateTimeOffset.MinValue });
        }

        return Ok();
    }
}