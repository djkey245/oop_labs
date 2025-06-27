namespace OOPLR3;

public class Book
{
    public static int Count { get; private set; }
    public int Nomer { get; private set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }

    public Book()
    {

        Nomer = Count;
        Title = "Default Title";
        Author = "Default Author";
        Pages = 0;
        Info();

        Count++;
    }

    public Book(string title, string author, int pages)
    {

        Nomer = Count;
        Title = title;
        Author = author;
        Pages = pages;
        Info();

        Count++;
    }

    public bool IsLargeBook()
    {
        return Pages > 500;
    }
    public string FullTitle()
    {
        return $"Title: {Title}, Author: {Author}";
    }


    public virtual void Info()
    {
        if (PageManager.CurrentPage != null)
        {
            string message = $"Title: {Title}, Author: {Author}, Pages: {Pages}, Large Book: {IsLargeBook()}";

            PageManager.CurrentPage.DisplayAlert("Info", message, "OK");
        }
    }

    ~Book()
    {
        if (PageManager.CurrentPage != null)
        {
            string message = $"The book #{Nomer} will be destroyed";
            PageManager.CurrentPage.DisplayAlert("Warning!", message, "OK");
        }

        Count--;
    }
}