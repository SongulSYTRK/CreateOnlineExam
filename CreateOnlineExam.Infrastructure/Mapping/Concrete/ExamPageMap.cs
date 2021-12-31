using CreateOnlineExam.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Infrastructure.Mapping.Concrete
{
   public class ExamPageMap:BaseMap<ExamPage>
    {
        public override void Configure(EntityTypeBuilder<ExamPage> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(true);


            builder.HasMany(x => x.Questions)
               .WithOne(x => x.ExamPage)
               .HasForeignKey(x => x.ExamPageId)
               .OnDelete(DeleteBehavior.Restrict);

         

        }
    }
}
