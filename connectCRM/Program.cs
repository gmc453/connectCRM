using System;
using System.Linq;
using Microsoft.Xrm.Sdk.Client;
using System.ServiceModel.Description;
using Microsoft.Crm.Sdk.Messages;

namespace Carl.Crm.OrgServiceProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Uri oUri = new Uri("https://crm365-iis.x-code.pl/box/XRMServices/2011/Organization.svc");
                ClientCredentials clientCredentials = new ClientCredentials();
                clientCredentials.UserName.UserName = "lplonski";
                clientCredentials.UserName.Password = "Bicek#2021";

                OrganizationServiceProxy _serviceProxy = new OrganizationServiceProxy(oUri, null, clientCredentials, null);
                _serviceProxy.EnableProxyTypes();

                OrganizationServiceContext orgContext = new OrganizationServiceContext(_serviceProxy);

                RetrieveVersionRequest versionRequest = new RetrieveVersionRequest();
                RetrieveVersionResponse versionResponse = (RetrieveVersionResponse)_serviceProxy.Execute(versionRequest);

                Console.WriteLine("Microsoft Dynamics CRM version {0}.", versionResponse.Version);
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
    }
}