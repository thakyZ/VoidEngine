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
	/// The Button class for the Void Engine
	/// </summary>
	public class Button : Sprite
	{
		/// <summary>
		/// This is the Void Engine button's state enum
		/// </summary>
		public enum bState
		{
			HOVER,
			UP,
			DOWN,
			RELEASED
		}

		Label label; // This is the label that the button has overlayed on it.

		bState buttonState = new bState(); // This is the button state variable
		bool mousePress = false; // This
		bool previousMousePress = false;
		int mouseX;
		int mouseY;
		Rectangle testCollision;

		/// <summary>
		/// Creates a button.
		/// </summary>
		/// <param name="position">The position for the button.</param>
		/// <param name="font">The font for the text in the button.</param>
		/// <param name="text">The text in the button.</param>
		public Button(Vector2 position, SpriteFont font, float scale, Color fontColor, string text, Color color, List<Sprite.AnimationSet> animationSetList)
			: base(position, color, animationSetList)
		{
			_Color = color;
			AnimationSets = animationSetList;
			label = new Label(new Vector2(position.X + ((animationSetList[0].frameSize.X - font.MeasureString(text).X) / 2), position.Y + ((animationSetList[0].frameSize.Y - font.MeasureString(text).Y) / 2)), font, scale, fontColor, text);
		}

		/// <summary>
		/// The test for hitButtonAlpha overload 0.
		/// </summary>
		/// <param name="tx">The texture's x</param>
		/// <param name="ty">The texture's y</param>
		/// <param name="frameTex">the texture's width and height in Point</param>
		/// <param name="x">the x of mouse</param>
		/// <param name="y">the y of mouse</param>
		/// <returns>Boolean</returns>
		Boolean hitButtonAlpha(float textureX, float textureY, Point frameSize, int x, int y)
		{
			testCollision = new Rectangle((int)textureX, (int)textureY, frameSize.X, frameSize.Y);

			if (testCollision.Intersects(new Rectangle(x, y, 1, 1)))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Updates the button without the mouse, exectutes the hitButtonAlpha function too.
		/// </summary>
		public void updButton()
		{
			if (hitButtonAlpha(Position.X, Position.Y, CurrentAnimation.frameSize, mouseX, mouseY))
			{
				if (mousePress)
				{
					buttonState = bState.DOWN;
					SetAnimation("PRESSED");
				}
				else if (!mousePress && previousMousePress)
				{
					if (buttonState == bState.DOWN)
					{
						buttonState = bState.RELEASED;
						SetAnimation("REG");
					}
				}
				else
				{
					buttonState = bState.HOVER;
					SetAnimation("HOVER");
				}
			}
			else
			{
				buttonState = bState.UP;
				SetAnimation("REG");
			}
		}

		/// <summary>
		/// Updates the button with the mouse's cords and state
		/// </summary>
		/// <param name="gameTime">The main GameTime</param>
		public override void Update(GameTime gameTime)
		{
			MouseState mState = Mouse.GetState();

			mouseX = mState.X;
			mouseY = mState.Y;
			previousMousePress = mousePress;
			mousePress = mState.LeftButton == ButtonState.Pressed;

			updButton();
		}

		/// <summary>
		/// Returns true if the button was clicked
		/// </summary>
		public bool Clicked()
		{
			if (buttonState == bState.RELEASED)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Draws the button
		/// </summary>
		/// <param name="gameTime">The main GameTime</param>
		/// <param name="spriteBatch">The main SpriteBatch</param>
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			base.Draw(gameTime, spriteBatch);

			label.Draw(gameTime, spriteBatch);
		}
	}
}