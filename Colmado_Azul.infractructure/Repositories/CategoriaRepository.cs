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
	public class CategoriaRepository : ICategoriaRepository
	{
		private readonly ColmadoAzulContext _context;
		private readonly DbSet<Categoria> _dbSet;

		public CategoriaRepository (ColmadoAzulContext context)
		{
			_context = context;
			_dbSet = context.Set<Categoria>();
		}

		public async Task AddAsycn(Categoria categoria)
		{
			await _dbSet.AddAsync(categoria);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var categoria = await _dbSet.FindAsync(id);
			if (categoria != null)
			{
				_dbSet.Remove(categoria);
				await _context.SaveChangesAsync();
			} 
		}

		public async Task <IEnumerable<Categoria>> GetAllCategoria()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<Categoria> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task UpdateAsync(Categoria categoria)
		{
			_dbSet.Update(categoria);
			await _context.SaveChangesAsync();
		}
	}
}
