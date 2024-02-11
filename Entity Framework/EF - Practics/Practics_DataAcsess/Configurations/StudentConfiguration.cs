using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practics_Model.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practics_Model.Entities.Concretes.Carts;
using System.Reflection.Emit;
#nullable disable

namespace Practics_DataAcsess.Configurations;

internal class SCartConfiguration : IEntityTypeConfiguration<S_Card>
{
    public void Configure(EntityTypeBuilder<S_Card> builder)
    {
        builder.HasOne(s => s.Student)
               .WithMany()
               .HasForeignKey(s => s.Id_Student);
    }
}
