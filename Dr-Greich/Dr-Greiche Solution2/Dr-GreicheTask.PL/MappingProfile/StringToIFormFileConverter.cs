using AutoMapper;

namespace Dr_GreicheTask.PL.MappingProfile
{
   
        public class StringToIFormFileConverter : ITypeConverter<string, IFormFile>
        {
            public IFormFile Convert(string source, IFormFile destination, ResolutionContext context)
            {
                if (string.IsNullOrEmpty(source))
                {
                    return null;
                }

                var fileName = Path.GetFileName(source);
                var stream = new FileStream(source, FileMode.Open);

                var formFile = new FormFile(stream, 0, stream.Length, null, fileName)
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/octet-stream"
                };

                return formFile;
            }
        }
    
}
