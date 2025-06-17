using System.Collections.Generic;
using ProceduralDungeon.Infrastructure;

namespace ProceduralDungeon.UseCases
{
    public class GenerateDungeonUseCase
    {
        private readonly DungeonGenerator _generator;
        private const int Width = 64;
        private const int Height = 64;
        private const int MinRoom = 8;
        private const int MaxRoom = 32;

        public GenerateDungeonUseCase(DungeonGenerator generator)
        {
            _generator = generator;
        }

        public List<DungeonGenerator.Room> Execute(int seed)
        {
            return _generator.Generate(Width, Height, MinRoom, MaxRoom, seed);
        }
    }
}