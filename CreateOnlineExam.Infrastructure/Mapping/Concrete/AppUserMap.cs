
using CreateOnlineExam.Domain.Entities.Concrete;
using CreateOnlineExam.Infrastructure.Mapping.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Infrastructure.Mapping.Interface
{
   public  class AppUserMap: BaseMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Imagepath).HasMaxLength(250).IsRequired(true);


            builder.Property(x => x.UserName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.NormalizedUserName).HasMaxLength(50).IsRequired(true);

            base.Configure(builder);
        }
    }
}
