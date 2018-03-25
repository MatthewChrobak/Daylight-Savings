using Game.Timing;
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Sounds
{
    public static class SoundManager
    {
        private static List<Music> gameMusic = new List<Music>();
        private static Thread musicDisposer = null;

        public static void addMusic(string fileName, bool loop = false, float volume = 1.0f)
        {
            gameMusic.Add(new Music(fileName)
            {
                Loop = loop,
                Volume = volume
            });

            // If there is no GC, initialize it.
            if (musicDisposer == null)
            {
                musicDisposer = new Thread(MonitorMusic);
                musicDisposer.Start();
            }
        }

        private static void MonitorMusic()
        {
            while (StateSystem.GameState != States.Closed)
            {
                for (int i = 0; i < gameMusic.Count; i++)
                {
                    if (gameMusic[i].Status == SoundStatus.Stopped)
                    {
                        gameMusic[i].Dispose();
                        gameMusic.RemoveAt(i);
                        i--;
                    }
                }

                Thread.Yield();
            }
        }
    }
}
