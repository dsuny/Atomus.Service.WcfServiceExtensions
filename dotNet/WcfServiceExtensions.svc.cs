using Atomus.Diagnostics;
using System;

namespace Atomus.Service
{
    public class WcfServiceExtensions : IServiceExtensions
    {
        ServiceResult IServiceExtensions.Request(ServiceData serviceData)
        {
            ServiceResult serviceResult;

            //IService service;

            try
            {
                //service = (IService)this.CreateInstance("ServerAdapter");
                //_Service = (IService)Factory.CreateInstance(@"E:\Work\Project\Atomus\Service\ServerAdapter\bin\Debug\Atomus.Service.ServerAdapter.V1.0.0.0.dll", "Atomus.Service.ServerAdapter", true, true);

                serviceResult = new ServiceResult();
                serviceResult.ConvertServiceResult(((IService)this.CreateInstance("ServerAdapter")).Request((ServiceDataSet)serviceData.ServiceDataSet()));

                return serviceResult;
            }
            catch (AtomusException exception)
            {
                DiagnosticsTool.MyTrace(exception);
                return (ServiceResult)Factory.CreateInstance("Atomus.Service.ServiceResult", false, true, exception);
            }
            catch (Exception exception)
            {
                DiagnosticsTool.MyTrace(exception);
                return (ServiceResult)Factory.CreateInstance("Atomus.Service.ServiceResult", false, true, exception);
            }
        }
    }
}