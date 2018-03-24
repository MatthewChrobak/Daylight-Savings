using SFML.System;

namespace Game.Graphics
{
    public class DrawableComponent
    {
        public string TextureName { get; set; }
        public Vector2f RenderSize { get; set; }
        public Vector2f Position { get; set; }
    }
}
