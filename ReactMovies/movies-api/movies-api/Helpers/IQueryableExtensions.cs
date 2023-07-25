using movies_api.DTOs;

namespace movies_api.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO paginationDTO)
        {
            return queryable
                .Skip((paginationDTO.Page - 1) * paginationDTO.RecordsPerPage)  //returns results in batches
                .Take(paginationDTO.RecordsPerPage); //only return a certain amount of records
        }
    }
}
