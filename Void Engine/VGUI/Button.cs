using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoGame.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VoidEngine.VGame;

namespace VoidEngine.VGUI
{
	/// <summary>
	/// The button class for the VoidEngine
	/// </summary>
    public class Button : Sprite
    {
        /// <summary>
        /// This is the Void Engine button's state enum
        /// </summary>
        protected enum ButtonStates
        {
            HOVER,
            UP,
            DOWN,
            RELEASED
        }

        protected Label Label; // This is the label that the button has overlayed on it.

        public string Text
        {
            get
            {
                return Label.Text;
            }
            set
            {
                Label.Text = value;
            }
        }

        protected ButtonStates CurrentButtonState = new ButtonStates(); // This is the button state variable
        protected bool MousePress = false; // This
        protected bool PreviousMousePress = false;
        protected Point MouseCords;
        protected Rectangle CollisionBounds;
        public Vector2 RelitiveCenter;

        Camera Camera;
        public bool HasCamera;
        /// <summary>
        /// Creates a button.
        /// When creating the button's animation set,
        /// the normal button texture has to be called "IDLE",
        /// the hover button texture has to be called "HOVER",
        /// the pressed button texture has to be called "PRESSED".
        /// </summary>
        /// <param name="position">The starting position of the button.</param>
        /// <param name="font">The font to use in the button</param>
        /// <param name="scale">The scale of the text in the button</param>
        /// <param name="fontColor">The color of the font to use in the button.</param>
        /// <param name="text">The text inside the button</param>
        /// <param name="color">The color to mask the button texture with.</param>
        /// <param name="animationSetList">The animation set list to use on the button.</param>
        public Button(Vector2 position, SpriteFont font, float scale, Color fontColor, string text, Color color, List<Sprite.AnimationSet> animationSetList)
            : base(position, color, animationSetList)
        {
            Color = color;
            AnimationSets = animationSetList;
            Label = new Label(new Vector2(position.X + ((animationSetList[0].frameSize.X - font.MeasureString(text).X) / 2), position.Y + ((animationSetList[0].frameSize.Y - font.MeasureString(text).Y) / 2)), font, scale, fontColor, text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="font"></param>
        /// <param name="scale"></param>
        /// <param name="fontColor"></param>
        /// <param name="text"></param>
        /// <param name="buttonColor"></param>
        public Button(Texture2D texture, Vector2 position, SpriteFont font, float scale, Color fontColor, string text, Color buttonColor)
            : base(position, buttonColor, texture)
        {
            Color = buttonColor;
            AddAnimations(texture);
            Label = new Label(new Vector2(position.X + (((texture.Width / 3) - font.MeasureString(text).X) / 2), position.Y + ((texture.Height - font.MeasureString(text).Y) / 2)), font, scale, fontColor, text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="font"></param>
        /// <param name="scale"></param>
        /// <param name="fontColor"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="animationSetList"></param>
        public Button(Vector2 position, SpriteFont font, float scale, Color fontColor, string text, Color color, List<Sprite.AnimationSet> animationSetList, Camera camera)
            : base(position, color, animationSetList)
        {
            Color = color;
            this.Camera = camera;
            HasCamera = true;
            AnimationSets = animationSetList;
            Label = new Label(new Vector2(position.X + ((animationSetList[0].frameSize.X - font.MeasureString(text).X) / 2), position.Y + ((animationSetList[0].frameSize.Y - font.MeasureString(text).Y) / 2)), font, scale, fontColor, text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="font"></param>
        /// <param name="scale"></param>
        /// <param name="fontColor"></param>
        /// <param name="text"></param>
        /// <param name="buttonColor"></param>
        public Button(Texture2D texture, Vector2 position, SpriteFont font, float scale, Color fontColor, string text, Color buttonColor, Camera camera)
            : base(position, buttonColor, texture)
        {
            Color = buttonColor;
            this.Camera = camera;
            HasCamera = true;
            AddAnimations(texture);
            Label = new Label(new Vector2(position.X + (((texture.Width / 3) - font.MeasureString(text).X) / 2), position.Y + ((texture.Height - font.MeasureString(text).Y) / 2)), font, scale, fontColor, text);
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
        protected Boolean hitButtonAlpha(Point mouseCords)
        {
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
            MouseState mState = Mouse.GetState();

            if (HasCamera == true)
            {
                CollisionBounds = new Rectangle((int)(position.X * Camera.Zoom), (int)(position.Y * Camera.Zoom), (int)(CurrentAnimation.frameSize.X * Camera.Zoom), (int)(CurrentAnimation.frameSize.Y * Camera.Zoom));
            }
            else
            {
                CollisionBounds = new Rectangle((int)position.X, (int)position.Y, CurrentAnimation.frameSize.X, CurrentAnimation.frameSize.Y);
            }

            RelitiveCenter = new Vector2(CollisionBounds.Center.X, CollisionBounds.Center.Y);

            MouseCords = new Point(mState.X, mState.Y);
            PreviousMousePress = MousePress;
            MousePress = mState.LeftButton == ButtonState.Pressed;

            Label.Position = new Vector2(position.X + ((CurrentAnimation.frameSize.X - Label.GetFont.MeasureString(Label.Text).X) / 2), position.Y + ((CurrentAnimation.frameSize.Y - Label.GetFont.MeasureString(Label.Text).Y) / 2));

            if (hitButtonAlpha(MouseCords))
            {
                if (MousePress)
                {
                    CurrentButtonState = ButtonStates.DOWN;
                    SetAnimation("PRESSED");
                }
                else if (!MousePress && PreviousMousePress)
                {
                    if (CurrentButtonState == ButtonStates.DOWN)
                    {
                        CurrentButtonState = ButtonStates.RELEASED;
                        SetAnimation("IDLE");
                    }
                }
                else
                {
                    CurrentButtonState = ButtonStates.HOVER;
                    SetAnimation("HOVER");
                }
            }
            else
            {
                CurrentButtonState = ButtonStates.UP;
                SetAnimation("IDLE");
            }
        }

        /// <summary>
        /// Returns weither if the button was clicked.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool Clicked()
        {
            if (CurrentButtonState == ButtonStates.RELEASED)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Used to draw the button.
        /// </summary>
        /// <param name="gameTime">The game time that the game runs off of.</param>
        /// <param name="spriteBatch">The sprite batch used to draw with.</param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            Label.Draw(gameTime, spriteBatch);
        }

        protected override void AddAnimations(Texture2D texture)
        {
            AddAnimation("IDLE", texture, new Point(texture.Width / 3, texture.Height), new Point(1, 1), new Point(0, 0), 1600, false);
            AddAnimation("HOVER", texture, new Point(texture.Width / 3, texture.Height), new Point(1, 1), new Point(texture.Width / 3, 0), 1600, false);
            AddAnimation("PRESSED", texture, new Point(texture.Width / 3, texture.Height), new Point(1, 1), new Point((texture.Width / 3) * 2, 0), 1600, false);
            SetAnimation("IDLE");

            base.AddAnimations(texture);
        }
    }
}