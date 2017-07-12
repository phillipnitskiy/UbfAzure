using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace WebApi.Infrastructure
{
    public class FromHeaderParameterBinding : HttpParameterBinding
    {
        public FromHeaderParameterBinding(HttpParameterDescriptor parameter)
            : base(parameter)
        {
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {       
            var taskSource = new TaskCompletionSource<object>();

            IEnumerable<string> values;
            if (actionContext.Request.Headers.TryGetValues(this.Descriptor.ParameterName, out values))
            {
                int intValue;
                if (int.TryParse(values.FirstOrDefault(), out intValue))
                {
                    actionContext.ActionArguments[this.Descriptor.ParameterName] = intValue;
                }
            }

            taskSource.SetResult(null);
            return taskSource.Task;
        }
    }
}