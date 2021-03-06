﻿using Microsoft.Azure.WebJobs.Host;
using Ninject;

namespace GDV_POC_WebJobContinious.Activator
{
    public class NinjectActivator : IJobActivator
    {
        private readonly IKernel _kernel;

        public NinjectActivator(IKernel kernel)
        {
            _kernel = kernel;
        }

        public T CreateInstance<T>()
        {
            return _kernel.Get<T>();
        }
    }
}