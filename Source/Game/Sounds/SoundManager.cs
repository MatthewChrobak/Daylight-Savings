using Game.Timing;
using SFML.Audio;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Game.Sounds
{
    public static class MusicManager
    {
        private static List<Music> gameMusic = new List<Music>();
        private static Thread musicDisposer = null;

        public static void addMusic(string fileName, bool loop = false, float volume = 100.0f)
        {
            lock (gameMusic) {
                gameMusic.Add(new Music("music/" + fileName) {
                    Loop = loop,
                    Volume = volume
                });
                gameMusic.Last().Play();
            }

            // If there is no GC, initialize it.
            if (musicDisposer == null) {
                musicDisposer = new Thread(MonitorMusic);
                musicDisposer.Start();
            }
        }

        public static void stopMusic()
        {
            for (int i = 0; i < gameMusic.Count; i++) {
                gameMusic[i].Stop();
            }
        }

        private static void MonitorMusic()
        {
            while (StateSystem.GameState != States.Closed) {
                lock (gameMusic) {
                    for (int i = 0; i < gameMusic.Count; i++) {
                        if (gameMusic[i].Status == SoundStatus.Stopped) {
                            gameMusic[i].Dispose();
                            gameMusic.RemoveAt(i);
                            i--;
                        }
                    }
                }

                Thread.Yield();
            }
        }
    }
    


    public static class SoundManager
    {
        private static List<Sound> Sounds = new List<Sound>();
        private static Thread soundDisposer = null;

        public static void addSound(string fileName)
        {
            lock (Sounds) {
                Sounds.Add(new Sound(new SoundBuffer("music/" + fileName)));
                Sounds.Last().Play();
            }

            // If there is no GC, initialize it.
            if (soundDisposer == null) {
                soundDisposer = new Thread(MonitorSounds);
                soundDisposer.Start();
            }
        }

        private static void MonitorSounds()
        {
            while (StateSystem.GameState != States.Closed) {
                lock(Sounds) {
                    for (int i = 0; i < Sounds.Count; i++) {
                        if (Sounds[i].Status == SoundStatus.Stopped) {
                            Sounds[i].Dispose();
                            Sounds.RemoveAt(i);
                            i--;
                        }
                    }
                }

                Thread.Yield();
            }
        }
    }
}

