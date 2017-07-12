using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApi.Infrastructure
{
    public class FromHeaderAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new FromHeaderParameterBinding(parameter);
        }
    }
}