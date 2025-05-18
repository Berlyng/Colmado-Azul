using Colamdo_Azul.domain.Entities.Models;
using Colmado_Azul.application.Interface;
using Colmado_Azul.common.Dtos;
using Colmado_Azul.infractructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colmado_Azul.application.Service
{
	public class SuplidorService:ISuplidoraService
	{
		private readonly ISuplidorRepository _repository;

		public SuplidorService(ISuplidorRepository repository)
		{
			_repository = repository;
		}

		public async Task AddSuplidorAsync(CreateSuplidorDto suplidor)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(suplidor.NombreDeEmpresa))
				{
					throw new Exception("El nombre de la Empresa es obligatorio.");
				}
				var createSuplidora = new Suplidor
				{
					NombreDeEmpresa = suplidor.NombreDeEmpresa,
					Correo = suplidor.Correo,
					Telefono = suplidor.Telefono,
					Direccion = suplidor.Direccion,
				};

				await _repository.AddAsync(createSuplidora);
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al crear el suplidor: {ex.Message}");
			}
		}

		public async Task DeleteSuplidorAsync(int id)
		{
			try
			{
				await _repository.DeleteAsync(id);
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al crear el suplidor: {ex.Message}");
			}
		}

		public async Task<IEnumerable<SuplidorDto>> GetAllSuplidorAsync()
		{
			try
			{
				var suplidora = await _repository.GetAllSuplidorAsync();
				if (suplidora == null || !suplidora.Any())
				{
					throw new Exception("No hay registros de Suplidora existentes");
				}
				return suplidora.Select(s => new SuplidorDto
				{
					Id = s.Id,
					NombreDeEmpresa = s.NombreDeEmpresa,
					Correo = s.Correo,
					Telefono = s.Telefono,
					Direccion = s.Direccion
				});
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al obtener los suplidores: {ex.Message}");
			}
		
		}

		public async Task<SuplidorDto> GetSuplidorByIdAsync(int id)
		{
			try
			{
				var suplidor = await _repository.GetSuplidorById(id);
				if(suplidor == null)
				{
					throw new Exception($"El suplidor con id:{id} no fue encontrado");
				}
				return new SuplidorDto
				{
					NombreDeEmpresa = suplidor.NombreDeEmpresa,
					Correo = suplidor.Correo,
					Telefono = suplidor.Telefono,
					Direccion = suplidor.Direccion

				};
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al obtene el suplidor: {ex.Message}");
			}
		}

		public async Task UpdateSuplidorAsync(int id, UpdateSuplidorDto suplidor)
		{
			try
			{
				var updateSuplidor = await GetSuplidorByIdAsync(id);
				updateSuplidor.NombreDeEmpresa = suplidor.NombreDeEmpresa;
				updateSuplidor.Correo = suplidor.Correo;
				updateSuplidor.Telefono = suplidor.Telefono;
				updateSuplidor.Direccion = suplidor.Direccion;
				
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al actualizar al suplidor: {ex.Message}");
			}
		}
	}
}
