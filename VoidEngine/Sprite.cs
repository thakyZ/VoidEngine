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
    /// The Sprite class for VoidEngine
    /// </summary>
    public class Sprite
    {
        protected Point frameSize;
        protected Point sheetSize;
        protected int fTime;
        protected Texture2D texture;
        protected Vector2 position;

        protected Point currentFrame;
        protected int lFTime;

        protected KeyboardState keyboardState, pKeyboardState;
        protected bool move;
        protected int speed;
        protected Keys up;
        protected Keys down;
        protected Keys left;
        protected Keys right;

        /// <summary>
        /// Creates the sprite with custom properties
        /// </summary>
        /// <param name="tex">The texture</param>
        /// <param name="pos">the position</param>
        /// <param name="frameWidth">the width of each frame</param>
        /// <param name="frameHeight">the height of each frame</param>
        /// <param name="sheetWidth">the amount of frames, widthwise</param>
        /// <param name="sheetHeight">the ammount of frames, height wise</param>
        /// <param name="fps">the frames per milliseconds</param>
        public Sprite(Texture2D tex, Vector2 pos, int frameWidth, int frameHeight, int sheetWidth, int sheetHeight, int fps)
        {
            texture = tex;
            position = pos;
            move = false;

            currentFrame = Point.Zero;
            lFTime = 0;
        }

        /// <summary>
        /// Creates the sprite with custom properties, and makes the sprite able to move
        /// </summary>
        /// <param name="tex">The texture</param>
        /// <param name="pos">the position</param>
        /// <param name="frameWidth">the width of each frame</param>
        /// <param name="frameHeight">the height of each frame</param>
        /// <param name="sheetWidth">the amount of frames, widthwise</param>
        /// <param name="sheetHeight">the ammount of frames, height wise</param>
        /// <param name="fps">the frames per milliseconds</param>
        /// <param name="sp">the speed the sprite moves</param>
        public Sprite(Texture2D tex, Vector2 pos, int frameWidth, int frameHeight, int sheetWidth, int sheetHeight, int fps, int sp, Keys u, Keys d, Keys l, Keys r)
        {
            texture = tex;
            position = pos;
            speed = sp;
            move = true;
            up = u;
            down = d;
            left = l;
            right = r;

            currentFrame = Point.Zero;
            lFTime = 0;
        }

        /// <summary>
        /// Create the sprite with default properties.
        /// frameSize = (60, 50)
        /// sheetSize = (5, 6)
        /// fTime = 16
        /// </summary>
        /// <param name="tex">The texture for the sprite</param>
        /// <param name="pos">The position for the sprite</param>
        public Sprite(Texture2D tex, Vector2 pos)
        {
            frameSize = new Point(60, 50);
            sheetSize = new Point(5, 6);
            fTime = 16;
            move = false;

            texture = tex;
            position = pos;

            currentFrame = Point.Zero;
            lFTime = 0;
        }

        /// <summary>
        /// Put this in the Update function
        /// </summary>
        /// <param name="gameTime">The main GameTime</param>
        public virtual void Update(GameTime gameTime)
        {
            if (move == true)
            {
                keyboardState = Keyboard.GetState();
            }

            lFTime += gameTime.ElapsedGameTime.Milliseconds;

            if (lFTime >= fTime)
            {
                currentFrame.X++;

                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.Y++;
                    currentFrame.X = 0;

                    if (currentFrame.Y >= sheetSize.Y)
                    {
                        currentFrame.Y = 0;
                    }
                }

                lFTime = 0;
            }
        }

        public virtual void Update(GameTime gameTime, Vector2 a, Vector2 b, Vector2 c, Vector2 d)
        {
        }

        /// <summary>
        /// Put inbetween the spriteBatch.Begin and spriteBatch.End
        /// </summary>
        /// <param name="gameTime">The main GameTime</param>
        /// <param name="spriteBatch">The main SpriteBatch</param>
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White);
        }
    }
}
