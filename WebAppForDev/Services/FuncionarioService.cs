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
            if(response.Data.Count == 0){
                response.Message ="Data is null";
            }


        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        //return await
        return response;
    }
    public async Task<ServiceResponseModel<FuncionariosModel>> GetFuncionarioById(int id)
    {
        ServiceResponseModel<FuncionariosModel> response = new ServiceResponseModel<FuncionariosModel>();
        try
        {
            response.Data = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
            if(response.Data == null){
                response.Message = "Data is null";
                response.IsSuccess = false;
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        return response;
    }
    public async Task<ServiceResponseModel<List<FuncionariosModel>>> AddFuncionario(FuncionariosModel newFuncionario)
    {
        ServiceResponseModel<List<FuncionariosModel>> response = new ServiceResponseModel<List<FuncionariosModel>>();
        try
        {
            _context.Add(newFuncionario);
            await _context.SaveChangesAsync();
            response.Data = await _context.Funcionarios.ToListAsync();
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        return response;
    }
    public async Task<ServiceResponseModel<List<FuncionariosModel>>> InativaFuncionario(int id)
    {
        ServiceResponseModel<List<FuncionariosModel>> response = new ServiceResponseModel<List<FuncionariosModel>>();
        try
        {
            FuncionariosModel funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
            if(funcionario == null){
                response.IsSuccess = false;
                response.Message = "Id is null";
                return response;
            }
            
            funcionario.Ativo = false;
            funcionario.DataAlteracao = DateTime.Now.ToLocalTime();
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
            response.Data = await _context.Funcionarios.ToListAsync();
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        return response;
    }
    public async Task<ServiceResponseModel<FuncionariosModel>> UpdateFuncionario(FuncionariosModel updatedFuncionario)
    {
        ServiceResponseModel<FuncionariosModel> response = new ServiceResponseModel<FuncionariosModel>();
        try
        {
            FuncionariosModel funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == updatedFuncionario.Id);
            if(funcionario == null){
                response.IsSuccess = false;
                response.Message = "Id is null";
                return response;
            }
            funcionario.Nome = updatedFuncionario.Nome;
            funcionario.Sobrenome = updatedFuncionario.Sobrenome;
            funcionario.DataAlteracao = DateTime.Now.ToLocalTime();
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
            response.Data = funcionario;
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        return response;
    }
    public async Task<ServiceResponseModel<List<FuncionariosModel>>> DeleteFuncionario(int id)
    {
        ServiceResponseModel<List<FuncionariosModel>> response = new ServiceResponseModel<List<FuncionariosModel>>();
        try
        {
            FuncionariosModel funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
            if(funcionario == null){
                response.IsSuccess = false;
                response.Message = "Id is null";
                return response;
            }
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            response.Data = await _context.Funcionarios.ToListAsync();
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        return response;
    }
}