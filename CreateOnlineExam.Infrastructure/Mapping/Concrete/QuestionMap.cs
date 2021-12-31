using CreateOnlineExam.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Infrastructure.Mapping.Concrete
{
    public class QuestionMap:BaseMap<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x=>x.Id);
     
            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.A).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.B).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.C).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.D).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Answer).IsRequired(true);
            builder.Property(x => x.CorrectAnswer).HasMaxLength(50).IsRequired(true);


            builder.HasOne(x => x.ExamPage)
               .WithMany(x => x.Questions)
               .HasForeignKey(x => x.ExamPageId);

            base.Configure(builder);
            
        }
    }
}
