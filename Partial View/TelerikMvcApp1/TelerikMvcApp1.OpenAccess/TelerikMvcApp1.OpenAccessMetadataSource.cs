using System.Collections.Generic;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;

namespace TelerikMvcApp1.OpenAccess
{
    public class TelerikMvcApp1OpenAccessMetadataSource : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            // Getting Started with the Fluent Mapping API
            // http://documentation.telerik.com/openaccess-orm/developers-guide/code-only-mapping/fluent-mapping-overview

            List<MappingConfiguration> configurations = new List<MappingConfiguration>();

            MappingConfiguration<Product> productConfiguration = new MappingConfiguration<Product>();
            productConfiguration.MapType(x => new
            {
                ID = x.ID,
                Price = x.Price,
                ProductName = x.ProductName
            }).ToTable("Products");
            productConfiguration.HasProperty(x => x.ID).IsIdentity(KeyGenerator.Autoinc);

            configurations.Add(productConfiguration);

            return configurations;
        }
    }
}
