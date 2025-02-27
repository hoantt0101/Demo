using log4net;

namespace PageObjects.Common.Base
{
    public class GlobalBase
    {
        // Global declaration for additional logging with Log4Net
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
