using SFML.Audio;

namespace MyEngine.MyEngineSound
{
    public static class SoundManager
    {
        public static Dictionary<string, Sound> sounds = new Dictionary<string, Sound>();

        public static void LoadSound(string path, string soundName)
            => sounds.Add(soundName, new Sound(new SoundBuffer(path)));

        public static void PlaySound(string soundName)
            => sounds[soundName]?.Play();

        public static Music CreateMusic(string path)
            => new Music(path);
    }
}
