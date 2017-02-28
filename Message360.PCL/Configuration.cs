using System.Collections.Generic;
using System.Text;
using message360.Models;
using message360.Utilities;

namespace message360
{
    public partial class Configuration
    {
        public enum Environments
        {
            //Our message360 production environment.  This is our latest stable release.
            PRODUCTION,
            //Pre-Production environment used to test your code in our beta systems.  There is a good chance nothing will work here.  Don't use it unless instructed by our staff.
            PREPRODUCTION,
            //Internal development testing.  This configuration of the API is not available to the public.
            DEVELOPMENT,
        }
        public enum Servers
        {
            DEFAULT,
        }

        //The current environment being used
        public static Environments Environment = Environments.PRODUCTION;

        //The username to use with basic authentication
        //TODO: Replace the BasicAuthUserName with an appropriate value
        public static string BasicAuthUserName = "TODO: Replace";

        //The password to use with basic authentication
        //TODO: Replace the BasicAuthPassword with an appropriate value
        public static string BasicAuthPassword = "TODO: Replace";

        //A map of environments and their corresponding servers/baseurls
        public static Dictionary<Environments, Dictionary<Servers, string>> EnvironmentsMap =
            new Dictionary<Environments, Dictionary<Servers, string>>
            {
                {
                    Environments.PRODUCTION,new Dictionary<Servers, string>
                    {
                        { Servers.DEFAULT,"https://api.message360.com/api/v2" },
                    }
                },
                {
                    Environments.PREPRODUCTION,new Dictionary<Servers, string>
                    {
                        { Servers.DEFAULT,"https://api-preprod.message360.com/api/v2" },
                    }
                },
                {
                    Environments.DEVELOPMENT,new Dictionary<Servers, string>
                    {
                        { Servers.DEFAULT,"https://api-dev.message360.com/api/v2" },
                    }
                },
            };

        /// <summary>
        /// Makes a list of the BaseURL parameters
        /// </summary>
        /// <return>Returns the parameters list</return>
        internal static List<KeyValuePair<string, object>> GetBaseURIParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList;
        }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters
        /// </summary>
        /// <param name="alias">Default value:DEFAULT</param>
        /// <return>Returns the baseurl</return>
        internal static string GetBaseURI(Servers alias = Servers.DEFAULT)
        {
            StringBuilder Url =  new StringBuilder(EnvironmentsMap[Environment][alias]);
            APIHelper.AppendUrlWithTemplateParameters(Url, GetBaseURIParameters());
            return Url.ToString();
        }
    }
}