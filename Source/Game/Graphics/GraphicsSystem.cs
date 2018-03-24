using SFML.Graphics;
using System.Collections.Generic;

namespace Game.Graphics
{
    public class GraphicsSystem
    {
        private GameWindow _context;
        private SurfaceManager _surfaces;
        private Camera _camera;

        public GraphicsSystem()
        {
            this._camera = new Camera();
            this._context = new GameWindow();
            this._surfaces = new SurfaceManager();

            this._context.SetView(this._camera);

            this._surfaces.LoadTextures();
        }

        public void RenderFrame(IEnumerable<DrawableComponent> components)
        {
            this._context.Clear(Color.Black);
            this._context.DispatchEvents();

            foreach (var component in components) {
                var sprite = this._surfaces.GetSprite(component.TextureName);
                sprite.Position = component.Position;
                this._context.Draw(sprite);
            }

            this._context.Display();
        }
    }
}
