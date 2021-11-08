using System;
using System.Threading.Tasks;

namespace Business.Common
{
    public static class LogErrorResult
    {
        public static Task<string> RaiseError(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
