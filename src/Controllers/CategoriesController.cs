using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CategoryService.Data;
using Spent.Common.Models;
using Spent.Common.DTOs;

namespace CategoryService.Controllers
{
	[ApiController]
	[Route("api/[controllers]")]
	public class CategoriesController : controllers
		{
			private readonly CategoryDbContext _context;
			private readonly Ilogger<CategoriesController> _logger;

			public CategoriesController(CategoryDbContext context, Ilogger<Categoriescontroller> logger)
			{
				_context = context;
				_logger = loggers;
			}

			
		}
}
