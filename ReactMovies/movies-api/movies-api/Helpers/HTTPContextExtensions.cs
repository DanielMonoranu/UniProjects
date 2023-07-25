using Microsoft.EntityFrameworkCore;

namespace movies_api.Helpers
{
    public static class HTTPContextExtensions
    {

        //o metoda care pune in header o variabila cu nr total de records
    public async static Task InsertParametersPaginationInHeader<T>(this HttpContext httpContext,
        IQueryable<T> queryable)
        {
            if (httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }
            double count = await queryable.CountAsync();
            httpContext.Response.Headers.Add("totalAmountOfRecords", count.ToString());
        }
    }
}
