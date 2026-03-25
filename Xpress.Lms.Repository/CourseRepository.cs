using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Data;
using Xpress.Lms.Data;
using Xpress.Lms.Models.Entities;
using Xpress.Lms.Repository.Interfaces;

namespace Xpress.Lms.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDatabase database;

        public CourseRepository(IDatabase database)
        {
            this.database = database;
        }

        public async Task Create(Courses course, IFormFile file)
        {
            var filePath = await SaveFile(file);

            var parameters = new DynamicParameters();
            parameters.Add("@Id", course.Id);
            parameters.Add("@Title", course.Title);
            parameters.Add("@Description", course.Description);
            parameters.Add("@CategoryId", course.CategoryId);
            parameters.Add("@InstructorId", course.InstructorId);
            parameters.Add("@ThumbnailUrl", filePath);
            parameters.Add("@CreatedAt", course.CreatedAt);

            await database.ExecuteAsync("sp_CreateCourse", CommandType.StoredProcedure, parameters);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var path = Path.Combine("wwwroot/uploads", fileName);

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/uploads/{fileName}";
        }
    }
}
