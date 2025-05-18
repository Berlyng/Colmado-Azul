using Colmado_Azul.application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colmado_Azul.api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CategoriaController : ControllerBase
	{
		private readonly ICategoriaService _service;
		public CategoriaController(ICategoriaService service)
		{
			_service = service;
		}

		[HttpGet (Name ="Get Category")]
		public async Task<ActionResult> GetAllCategoria()
		{
			try
			{
				var categorias = await _service.GetAllCategoriasAsync();
				return Ok(categorias);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}
