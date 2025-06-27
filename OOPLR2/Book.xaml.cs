namespace OOPLR2;
public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }

        public Book()
        {
            Title = "Default Title";
            Author = "Default Author";
            Pages = 0;
        }

        public Book(string title, string author, int pages)
        {
            Title = title;
            Author = author;
            Pages = pages;
        }

        public bool IsLargeBook()
        {
            return Pages > 500;
        }

        public string FullTitle()
        {
            return $"Title: {Title}, Author: {Author}";
        }

        async public void Info()
        {
            if (PageManager.CurrentPage != null)
            {
                string message = $"Title: {Title}, Author: {Author}, Pages: {Pages}, Large Book: {IsLargeBook()}";

                await PageManager.CurrentPage.DisplayAlert("Info", message, "OK");
            }

        }
    }
