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
	public class ProductoService:IProductoService
	{
		private readonly IProductoRepository _repository;

		public ProductoService(IProductoRepository repository) 
		{
			_repository = repository;
		}

		public async Task AddProductoAsync(CreateProductoDto producto)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(producto.Descripcion))
				{
					throw new Exception("La descripcion del Producto es obligatorio.");
				}
				var product = new Producto
				{
					Descripcion = producto.Descripcion,
					CategoriaId = producto.CategoriaId,
					Cantidad = producto.Cantidad,
					Precio = producto.Precio,
					SuplidorId = producto.SuplidorId,
					FechaDeVencimiento = producto.FechaDeVencimiento,
				};
				await _repository.AddAsync(product);
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al crear el producto: {ex.Message}");
			}
		}

		public async Task DeleteProductoAsync(int id)
		{
			try
			{
				await _repository.DeleteAsync(id);
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al eliminar el producto: {ex.Message}");
			}
		}

		public async Task<IEnumerable<ProductoDto>> GetAllProductoAsync()
		{
			try
			{
				var productos = await _repository.GetAllProducto();
				if (productos == null || !productos.Any())
				{
					throw new Exception("No se encontraron productos.");
				}
				return productos.Select(p => new ProductoDto
				{
					Id = p.Id,
					Descripcion = p.Descripcion,
					CategoriaId = p.CategoriaId,
					Cantidad = p.Cantidad,
					Precio = p.Precio,
					SuplidorId = p.SuplidorId,
					FechaDeVencimiento = p.FechaDeVencimiento
				});
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al obtener los Productos: {ex.Message}");
			}
		}

		public async Task<ProductoDto> GetProductoById(int id)
		{
			try
			{
				var producto = await _repository.GetByIdAsync(id);
				if(producto == null)
				{
					throw new Exception($"El producto con el id:{id} no existe");
				}
				return new ProductoDto
				{
					Descripcion = producto.Descripcion,
					CategoriaId = producto.CategoriaId,
					Cantidad = producto.Cantidad,
					Precio = producto.Precio,
					SuplidorId = producto.SuplidorId,
					FechaDeVencimiento = producto.FechaDeVencimiento
				};
			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al obtener el producto: {ex.Message}");
			}
		}

		public async Task UpdatePrdouctoAsync(int id, UpdateProductoDto producto)
		{
			try
			{
				var updateCategoria = await _repository.GetByIdAsync(id);
				if(updateCategoria == null)
				{
					throw new Exception($"Producto con id:{id} no existe");
				}
				updateCategoria.Descripcion = producto.Descripcion;
				updateCategoria.CategoriaId = producto.CategoriaId;
				updateCategoria.Cantidad = producto.Cantidad;
				updateCategoria.Precio = producto.Precio;
				updateCategoria.SuplidorId = producto.SuplidorId;
				updateCategoria.FechaDeVencimiento = producto.FechaDeVencimiento;

				await _repository.UpdateAsync(updateCategoria);

			}
			catch (Exception ex)
			{

				throw new Exception($"Ocurrió un error al actualizar el producto: {ex.Message}");
			}
		}
	}
}
