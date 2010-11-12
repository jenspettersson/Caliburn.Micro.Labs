using System;

namespace GameLibrary.WPF.Model
{
    public class GetGame : IQuery<GameDTO>
    {
        public Guid Id { get; set; }
    }
}