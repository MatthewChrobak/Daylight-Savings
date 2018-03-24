using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Game.Graphics
{
    public class SurfaceManager
    {
        private Dictionary<string, Texture> _textures { get; set; }
        private readonly string GRAPHICS_FOLDER = "graphics/";

        public SurfaceManager()
        {
            this._textures = new Dictionary<string, Texture>();
        }

        public void LoadTextures()
        {
            // Make sure the folder exists.
            if (!Directory.Exists(GRAPHICS_FOLDER)) {
                Directory.CreateDirectory(GRAPHICS_FOLDER);
            }

            foreach (string file in Directory.GetFiles(GRAPHICS_FOLDER, "*.png", SearchOption.AllDirectories)) {
                var fi = new FileInfo(file);
                var texture = new Texture(file);
                this._textures.Add(fi.Name, texture);
            }
        }

        public Sprite GetSprite(string textureName)
        {
            if (!this._textures.ContainsKey(textureName)) {
                Console.WriteLine($"Could not find the texture {textureName}");
                return new Sprite();
            }
            return new Sprite(this._textures[textureName]);
        }
    }
}
