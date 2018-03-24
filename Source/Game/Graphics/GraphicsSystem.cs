using SFML.Graphics;

namespace Game.Graphics
{
    public class GraphicsSystem
    {
        private GameWindow _context;

        public GraphicsSystem()
        {
            this._context = new GameWindow();
        }

        public void Render()
        {
            this._context.Clear(Color.Red);
            this._context.DispatchEvents();
            this._context.Display();
        }
    }
}
