using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;

namespace TelerikMvcApp1.OpenAccess
{
    public partial class TelerikMvcApp1OpenAccessContext : OpenAccessContext
    {
        static MetadataContainer metadataContainer = new TelerikMvcApp1OpenAccessMetadataSource().GetModel();
        static BackendConfiguration backendConfiguration = new BackendConfiguration()
        {
            Backend = "mssql"
        };

        private const string DbConnection = "connectionID";

        public TelerikMvcApp1OpenAccessContext()
            : base(DbConnection, backendConfiguration, metadataContainer)
        {

        }

        public IQueryable<Product> Products
        {
            get
            {
                return this.GetAll<Product>();
            }
        }

        public void UpdateSchema()
        {
            var handler = this.GetSchemaHandler();
            string script = null;
            try
            {
                script = handler.CreateUpdateDDLScript(null);
            }
            catch
            {
                bool throwException = false;
                try
                {
                    handler.CreateDatabase();
                    script = handler.CreateDDLScript();
                }
                catch
                {
                    throwException = true;
                }
                if (throwException)
                    throw;
            }

            if (string.IsNullOrEmpty(script) == false)
            {
                handler.ExecuteDDLScript(script);
            }
        }
    }
}
