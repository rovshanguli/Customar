namespace Web.Services.FileService
{
    public interface IFileService
    {
        Task<string> SaveStreamFile(IFormFile x);

        Task<string> SaveFile(IFormFile formFile);

    }
}
