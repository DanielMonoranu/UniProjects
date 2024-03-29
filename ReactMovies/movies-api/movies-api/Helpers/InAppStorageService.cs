﻿namespace movies_api.Helpers
{
    public class InAppStorageService : IFileStorageService
    {
        //class for saving images locally in wwwroot file. It is not used.
        //If you want to use it in Program.cs you need to use dependency injection for IFileStorageService,
        //app.UseStaticFiles() and services.AddHttpContextACcessor();

        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InAppStorageService(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task DeleteFile(string fileRoute, string containerName)
        {
            if (string.IsNullOrEmpty(fileRoute))
            {
                return Task.CompletedTask;
            }
            var fileName = Path.GetFileName(fileRoute);
            var fileDirectory = Path.Combine(_env.WebRootPath, containerName, fileName);
            if (File.Exists(fileDirectory))
            {
                File.Delete(fileDirectory);
            }
            return Task.CompletedTask;

        }

        public async Task<string> EditFile(string containerName, IFormFile file, string fileRoute)
        {
            await DeleteFile(fileRoute, containerName);
            return await SaveFile(containerName, file);

        }

        public async Task<string> SaveFile(string containerName, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_env.WebRootPath, containerName);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string route = Path.Combine(folder, fileName);
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                var content = ms.ToArray();
                await File.WriteAllBytesAsync(route, content);
            }
            var url = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var routeForDB = Path.Combine(url, containerName, fileName).Replace("\\", "/");
            return routeForDB;

        }
    }
}
