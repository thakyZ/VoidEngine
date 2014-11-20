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
    public class Button
    {
        /// <summary>
        /// This is the button's state
        /// </summary>
        public enum bState { HOVER, UP, DOWN, RELEASED }

        Point frameSize;
        Point sheetSize;
        int fTime;
        Point currentFrame;
        Texture2D texture;
        Vector2 position;
        Label label;
        bState buttonState = new bState();
        bool mPress = false;
        bool pMPress = false;
        int mX;
        int mY;

        /// <summary>
        /// Creates a button with custom paramiters.
        /// </summary>
        /// <param name="tex">the texture</param>
        /// <param name="pos">the position for the button</param>
        /// <param name="frameWidth">the button's width</param>
        /// <param name="frameHeight">the button's height</param>
        /// <param name="sheetWidth">the texture's width</param>
        /// <param name="sheetHeight">the texture's height</param>
        /// <param name="text">the text in the button</param>
        public Button(Texture2D tex, Vector2 pos, int frameWidth, int frameHeight, int sheetWidth, int sheetHeight, string text)
        {
            texture = tex;
            position = pos;
            frameSize = new Point(frameWidth, frameHeight);
            sheetSize = new Point(sheetWidth, sheetHeight);
            label = new Label(text);
        }

        /// <summary>
        /// The button hit test's main function
        /// </summary>
        /// <param name="pos">the position</param>
        /// <param name="frameTex">the frame's size</param>
        /// <param name="x">the x of the mouse</param>
        /// <param name="y">the y of the mouse</param>
        /// <returns>Boolean</returns>
        Boolean hitButtonAlpha(Vector2 pos, Point frameTex, int x, int y)
        {
            return hitButtonAlpha(0, 0, frameTex, Convert.ToInt32(frameTex.X * (x - pos.X) / frameTex.X), Convert.ToInt32(frameTex.Y * (y - pos.Y) / pos.Y));
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

                texture.GetData<uint>(data);

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
            if (hitButtonAlpha(position, frameSize, mX, mY))
            {
                fTime = 0;

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

                if (fTime > 0)
                {
                    fTime = fTime - fTime;
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
        public void Update(GameTime gameTime)
        {
            fTime = gameTime.ElapsedGameTime.Milliseconds / 1000;

            MouseState mState = Mouse.GetState();

            mX = mState.X;
            mY = mState.Y;
            pMPress = mPress;
            mPress = mState.LeftButton == ButtonState.Pressed;

            updButton();
        }

        /// <summary>
        /// Draws the button
        /// </summary>
        /// <param name="gameTime">The main GameTime</param>
        /// <param name="spriteBatch">The main SpriteBatch</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White);
        }
    }