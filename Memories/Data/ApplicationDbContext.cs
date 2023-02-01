using System;
using Microsoft.EntityFrameworkCore;

namespace Memories.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{


		}
	}
}

