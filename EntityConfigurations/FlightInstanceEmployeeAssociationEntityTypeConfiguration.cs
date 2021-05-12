using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.EntityConfigurations
{
    public class FlightInstanceEmployeeAssociationEntityTypeConfiguration : IEntityTypeConfiguration<FlightInstanceEmployeeAssociation>
    {
        public void Configure(EntityTypeBuilder<FlightInstanceEmployeeAssociation> entity)
        {
            entity.ToTable("Flight_Instance_Employee_Association", "c");
            entity.HasKey(e => e.flightInstanceEmployeeAssociationId);
            entity.Property(e => e.flightInstanceEmployeeAssociationId).ValueGeneratedOnAdd().HasColumnName("flight_instance_employee_association_id");
            entity.Property(e => e.employeeId).IsRequired().HasColumnName("employee_Id");
            entity.Property(e => e.flightInstanceId).IsRequired().HasColumnName("flight_instance_id");

            entity.HasOne(e => e.flightInstance)
                    .WithMany(s => s.FlightInstanceEmployeelist)
                    .HasForeignKey(s => s.flightInstanceId);

            entity.HasOne(e => e.employee)
                    .WithMany(s => s.FlightInstanceEmployeelist)
                    .HasForeignKey(s => s.employeeId);
        }
    }
}
