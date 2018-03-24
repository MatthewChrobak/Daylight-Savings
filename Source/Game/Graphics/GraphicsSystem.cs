using SFML.Graphics;

namespace Game.Graphics
{
    public class GraphicsSystem
    {
        private GameWindow _context;
        private SurfaceManager _surfaces;

        public GraphicsSystem()
        {
            this._context = new GameWindow();
            this._surfaces = new SurfaceManager();

            this._surfaces.LoadTextures();
        }

        public void Render()
        {
            this._context.Clear(Color.Red);
            this._context.DispatchEvents();
            this._context.Display();
        }
    }
}
