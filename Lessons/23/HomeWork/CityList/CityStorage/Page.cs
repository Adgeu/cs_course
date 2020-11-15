using System;

namespace CityStorage
{
    public class Page
    {
        public int PerPage { get; }
        public int CurrentPage { get; }
        public int Total { get; }
        public int TotalPages { get; }
        public City[] Data { get; }

        public Page(int currentPage, int perPage, City[] cities)
        {
            CurrentPage = currentPage;
            PerPage = perPage;
            Total = cities.Length;
            TotalPages = (int)Math.Ceiling((float)cities.Length / PerPage);

            if (currentPage > TotalPages)
            {
                Data = new City[] { };
                return;
            }
            
            var range = ((CurrentPage * PerPage) - PerPage)..(CurrentPage == TotalPages ? cities.Length : CurrentPage * PerPage);

            Data = cities[range];
        }
    }
}
