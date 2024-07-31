using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HandsOnEFDBFirst.Entities;

public partial class MyDb1Context : DbContext
{
    public MyDb1Context()
    {
    }

    public MyDb1Context(DbContextOptions<MyDb1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<EmpDetail> EmpDetails { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<IdentityEx> IdentityExes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<VwEmpDept> VwEmpDepts { get; set; }

    public virtual DbSet<VwEmployeeDetail> VwEmployeeDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-UQPO8UJ;Initial Catalog=MyDB1;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CompanyName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ContactName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Customerid)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptCode).HasName("dept_pk");

            entity.ToTable("Department");

            entity.HasIndex(e => e.DeptName, "UQ__Departme__B744FF0F0ABF9C2A").IsUnique();

            entity.Property(e => e.DeptCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Dept_code");
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Dept_Name");
        });

        modelBuilder.Entity<EmpDetail>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__employee__AF2DBA7936203741");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("EmpID");
            entity.Property(e => e.Dept1Code)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DEPT1_code");
            entity.Property(e => e.Designation)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmpAge).HasColumnName("emp_age");
            entity.Property(e => e.EmpName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Dept1CodeNavigation).WithMany(p => p.EmpDetails)
                .HasForeignKey(d => d.Dept1Code)
                .HasConstraintName("employee_fk01");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Gender");

            entity.Property(e => e.Gender1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<IdentityEx>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Identity__3214EC071C00C30D");

            entity.ToTable("Identity_Ex");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__Product__C5705938C356F61D");

            entity.ToTable("Product");

            entity.HasIndex(e => e.Pname, "UQ__Product__42B4608304D46C94").IsUnique();

            entity.Property(e => e.Pid).ValueGeneratedNever();
            entity.Property(e => e.Pname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PName");
        });

        modelBuilder.Entity<VwEmpDept>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_emp_dept");

            entity.Property(e => e.Dept1Code)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DEPT1_code");
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Dept_Name");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EmpName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<VwEmployeeDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_employeeDetails");

            entity.Property(e => e.Designation)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EmpName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
