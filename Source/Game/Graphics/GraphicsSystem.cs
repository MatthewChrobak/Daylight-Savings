using SFML.Graphics;
using SFML.System;
using Game.Models.Enviroment;
using System.Collections.Generic;

namespace Game.Graphics
{
    public class GraphicsSystem
    {
        private GameWindow _context;
        private SurfaceManager _surfaces;
        private Camera _camera;
        private Font _font;

        public GraphicsSystem(Map map)
        {
            this._context = new GameWindow(map);
            this._camera = new Camera(this._context);
            this._surfaces = new SurfaceManager();

            this._context.SetView(this._camera);

            this._surfaces.LoadTextures();

            this._font = new Font("fonts/opensans.ttf");


            map.Girl.Attach(_camera);
        }

        public void BeginRenderFrame()
        {
            this._context.Clear(Color.Black);
            this._context.DispatchEvents();
        }

        public void RenderToFrame(IEnumerable<DrawableComponent> components)
        {
            foreach (var component in components) {
                if (component.RenderText != null) {
                    this.RenderTextComponent(component);
                } else {
                    this.RenderSurfaceComponent(component);
                }
            }
        }

        private void RenderSurfaceComponent(DrawableComponent component)
        {
            var sprite = this._surfaces.GetSprite(component.TextureName);

            var pos = (Vector2f)component.Position;

            if (component.AbsolutePositioning) {
                sprite.Position = new Vector2f(
                    pos.X + this._camera.Center.X - (this._camera.Size.X / 2),
                    pos.Y + this._camera.Center.Y - (this._camera.Size.Y / 2)
                    );
            } else {
                sprite.Position = pos;
            }

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
        
        private void RenderTextComponent(DrawableComponent component)
        {
            var text = new Text(component.RenderText, this._font);
            text.CharacterSize = component.CharacterSize;
            
            if (component.Position != null) {
                var pos = (Vector2f)component.Position;
                if (component.AbsolutePositioning) {
                    text.Position = new Vector2f(
                        pos.X + this._camera.Center.X - (this._camera.Size.X / 2),
                        pos.Y + this._camera.Center.Y - (this._camera.Size.Y / 2)
                        );
                } else {
                    text.Position = pos;
                }
            }

            this._context.Draw(text);
        }

        public void EndRenderFrame()
        {
            this._context.Display();
        }
    }
}
