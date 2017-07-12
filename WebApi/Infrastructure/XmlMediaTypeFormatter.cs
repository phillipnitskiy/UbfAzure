using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebApi.Infrastructure
{
    public class XmlMediaTypeFormatter : MediaTypeFormatter
    {
        public XmlMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (readStream == null)
            {
                throw new ArgumentNullException(nameof(readStream));
            }

            var taskCompletionSource = new TaskCompletionSource<object>();
            try
            {
                XDocument xmlDoc = XDocument.Load(readStream);

                taskCompletionSource.SetResult(xmlDoc);
            }
            catch (Exception e)
            {
                taskCompletionSource.SetException(e);
            }

            return taskCompletionSource.Task;
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(XDocument);
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }
    }
}