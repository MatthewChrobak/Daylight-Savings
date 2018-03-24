using SFML.Graphics;
using SFML.System;
using Game.Models.Enviroment;
using System.Collections.Generic;
using Game.Models.Enviroment;

namespace Game.Graphics
{
    public class GraphicsSystem
    {
        private GameWindow _context;
        private SurfaceManager _surfaces;
        private Camera _camera;

        public GraphicsSystem(Map map)
        {
            this._camera = new Camera();
            this._context = new GameWindow(map);
            this._surfaces = new SurfaceManager();

            this._context.SetView(this._camera);

            this._surfaces.LoadTextures();
        }

        public void BeginRenderFrame()
        {
            this._context.Clear(Color.Black);
            this._context.DispatchEvents();
        }

        public void RenderToFrame(IEnumerable<DrawableComponent> components)
        {
            foreach (var component in components) {
                var sprite = this._surfaces.GetSprite(component.TextureName);

                var pos = (Vector2f)component.Position;
                sprite.Position = pos;

                if (component.Rect != null) {
                    var rect = (IntRect)component.Rect;
                    sprite.TextureRect = rect;

                    if (component.RenderSize != null) {
                        var size = (Vector2f)component.RenderSize;

                        sprite.Scale = new Vector2f(
                            size.X / rect.Width,
                            size.Y / rect.Height
                            );
                    }
                } else {
                    if (component.RenderSize != null) {
                        var size = (Vector2f)component.RenderSize;
                        sprite.Scale = new Vector2f(
                            size.X / sprite.Texture.Size.X,
                            size.Y / sprite.Texture.Size.Y
                            );
                    }
                }

                this._context.Draw(sprite);
            }
        }

        public void EndRenderFrame()
        {
            this._context.Display();
        }
    }
}
