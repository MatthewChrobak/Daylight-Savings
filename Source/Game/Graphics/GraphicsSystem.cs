using SFML.Graphics;

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

        public void Render()
        {
            this._context.Clear(Color.Black);
            this._context.DispatchEvents();

            var grass = this._surfaces.GetTextureByName("grass.png");
            grass.Scale = new SFML.System.Vector2f(5000, 5000);
            this._context.Draw(grass);

            this._context.Display();
        }
    }
}
