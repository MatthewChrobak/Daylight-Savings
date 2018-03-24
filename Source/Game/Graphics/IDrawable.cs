using System.Collections.Generic;

namespace Game.Graphics
{
    public interface IDrawable
    {
        IEnumerable<DrawableComponent> GetDrawableComponents();
    }
}
