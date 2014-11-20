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
    /// The OneAnimation sub-class of Sprite
    /// </summary>
    public class OneAnimation : Sprite
    {
        /// <summary>
        /// The creator of OneAnimation class with default properties
        /// frameSize = (60, 50)
        /// sheetSize = (5, 6)
        /// fTime = 16
        /// </summary>
        /// <param name="tex">The texture</param>
        /// <param name="pos">The position</param>
        public OneAnimation(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            frameSize = new Point(60, 50);
            sheetSize = new Point(5, 6);
            move = false;
            fTime = 16;
        }

        /// <summary>
        /// The creator of OneAnimation class with custom properties
        /// </summary>
        /// <param name="tex">The texture</param>
        /// <param name="pos">The position</param>
        /// <param name="frameWidth">The frame's width</param>
        /// <param name="frameHeight">The frame's Height</param>
        /// <param name="sheetWidth">The amount of frames on the x axis</param>
        /// <param name="sheetHeight">The amount of frames on the y axis</param>
        /// <param name="fps">The frames per second in miliseconds</param>
        public OneAnimation(Texture2D tex, Vector2 pos, int frameWidth, int frameHeight, int sheetWidth, int sheetHeight, int fps) : base(tex, pos, frameWidth, frameHeight, sheetWidth, sheetHeight, fps)
        {
            frameSize = new Point(frameWidth, frameHeight);
            sheetSize = new Point(sheetWidth, sheetHeight);
            move = false;
            fTime = fps;
        }

        /// <summary>
        /// The creator of OneAnimation class with custom properties
        /// </summary>
        /// <param name="tex">The texture</param>
        /// <param name="pos">The position</param>
        /// <param name="frameWidth">The frame's width</param>
        /// <param name="frameHeight">The frame's Height</param>
        /// <param name="sheetWidth">The amount of frames on the x axis</param>
        /// <param name="sheetHeight">The amount of frames on the y axis</param>
        /// <param name="fps">The frames per second in miliseconds</param>
        public OneAnimation(Texture2D tex, Vector2 pos, int frameWidth, int frameHeight, int sheetWidth, int sheetHeight, int fps, int sp, Keys u, Keys d, Keys l, Keys r) : base(tex, pos, frameWidth, frameHeight, sheetWidth, sheetHeight, fps, sp, u, d, l, r)
        {
            frameSize = new Point(frameWidth, frameHeight);
            sheetSize = new Point(sheetWidth, sheetHeight);
            move = true;
            fTime = fps;
            speed = sp;
            up = u;
            down = d;
            left = l;
            right = r;
        }

        public override void Update(GameTime gameTime)
        {
            if (move == true)
            {
                if (keyboardState.IsKeyDown(up))
                {
                    position.Y -= speed;
                }
                if (keyboardState.IsKeyDown(left))
                {
                    position.X -= speed;
                }
                if (keyboardState.IsKeyDown(down))
                {
                    position.Y += speed;
                }
                if (keyboardState.IsKeyDown(right))
                {
                    position.X += speed;
                }

                if (position.Y <= 0)
                {
                    position.Y = 0;
                }
                if (position.Y >= 480 - frameSize.Y)
                {
                    position.Y = 480 - frameSize.Y;
                }
                if (position.X <= 0)
                {
                    position.X = 0;
                }
                if (position.X >= 480 - frameSize.X)
                {
                    position.X = 480 - frameSize.X;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
