using Microsoft.EntityFrameworkCore;
using WebAppForDev.Models;
using WebAppForDev.Models.DataContext;

namespace WebAppForDev.Services;

public class FuncionarioService : IFuncionarioService

{
    private readonly ApplicationDbContext _context;
    public FuncionarioService(ApplicationDbContext context)
    {
        _context = context;
    }
//corrigir GetFuncionarios

    public async Task<ServiceResponseModel<List<FuncionariosModel>>> GetFuncionarios()
    {
        ServiceResponseModel<List<FuncionariosModel>> response = new ServiceResponseModel<List<FuncionariosModel>>();
        try
        {

            response.Data = await _context.Funcionarios.ToListAsync();

        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        //return await
        return response;
    }
    // task<ServiceResponseModel<FuncionariosModel>> IFuncionarioService.GetFuncionarioById(int id)
    // {
    //     throw new NotImplementedException();
    // }
    // task<ServiceResponseModel<List<FuncionariosModel>>> IFuncionarioService.AddFuncionario(FuncionariosModel newFuncionario)
    // {
    //     throw new NotImplementedException();
    // }
    // task<ServiceResponseModel<FuncionariosModel>> IFuncionarioService.UpdateFuncionario(FuncionariosModel updatedFuncionario)
    // {
    //     throw new NotImplementedException();
    // }
    // task<ServiceResponseModel<List<FuncionariosModel>>> IFuncionarioService.DeleteFuncionario(int id)
    // {
    //     throw new NotImplementedException();
    // }
    // task<ServiceResponseModel<List<FuncionariosModel>>> IFuncionarioService.InativaFuncionario(int id)
    // {
    //     throw new NotImplementedException();
    // }
}