using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeneratePDFWithiTextSharp.Startup))]
namespace GeneratePDFWithiTextSharp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
