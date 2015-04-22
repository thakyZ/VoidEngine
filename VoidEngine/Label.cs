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
		public string text;
		protected SpriteFont texture;
		public Vector2 position;
		public float scale;
		public Color color;
		/// <summary>
		/// Creates the Label.
		/// </summary>
		/// <param name="text">The text that will be in the label.</param>
		public Label(Vector2 position, SpriteFont texture, float scale, Color color, string text)
		{
			this.text = text;
			this.texture = texture;
			this.position = position;
			this.scale = scale;
			this.color = color;
		}

		public virtual void Update(GameTime gameTime)
		{
		}

		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			//Vector2 FontOrigin = texture.MeasureString(text) / 2;
			// Draw the string
			spriteBatch.DrawString(texture, text, position, color, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0.5f);
		}
	}
}