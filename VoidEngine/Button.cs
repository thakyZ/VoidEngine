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

namespace myFirstXNAGame
{
    class Button
    {
        public enum bState { HOVER, UP, DOWN, RELEASED }
        Point frameSize;
        Point sheetSize;
        int fTime;
        Point currentFrame;
        int lFTime;
        Texture2D texture;
        Vector2 position;
        Label label;
        bState buttonState = new bState;
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

        public Boolean hitButtonAlpha(Vector2 pos, Vetor2 frameTex, int x, int y)
        {
            return hitButtonAlpha(0, 0, frameTex, frameTex.X * (x - pos.X) / frameTex.X, frameTex.X * (y - pos.Y) / pos.Y);
        }

        public Boolean hitButtonAlpha(float tx, float ty, Vector2 frameTex, int x, int y)
        {
            if (hitButton(tx, ty, frameTex, x, y))
            {
                uint[] data = new uint[frameTex.X * frameTex.Y];

                texture.GetData<uint>(data);

                if ((x - (int)tx) + (y - (int)ty) * frameTex.X < frameTex.X * frameTex.Y)
                {
                    return ((data[(x - (int)tx) + (y - (int)ty) * frameTex.X] & 0xFF000000) >> 24) > 20;
                }
            }

            return false;
        }

        public Boolean hitButton(float tx, float ty, Vector2 frameTex, int x, int y)
        {
            return (x >= tx && x <= tx + frameTex.X && y >= ty && y <= ty + frameTex.X);
        }

        public void updButton()
        {
            if (hitButtonAlpha(position, frameSize, mX, mY))
            {
                buttonTime = 0.0;

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

                if (buttonTime > 0)
                {
                    buttonTime = buttonTime - fTime;
                }
                else
                {
                	currentFrame.Y = 0;
                }
            }
        }

        /// <summary>
        /// Updates the button stuff
        /// Use buttonState to execute a function.
        /// </summary>
        public Update(GameTime gameTime)
        {
            fTime = gameTime.ElapsedGameTime.Milliseconds / 1000.0;

            MouseState mState = Mouse.GetState();

            mX = mState.X;
            mY = mState.Y;
            pMPress = mPress;
            mPress = mState.LeftButton == buttonState.Pressed;

            updButton();
        }

        public Draw()
        {
            spriteBatch.Draw(texture, position, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White);
        }
    }
}