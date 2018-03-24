namespace Game.Models
{
    public interface IObserver
    {
        void Notify(Observable obj);
    }
}
