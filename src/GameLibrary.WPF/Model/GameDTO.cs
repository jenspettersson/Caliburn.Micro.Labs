using System;

namespace GameLibrary.WPF.Model
{
    public class GameDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public string Notes { get; set; }
        public string Borrower { get; set; }
        public DateTime AddedOn { get; set; }
    }
}