namespace GameLibrary.WPF.Model
{
    public class AddGameToLibrary : ICommand
    {
        public string Title { get; set; }
        public string Notes { get; set; }
        public double Rating { get; set; }
    }
}