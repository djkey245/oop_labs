namespace OOPLR3;

public class EBook : Book
{
    public double FileSize { get; set; }
    public string Format { get; set; }

    public EBook() : base()
    {
        FileSize = 1.0;
        Format = "PDF";
        Info();
    }

    public EBook(string title, string author, int pages, double fileSize, string format) : base(title, author, pages)
    {
        FileSize = fileSize;
        Format = format;
        Info();
    }

    private bool IsLargeFile(){
        return FileSize > 5.0;
    }

    public override void Info()
    {
        if (PageManager.CurrentPage != null)
        {
            string message = $"Type: Ebook, Title: {Title}, Author: {Author}, Pages: {Pages}, Large Book: {IsLargeBook()}, FileSize: {FileSize}, Format: {Format}, Large File: {IsLargeFile()}";

            PageManager.CurrentPage.DisplayAlert("Info", message, "OK");
        }
    }
}