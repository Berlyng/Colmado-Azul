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
	public class SuplidorRepository : ISuplidorRepository
	{
		private readonly ColmadoAzulContext _context;
		private readonly DbSet<Suplidor> _dbSet;
		public SuplidorRepository(ColmadoAzulContext context) {

			_context = context;
			_dbSet = context.Set<Suplidor>();		
		}
		public async Task AddAsync(Suplidor suplidor)
		{
			await _dbSet.AddAsync(suplidor);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var suplidor = await _dbSet.FindAsync(id);
			if (suplidor != null)
			{
				_dbSet.Remove(suplidor);
				await _context.SaveChangesAsync();
			}

		}

		public async Task<IEnumerable<Suplidor>> GetAllSuplidorAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<Suplidor> GetSuplidorById(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task UpdateAsync(Suplidor suplidor)
		{
			_dbSet.Update(suplidor);
			await _context.SaveChangesAsync();
		}
	}
}
