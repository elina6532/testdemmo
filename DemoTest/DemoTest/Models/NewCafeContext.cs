using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DemoTest.Models;

public partial class NewCafeContext : DbContext
{
    public NewCafeContext()
    {
    }

    public NewCafeContext(DbContextOptions<NewCafeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderitem> Orderitems { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<Shifttype> Shifttypes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;database=newCafe;password=ELINA2030", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.IdPosition, "Id_Position");

            entity.HasIndex(e => e.IdStatus, "Id_Status");

            entity.Property(e => e.IdEmployee).HasColumnName("Id_Employee");
            entity.Property(e => e.Adress).HasMaxLength(40);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IdPosition).HasColumnName("Id_Position");
            entity.Property(e => e.IdStatus).HasColumnName("Id_Status");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Passport).HasMaxLength(20);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdPosition)
                .HasConstraintName("employee_ibfk_2");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("employee_ibfk_1");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PRIMARY");

            entity.ToTable("menu");

            entity.Property(e => e.IdMenu).HasColumnName("Id_Menu");
            entity.Property(e => e.Cost).HasPrecision(19, 2);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(30);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.IdEmployee, "Id_Employee");

            entity.Property(e => e.IdOrder).HasColumnName("Id_Order");
            entity.Property(e => e.IdEmployee).HasColumnName("Id_Employee");
            entity.Property(e => e.OrderStatus).HasMaxLength(20);
            entity.Property(e => e.OrderTotalAmount).HasPrecision(19, 2);

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("orders_ibfk_1");
        });

        modelBuilder.Entity<Orderitem>(entity =>
        {
            entity.HasKey(e => e.IdOrderItem).HasName("PRIMARY");

            entity.ToTable("orderitem");

            entity.HasIndex(e => e.IdMenu, "Id_Menu");

            entity.HasIndex(e => e.IdOrder, "Id_Order");

            entity.Property(e => e.IdOrderItem).HasColumnName("Id_OrderItem");
            entity.Property(e => e.IdMenu).HasColumnName("Id_Menu");
            entity.Property(e => e.IdOrder).HasColumnName("Id_Order");
            entity.Property(e => e.Price).HasPrecision(19, 2);

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("orderitem_ibfk_2");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("orderitem_ibfk_1");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition).HasName("PRIMARY");

            entity.ToTable("positions");

            entity.Property(e => e.IdPosition).HasColumnName("Id_Position");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.IdShift).HasName("PRIMARY");

            entity.ToTable("shift");

            entity.HasIndex(e => e.IdEmployee, "Id_Employee");

            entity.HasIndex(e => e.IdShiftType, "Id_ShiftType");

            entity.Property(e => e.IdShift).HasColumnName("Id_Shift");
            entity.Property(e => e.IdEmployee).HasColumnName("Id_Employee");
            entity.Property(e => e.IdShiftType).HasColumnName("Id_ShiftType");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("shift_ibfk_1");

            entity.HasOne(d => d.IdShiftTypeNavigation).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.IdShiftType)
                .HasConstraintName("shift_ibfk_2");
        });

        modelBuilder.Entity<Shifttype>(entity =>
        {
            entity.HasKey(e => e.IdShiftType).HasName("PRIMARY");

            entity.ToTable("shifttype");

            entity.Property(e => e.IdShiftType).HasColumnName("Id_ShiftType");
            entity.Property(e => e.EndTime).HasMaxLength(20);
            entity.Property(e => e.ShiftName).HasMaxLength(30);
            entity.Property(e => e.StartTime).HasMaxLength(20);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.IdStatus).HasColumnName("Id_Status");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
