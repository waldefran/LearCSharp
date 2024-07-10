using Microsoft.AspNetCore.Mvc;
using WebAppForDev.Models;
using WebAppForDev.Services;

namespace WebAppForDev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _ifuncionarioService;
        public FuncionarioController(IFuncionarioService ifuncionarioService) //Deveria ser IfuncionarioInterface
        {
            _ifuncionarioService = ifuncionarioService;
        }
        // GET: api/Funcionario
        [HttpGet]
        public async Task<ActionResult<ServiceResponseModel<List<FuncionariosModel>>>> GetFuncionarios()
        {
            return Ok(await _ifuncionarioService.GetFuncionarios());
        }


    }
}