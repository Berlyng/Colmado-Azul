using Colamdo_Azul.domain.Entities.Models;
using Colmado_Azul.infractructure.Interface;
using Colmado_Azul.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colmado_Azul.infractructure.Repositories
{
	public class ProductoRepository:IProductoRepository
	{
		private readonly ColmadoAzulContext _context;
		private readonly DbSet<Producto> _dbSet;

		public ProductoRepository(ColmadoAzulContext context)
		{
			_context = context;
			_dbSet = context.Set<Producto>();
		}

		public async Task AddAsync(Producto producto)
		{
			await _dbSet.AddAsync(producto);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var producto = await _dbSet.FindAsync(id);
			if (producto != null)
			{
				_dbSet.Remove(producto);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Producto>> GetAllProducto()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<Producto> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task UpdateAsync(Producto producto)
		{
			_dbSet.Update(producto);
			await _context.SaveChangesAsync();
		}
	}
}
