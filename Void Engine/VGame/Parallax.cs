using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoGame.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VoidEngine;

namespace VoidEngine.VGame
{
    public class Parallax
    {
        /// <summary>
        ///
        /// </summary>
        private Texture2D texture
        {
            get;
            set;
        }
        /// <summary>
        ///
        /// </summary>
        public Vector2 position1;
        public Vector2 position2;
        public Vector2 position3;
        public Vector2 position4;
        /// <summary>
        ///
        /// </summary>
        private Color color
        {
            get;
            set;
        }
        /// <summary>
        ///
        /// </summary>
        public Vector2 multiplier
        {
            get;
            private set;
        }
        /// <summary>
        ///
        /// </summary>
        private Camera camera
        {
            get;
            set;
        }
        /// <summary>
        ///
        /// </summary>
        private Vector2 defaultPosition
        {
            get;
            set;
        }
        /// <summary>
        ///
        /// </summary>
        public GraphicsDeviceManager graphics
        {
            get;
            set;
        }

        // An array of positions of the parallaxing background
        public Vector2[] positions;

        /// <summary>
        ///
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="multiplier"></param>
        /// <param name="camera"></param>
        public Parallax(Texture2D texture, Vector2 position, Color color, Vector2 multiplier, Camera camera)
        {
            this.texture = texture;
            this.color = color;
            this.multiplier = multiplier;
            this.camera = camera;

            // If we divide the screen with the texture width then we can determine the number of tiles need.
            // We add 1 to it so that we won't have a gap in the tiling
            positions = new Vector2[(int)(camera.Size.X / camera.viewportSize.X + 1)];

            // Set the initial positions of the parallaxing background
            for (int i = 0; i < positions.Length; i++)
            {
                // We need the tiles to be side by side to create a tiling effect
                positions[i] = new Vector2(i * camera.viewportSize.X, 0);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Rectangle rectBg = new Rectangle((int)(((texture.Width - camera.Size.X) * multiplier.X) + camera.Position.X), (int)0, (int)texture.Width, (int)texture.Height);
            spriteBatch.Draw(texture, new Rectangle(0, 0, (int)camera.viewportSize.X, (int)camera.viewportSize.Y), rectBg, Color.White);
        }
    }
}
