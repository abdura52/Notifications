using Notifications.Domain.Common.Exceptions;

namespace Notifications.Domain.Extensions;

public static class ExceptionExtensions
{
    public static async ValueTask<FuncResult<T>> GetValueAsync<T>(this Func<Task<T>> func) where T : struct
    {
        FuncResult<T> result;

        try
        {
            result = new(await func());
        }
        catch (Exception ex)
        {
            result = new(ex);
        }

        return result;
    }
}
