using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLNS.Domain.Entities;

namespace QLNS.API.Domain.Configurations
{
    public class AppConfigConfiguration : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.ToTable("NhanVien");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ten).IsRequired();

            builder.Property(x => x.NgaySinh).IsRequired();
            builder.Property(x => x.ThangSinh).IsRequired();
            builder.Property(x => x.NamSinh).IsRequired();
        }
    }
}
