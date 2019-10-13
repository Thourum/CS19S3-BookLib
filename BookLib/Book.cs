using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookLib
{
    public class Book
    {
        public Book() { }
        public Book(string title, string author, int page, string isbn)
        {
            Title = title;
            Author = author;
            Page = page;
            ISBN13 = isbn;
            Validate();
        }

        [Required]
        [MinLength(2)]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(10, 1000, ErrorMessage = "Must be between 10 and 1000")]
        public int Page { get; set; }
        [Required]
        [MinLength(13)]
        [StringLength(13)]
        public string ISBN13 { get; set; }

        public void Validate()
        {
            var context = new ValidationContext(this, null, null);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, result, true);
            if (!isValid)
                throw new ArgumentException(result.FirstOrDefault().ErrorMessage);
        }
    }
}
