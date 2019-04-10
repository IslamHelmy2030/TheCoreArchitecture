using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TheCoreArchitecture.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build().Run();



    }
}
