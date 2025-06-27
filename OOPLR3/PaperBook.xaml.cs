namespace OOPLR3;

public class PaperBook : Book
{
    public string CoverType { get; set; }
    public string PublishingHouse { get; set; }

    public PaperBook() : base()
    {
        CoverType = "rough";
        PublishingHouse = "None";
    }

    public PaperBook(string title, string author, int pages, string coverType, string publishingHouse) : base(title, author, pages)
    {
        CoverType = coverType;
        PublishingHouse = publishingHouse;
    }

    public override void Info()
    {
        if (PageManager.CurrentPage != null)
        {
            string message = $"Type: Paper Book, Title: {Title}, Author: {Author}, Pages: {Pages}, Large Book: {IsLargeBook()}, CoverType: {CoverType}, PublishingHouse: {PublishingHouse}";

            PageManager.CurrentPage.DisplayAlert("Info", message, "OK");
        }
    }
}