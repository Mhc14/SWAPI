using Newtonsoft.Json;

namespace SWAPI.Models
{
    public class ResponseSW
    {
        public List<Swpublic>? results { get; set; }
    }
    public class Swpublic
    {
        public string? name { get; set; }
        public string? Height { get; set; }
        public string? Mass { get; set; }
        public string? Gender { get; set; }
    }

    public class ResponseDownload
    {
        public List<SwPrivate>? results { get; set; }
    }
    public class SwPrivate
    {
       
        public string? name { get; set; }
        public string? Height { get; set; }
        public string? Mass { get; set; }
        public string? Hair_color { get; set; }
        public string? Skin_color { get; set; }
        public string? Eye_color { get; set; }
        public string? Birth_year { get; set; }


    }
}
