using Colamdo_Azul.domain.Entities.Models;
using Colmado_Azul.application.Interface;
using Colmado_Azul.common.Dtos;
using Colmado_Azul.infractructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Colmado_Azul.application.Service
{
	public class CategoriaService: ICategoriaService
	{
		private readonly ICategoriaRepository _repository;

		public CategoriaService(ICategoriaRepository repository)
		{
			_repository = repository;
		}

		public async Task AddCategoriaAsync(CreateCategoriaDto categoria)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(categoria.Descripcion))
				{
					throw new Exception("La descripcion es obligatorio");
				}

				var categoriaDto = new Categoria
				{
					Descripcion = categoria.Descripcion,
				};

				await _repository.AddAsycn(categoriaDto);
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al crear las categorías: {ex.Message}");
			}
		}

		public async Task DeleteCategoriaAsync(int id)
		{
			try
			{
				await _repository.DeleteAsync(id);
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al eliminar las categorías: {ex.Message}");
			}
		}

		public async Task<IEnumerable<CategoriaDto>> GetAllCategoriasAsync()
		{
			try
			{
				var categorias = await _repository.GetAllCategoria();
				if (categorias == null || !categorias.Any())
				{
					throw new Exception("No se encontraron categorías.");
				}
				return categorias.Select(c => new CategoriaDto
				{
					Id = c.Id,
					Descripcion = c.Descripcion,
				});
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al obtener las categorías: {ex.Message}");
			}
		}

		public async Task<CategoriaDto> GetCategoriaByIdAsync(int id)
		{
			try
			{
				var categoria = await _repository.GetByIdAsync(id);
				if (categoria == null)
				{
					throw new Exception($"Categoría con ID {id} no encontrada.");
				}

				return new CategoriaDto
				{
					Id = categoria.Id,
					Descripcion = categoria.Descripcion
				};
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al obtener las categorías: {ex.Message}");
			}
		}

		public async Task UpdateCategoriaAsync(int id, UpdateCategoriaDto categria)
		{
			try
			{
				var categoria = await _repository.GetByIdAsync(id);
				if(categoria == null)
				{
					throw new Exception($"Categoría con ID {id} no encontrada.");
				}

				categoria.Descripcion = categria.Descripcion;
				await _repository.UpdateAsync(categoria);
			}
			catch (Exception ex)
			{
				throw new Exception($"Ocurrió un error al actualizar las categorías: {ex.Message}");

			}
		}
	}
}
