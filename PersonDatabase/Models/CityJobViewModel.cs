using Microsoft.AspNetCore.Mvc.Rendering;

namespace PersonDatabase.Models
{
    public class CityJobViewModel
    {
        public List<Person>? People { get; set; }
        public SelectList? Jobs { get; set; }
        public SelectList? Towns { get; set; }


        public string? Job { get; set; }

        public string? Town { get; set; }
        public string? SearchString { get; set; }


    }
}
