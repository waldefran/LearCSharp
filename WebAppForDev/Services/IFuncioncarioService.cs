using WebAppForDev.Models;

namespace WebAppForDev.Services;

public interface IFuncionarioService
{
    Task<ServiceResponseModel<List<FuncionariosModel>>> GetFuncionarios();
    Task<ServiceResponseModel<FuncionariosModel>> GetFuncionarioById(int id);
     Task<ServiceResponseModel<List<FuncionariosModel>>> AddFuncionario(FuncionariosModel newFuncionario);
    Task<ServiceResponseModel<List<FuncionariosModel>>> InativaFuncionario(int id);
    Task<ServiceResponseModel<FuncionariosModel>> UpdateFuncionario(FuncionariosModel updatedFuncionario);
    Task<ServiceResponseModel<List<FuncionariosModel>>> DeleteFuncionario(int id);
}
