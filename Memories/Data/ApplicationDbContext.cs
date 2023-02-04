using System;
using Memories.Models;
using Microsoft.EntityFrameworkCore;

namespace Memories.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Family>? Families { get; set; }

		public DbSet<Address>? Addresses { get; set; }

		public DbSet<Picture>? Pictures { get; set; }

		public DbSet<FamilyMember>? FamilyMembers { get; set; }


			}
}

