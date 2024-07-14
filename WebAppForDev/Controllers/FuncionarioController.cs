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
        [HttpGet("GetFuncionarios")]
        public async Task<ActionResult<ServiceResponseModel<List<FuncionariosModel>>>> GetFuncionarios()
        {
            return Ok(await _ifuncionarioService.GetFuncionarios());
        }
        // GET: api/Funcionario/id
        [HttpGet("GetFuncionarios{id}")]
        public async Task<ActionResult<ServiceResponseModel<FuncionariosModel>>> GetFuncionarioById(int id)
        {
            return Ok(await _ifuncionarioService.GetFuncionarioById(id));
        }
        // POST: api/newFuncionario
        [HttpPost("CriaFuncionario")]
        public async Task<ActionResult<ServiceResponseModel<List<FuncionariosModel>>>> AddFuncionario(FuncionariosModel newFuncionario)
        {
            return Ok(await _ifuncionarioService.AddFuncionario(newFuncionario));
        }
        // PUT: api/Funcionario/id
        [HttpPut("InativaFuncionario/{id}")]
        public async Task<ActionResult<ServiceResponseModel<List<FuncionariosModel>>>> InativaFuncionario(int id)
        {
            return Ok(await _ifuncionarioService.InativaFuncionario(id));
        }
        // PUT: api/Funcionario/id
        [HttpPut("AtualizaFuncionario")]
        public async Task<ActionResult<ServiceResponseModel<FuncionariosModel>>> UpdateFuncionario(FuncionariosModel updatedFuncionario)
        {
            return Ok(await _ifuncionarioService.UpdateFuncionario(updatedFuncionario));
        }
        // DELETE: api/Funcionario/id
        [HttpDelete("DeletaFuncionario/{id}")]
        public async Task<ActionResult<ServiceResponseModel<List<FuncionariosModel>>>> DeleteFuncionario(int id)
        {
            return Ok(await _ifuncionarioService.DeleteFuncionario(id));
        }

    }
}