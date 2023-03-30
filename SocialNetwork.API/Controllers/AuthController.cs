using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Application.DTOs;
using SocialNetwork.Domain.Entites;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialNetwork.API.Controllers;


[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager, IConfiguration Configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = Configuration;
    }


    [HttpGet]
    public ActionResult<string> Get()
    {
        return "AuthController::Acessado em:" + DateTime.Now.ToString();

    }
    
    [HttpPost("Register")]
    public async Task<ActionResult> RegisterUser([FromBody] UsuarioDTO model)
    {
        var user = new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email,
            EmailConfirmed = true,


        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        await _signInManager.SignInAsync(user, false);
        return Ok(GenerateToken(model));
    }
    
    [HttpPost("Login")]
    public async Task<ActionResult> Login(UsuarioDTO userInfo)
    {

        //verifica as credenciais do usuário e retorna o valor
        var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password,
            isPersistent: false, lockoutOnFailure: false);//se tentar +3x vai bloquear

        if (result.Succeeded)
        {
            return Ok(GenerateToken(userInfo));
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Login Inválido.");
            return BadRequest(ModelState);
        }
    }

    private UserToken GenerateToken(UsuarioDTO userInfo)
    {
        //define declaracoes do usuario
        var claims = new[]
        {
             new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
         };

        //gera uma chave com base em um algoritmo simetrico
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        //gera a assinatura digital do token usando a algoritmo Hmac e a chave privada
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //tempo de expiracao do token.
        var expiracao = _configuration["TokenConfiguration:ExpiryTimeInDays"];
        var expiration = DateTime.UtcNow.AddDays(double.Parse(expiracao));

        //classe que representa um token Jwt e gera o token
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["TokenConfiguration:Issuer"],
            audience: _configuration["TokenConfiguration:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
            );
        return new UserToken()
        {
            Authenticated = true,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration,
            Message = "Token Jwt gerado."
        };

    }

}
