using System;

namespace ProductsApp
{
    public class BookProduct : IProduct
    {
        private readonly Book book;

        public BookProduct(Book book)
        {
            this.book = book;
        }
        public string Category { get => "Book" ; set => throw new NotImplementedException(); }
        public decimal Cost { get => this.book.Price; set => this.book.Price = value; }
        public int Id { get => this.book.BookId; set => this.book.BookId = value; }
        public string Name { get => this.book.Title; set => this.book.Title = value; }
        public int Units { get => this.book.Units; set => this.book.Units = value; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}", this.Id, this.Name, this.Cost, this.Units, this.Category);
        }
    }
}
