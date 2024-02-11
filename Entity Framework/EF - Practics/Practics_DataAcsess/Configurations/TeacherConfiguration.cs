using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Practics_Model.Entities.Concretes.Carts;
using Practics_Model.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Practics_DataAcsess.Configurations;

internal class TCartConfiguration : IEntityTypeConfiguration<T_Card>
{
    public void Configure(EntityTypeBuilder<T_Card> builder)
    {
        builder.HasOne(s => s.Teacher)
               .WithMany()
               .HasForeignKey(s => s.Id_Teacher);
    }
}