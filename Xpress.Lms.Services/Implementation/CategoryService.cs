using Xpress.Lms.Data;
using Xpress.Lms.Models.DTOs;
using Xpress.Lms.Services.Interfaces;

namespace Xpress.Lms.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IDatabase database;

        public CategoryService(IDatabase database)
        {
            this.database = database;
        }

        public async Task<List<CategoryDto>> Get()
        {
            return await database.Get<CategoryDto>("SELECT Id, Name FROM Categories ORDER BY Name");
        }
    }
}
