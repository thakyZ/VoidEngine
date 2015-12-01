using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using VoidEngine.VGame;

namespace VoidEngine.VGUI
{
	/// <summary>
	/// The button class for the VoidEngine
	/// </summary>
	public class Checkbox : Sprite
	{
		/// <summary>
		/// This is the Void Engine button's state enum
		/// </summary>
		protected enum ButtonStates
		{
			Hover,
			Up,
			Down,
			Released
		}
		/// <summary>
		/// This is the Void Engine button's state enum
		/// </summary>
		protected enum CheckboxStates
		{
			Checked,
			Unchecked
		}
		/// <summary>
		/// The types of buttons on the mouse.
		/// </summary>
		public enum ButtonTypes
		{
			Left,
			Right,
			Middle
		}

		protected ButtonStates CheckButtonState = new ButtonStates(); // This is the button state variable
		protected CheckboxStates CheckboxState = new CheckboxStates();
		protected ButtonTypes PrimaryButton = new ButtonTypes();

		protected bool MousePressed, PreviousMousePressed;
		protected Point MouseCords;
		protected Rectangle CollisionBounds;

		public string test = "Hi";
		public Color test2;

		/// <summary>
		/// Creates the Checkbox class.
		/// </summary>
		/// <param name="position"></param>
		/// <param name="color"></param>
		/// <param name="primaryButton"></param>
		/// <param name="defaultButtonPositions"></param>
		/// <param name="animationSetList"></param>
		public Checkbox(Vector2 position, Color color, ButtonTypes primaryButton, List<Sprite.AnimationSet> animationSetList)
			: base(position, color, animationSetList)
		{
			AnimationSets = animationSetList;

			Color = color;
			PrimaryButton = primaryButton;

			CheckboxState = CheckboxStates.Unchecked;
		}

		public Checkbox(Texture2D texture, Vector2 position, ButtonTypes primaryButton, Color color)
			: base(position, color, texture)
		{
			AddAnimations(texture);

			Color = color;
			PrimaryButton = primaryButton;

			CheckboxState = CheckboxStates.Unchecked;
			CheckButtonState = ButtonStates.Up;
		}

		/// <summary>
		/// Returns if the button is hovered over or not.
		/// </summary>
		/// <param name="tx">The texture of the button</param>
		/// <param name="ty">The texture's y</param>
		/// <param name="frameTex">the texture's width and height in Point</param>
		/// <param name="x">the x of mouse</param>
		/// <param name="y">the y of mouse</param>
		/// <returns>Boolean</returns>
		protected bool hitButtonAlpha(Vector2 position, Point frameSize, Point mouseCords)
		{
			CollisionBounds = new Rectangle((int)position.X, (int)position.Y, frameSize.X, frameSize.Y);

			if (CollisionBounds.Intersects(new Rectangle(mouseCords.X, mouseCords.Y, 1, 1)))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Updates the button with the mouse's cords and state
		/// </summary>
		/// <param name="gameTime">The game time that the game runs off of.</param>
		public override void Update(GameTime gameTime)
		{
			MouseState MouseState = Mouse.GetState();

			MouseCords = new Point(MouseState.X, MouseState.Y);
			PreviousMousePressed = MousePressed;
			//MousePressed = (PrimaryButton == ButtonTypes.Left && MouseState.LeftButton == ButtonState.Pressed) || (PrimaryButton == ButtonTypes.Right && MouseState.RightButton == ButtonState.Pressed) || (PrimaryButton == ButtonTypes.Middle && MouseState.MiddleButton == ButtonState.Pressed);
			MousePressed = MouseState.LeftButton == ButtonState.Pressed;

			inbounds = new Rectangle(0, 0, CurrentAnimation.frameSize.X, CurrentAnimation.frameSize.Y);

			if (CheckboxState == CheckboxStates.Checked)
			{
				test = "Checked";

				if (CheckButtonState == ButtonStates.Hover)
				{
					test = "Checked Hover";
				}
				else if (CheckButtonState == ButtonStates.Up)
				{
					test = "Checked UP";
				}
			}
			else if (CheckboxState == CheckboxStates.Unchecked)
			{
				test = "Unchecked";

				if (CheckButtonState == ButtonStates.Hover)
				{
					test = "Unchecked Hover";
				}
				else if (CheckButtonState == ButtonStates.Up)
				{
					test = "Unchecked UP";
				}
			}

			if (hitButtonAlpha(position, CurrentAnimation.frameSize, MouseCords))
			{

				if (CheckboxState == CheckboxStates.Unchecked && (!MousePressed && PreviousMousePressed))
				{
					test2 = Color.Aqua;
					//CheckButtonState = ButtonStates.Down;
					CheckboxState = CheckboxStates.Checked;
					SetAnimation("CHECKED");
				}
				else if (CheckboxState == CheckboxStates.Checked && (!MousePressed && PreviousMousePressed))
				{
					test2 = Color.Red;
					//CheckButtonState = ButtonStates.Down;
					CheckboxState = CheckboxStates.Unchecked;
					SetAnimation("UNCHECKED");
				}

				if (CheckButtonState == ButtonStates.Up)
				{
					if (CheckboxState == CheckboxStates.Unchecked)
					{
						test2 = Color.Blue;
						CheckButtonState = ButtonStates.Hover;
						SetAnimation("HOVERUNCHECKED");
					}
					else if (CheckboxState == CheckboxStates.Checked)
					{
						test2 = Color.Blue;
						CheckButtonState = ButtonStates.Hover;
						SetAnimation("HOVERCHECKED");
					}
				}
			}
			else
			{
				if (CheckButtonState == ButtonStates.Hover)
				{
					if (CheckboxState == CheckboxStates.Unchecked)
					{
						test2 = Color.Lime;
						CheckButtonState = ButtonStates.Up;
						SetAnimation("UNCHECKED");
					}
					else if (CheckboxState == CheckboxStates.Checked)
					{
						test2 = Color.Lime;
						CheckButtonState = ButtonStates.Up;
						SetAnimation("CHECKED");
					}
				}
			}
		}

		/// <summary>
		/// Returns weither if the button was clicked.
		/// </summary>
		/// <returns>Boolean</returns>
		public bool isChecked
		{
			get
			{
				if (CheckboxState == CheckboxStates.Checked)
				{
					return true;
				}

				return false;
			}
		}

		/// <summary>
		/// Used to draw the button.
		/// </summary>
		/// <param name="gameTime">The game time that the game runs off of.</param>
		/// <param name="spriteBatch">The sprite batch used to draw with.</param>
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			base.Draw(gameTime, spriteBatch);
		}

		protected override void AddAnimations(Texture2D texture)
		{
			AddAnimation("UNCHECKED", texture, new Point(texture.Width / 4, texture.Height), new Point(1, 1), new Point((texture.Width / 4) * 1, 0), 1600, true);
			AddAnimation("HOVERUNCHECKED", texture, new Point(texture.Width / 4, texture.Height), new Point(1, 1), new Point((texture.Width / 4) * 0, 0), 1600, true);
			AddAnimation("CHECKED", texture, new Point(texture.Width / 4, texture.Height), new Point(1, 1), new Point((texture.Width / 4) * 2, 0), 1600, true);
			AddAnimation("HOVERCHECKED", texture, new Point(texture.Width / 4, texture.Height), new Point(1, 1), new Point((texture.Width / 4) * 3, 0), 1600, true);
			SetAnimation("UNCHECKED");

			base.AddAnimations(texture);
		}
	}
}