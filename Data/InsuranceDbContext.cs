using InsuranceManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManagementSystem.Data;

public class InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : DbContext(options)
{
    public DbSet<InsurancePolicy> Policies { get; set; }
    public DbSet<InsuranceCase> Cases { get; set; }
}