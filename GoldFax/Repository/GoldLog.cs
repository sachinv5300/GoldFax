using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFax.Repository
{
    internal  class GoldLog
    {
        public static readonly string LogFileName = "Log.txt";

        public static void LoggingException(string FunctionName, string ParentName, Exception ex )
        {
            try
            {
                using (StreamWriter logwriter = new StreamWriter(LogFileName))
                {
                    logwriter.WriteLine("Exception Occured At--" + FunctionName +
                        "  in--" + ParentName + " with Message--" + ex.Message +
                        " Stack---" + ex.StackTrace);
                }
            }
            catch (Exception)
            {

                
            }          

        }

    }
}
