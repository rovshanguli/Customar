using Domain.Entities.SubCodeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configrations
{
    public class SubCodeConfiguraton : IEntityTypeConfiguration<SubscriptionCode>
    {
        public void Configure(EntityTypeBuilder<SubscriptionCode> builder)
        {

        }
    }
}
