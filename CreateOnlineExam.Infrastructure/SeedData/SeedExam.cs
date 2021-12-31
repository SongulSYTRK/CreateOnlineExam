using CreateOnlineExam.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateOnlineExam.Infrastructure.SeedData
{
    public class SeedExam : IEntityTypeConfiguration<ExamPage>
    {
        public void Configure(EntityTypeBuilder<ExamPage> builder)
        {
            builder.HasData(
              new ExamPage { Id = 1, Title= "The James Webb Space Telescope Finally Prepares for Launch", Description= "IN THE MID-1990S, a team of scientists proposed developing a next-generation infrared space probe. Nearly three decades later, after overcoming engineering, logistical, and political challenges, the ambitious spacecraft envisioned as Hubble’s successor will finally blast off. ", ExamDate = DateTime.Parse("2021-12-31"), ExamTime = 30 },
              new ExamPage { Id = 2, Title = "The US Mountain West Could Soon Face Snowless Winters",Description= "Across the Central Rockies, it’s been an unseasonably warm, dry year. Denver smashed the record for its latest first measurable winter snow. Colorado ski resorts delayed opening because temperatures were too high to even produce fake snow. And Salt Lake City was entirely snowless through November, for only the second time since 1976." ,ExamDate = DateTime.Parse("2022-01-31"), ExamTime = 25 },
              new ExamPage { Id = 3, Title = "The Quest to Trap Carbon in Stone—and Beat Climate Change", Description= "IT WAS UNDOUBTEDLY the most august gathering ever convened on the uninhabited lava plains of Hellisheidi, Iceland. Some 200 guests were seated in the modernist three-story visitors’ center of a geothermal power plant—the country’s prime minister and an ex-president, journalists from New York and Paris, financiers from London and Geneva, and researchers and policy wonks from around the world.", ExamDate = DateTime.Parse("2021-12-25"), ExamTime = 50 },
              new ExamPage { Id = 4, Title = "When did life start  ?",Description= "The Quest to Trap Carbon in Stone—and Beat Climate Change", ExamDate = DateTime.Parse("2021-12-29"), ExamTime = 30 });
        }
    }
}
