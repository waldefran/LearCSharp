using Microsoft.AspNetCore.Mvc;

namespace WebAppForDev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncioncarioService _funcionarioService;
        public FuncionarioController(IFuncioncarioService ifuncionarioService) //Deveria ser IfuncionarioInterface
        {
            _funcionarioService = ifuncionarioService;
        }
        // GET: api/Funcionario
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get all funcionarios");
        }


    }
}