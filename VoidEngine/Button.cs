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
        /// This is the button's state
        /// </summary>
        public enum bState { HOVER, UP, DOWN, RELEASED }

        Label label;

        bState buttonState = new bState();
        bool mPress = false;
        bool pMPress = false;
        int mX;
        int mY;

        /// <summary>
        /// Creates a button.
        /// </summary>
        /// <param name="position">The position for the button.</param>
        /// <param name="font">The font for the text in the button.</param>
        /// <param name="text">The text in the button.</param>
        public Button(Vector2 position, SpriteFont font, string text) : base(position)
        {
            this.position = position;
            label = new Label(new Vector2(position.X + 2, position.Y + 2), font, text);
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
        Boolean hitButtonAlpha(float tx, float ty, Point frameTex, int x, int y)
        {
            if (hitButton(tx, ty, frameTex, x, y))
            {
                uint[] data = new uint[Convert.ToUInt32(frameTex.X) * Convert.ToUInt32(frameTex.Y)];

                currentAnimation.texture.GetData<uint>(data);

                if ((x - (int)tx) + (y - (int)ty) * frameTex.X < frameTex.X * frameTex.Y)
                {
                    return ((data[(Convert.ToUInt32(x) - (int)tx) + (Convert.ToUInt32(y) - (int)ty) * Convert.ToUInt32(frameTex.X)] & 0xFF000000) >> 24) > 20;
                }
            }

            return false;
        }

        /// <summary>
        /// The hit test for a button for hitTestAlpha overload 1.
        /// </summary>
        /// <param name="tx">The texture's x</param>
        /// <param name="ty">The texture's y</param>
        /// <param name="frameTex">The texture's with and height in Point form</param>
        /// <param name="x">The mouse's x</param>
        /// <param name="y">The mouse's y</param>
        /// <returns>Boolean</returns>
        Boolean hitButton(float tx, float ty, Point frameTex, int x, int y)
        {
            return (x >= tx && x <= tx + frameTex.X && y >= ty && y <= ty + frameTex.X);
        }

        /// <summary>
        /// Updates the button without the mouse, exectutes the hitButtonAlpha function too.
        /// </summary>
        public void updButton()
        {
            if (hitButtonAlpha(position.X, position.Y, currentAnimation.frameSize, mX, mY))
            {
                currentAnimation.fps = 0;

                if (mPress)
                {
                    buttonState = bState.DOWN;
                    currentFrame.X = 1;
                }
                else if (!mPress && pMPress)
                {
                    if (buttonState == bState.DOWN)
                    {
                        buttonState = bState.RELEASED;
                    }
                }
                else
                {
                    buttonState = bState.HOVER;
                    currentFrame.X = 2;
                }
            }
            else
            {
                buttonState = bState.UP;

                if (currentAnimation.fps > 0)
                {
                    currentAnimation.fps = currentAnimation.fps - currentAnimation.fps;
                }
                else
                {
                    currentFrame.Y = 0;
                }
            }
        }

        /// <summary>
        /// Updates the button with the mouse's cords and state
        /// </summary>
        /// <param name="gameTime">The main GameTime</param>
        public override void Update(GameTime gameTime)
        {
            currentAnimation.fps = gameTime.ElapsedGameTime.Milliseconds / 1000;

            MouseState mState = Mouse.GetState();

            mX = mState.X;
            mY = mState.Y;
            pMPress = mPress;
            mPress = mState.LeftButton == ButtonState.Pressed;

            updButton();
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the button
        /// </summary>
        /// <param name="gameTime">The main GameTime</param>
        /// <param name="spriteBatch">The main SpriteBatch</param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentAnimation.texture, position, new Rectangle(currentFrame.X * currentAnimation.frameSize.X, currentFrame.Y * currentAnimation.frameSize.Y, currentAnimation.frameSize.X, currentAnimation.frameSize.Y), Color.White);
        }
    }
}
