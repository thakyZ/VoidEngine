using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace VoidEngine
{
    /// <summary>
    /// The Label class for the VoidEngine
    /// </summary>
    public class Label
    {
        protected string text;
        protected SpriteFont texture;
        protected Vector2 position;
        /// <summary>
        /// Creates the Label.
        /// </summary>
        /// <param name="text">The text that will be in the label.</param>
        public Label(Vector2 position, SpriteFont texture, string text)
        {
            this.text = text;
            this.texture = texture;
            this.position = position;
        }

        public virtual void Update(GameTime gameTime, string text2)
        {
            text = text2;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 FontOrigin = texture.MeasureString(text) / 2;
            // Draw the string
            spriteBatch.DrawString(texture, text, position, Color.White, 0, new Vector2(0,0), 0.5f, SpriteEffects.None, 0.5f);
        }
    }
}
