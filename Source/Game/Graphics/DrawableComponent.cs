using SFML.Graphics;
using SFML.System;

namespace Game.Graphics
{
    public class DrawableComponent
    {
        public string TextureName { get; set; }
        public Vector2f? RenderSize { get; set; } = null;
        public Vector2f? Position { get; set; } = null;
        public IntRect? Rect { get; set; } = null;

        public string RenderText { get; set; } = null;
        public uint CharacterSize { get; set; } = 11;
    }
}
