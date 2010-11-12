using System;

namespace GameLibrary.WPF.Model
{
    public class CheckGameOut : ICommand
    {
        public Guid Id { get; set; }
        public string Borrower { get; set; }
    }
}