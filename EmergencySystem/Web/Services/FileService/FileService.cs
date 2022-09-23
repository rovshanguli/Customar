namespace Web.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _host;

        public FileService(IWebHostEnvironment host)
        {
            _host = host;
        }



        public async Task<string> SaveStreamFile(IFormFile x)
        {
            byte[] buffer = new byte[4096];
            using var stream = x.OpenReadStream();
            int read = 0;
            string fileUrl = Guid.NewGuid().ToString("N") + Path.GetExtension(x.FileName);
            using var fileStream = new FileStream(Path.Combine(_host.WebRootPath + "\\Appeal\\", fileUrl), FileMode.Append);
            while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await fileStream.WriteAsync(buffer, 0, read);
            }
            return fileUrl;
        }

        public async Task<string> SaveFile(IFormFile formFile)
        {
            string fileUrl = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
            using var fileStream = new FileStream(Path.Combine(_host.WebRootPath + "\\Info\\", fileUrl), FileMode.Create);
            await formFile.CopyToAsync(fileStream);
            return fileUrl;
        }



    }
}
