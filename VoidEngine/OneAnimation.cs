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
        protected Keys up;
        protected Keys down;
        protected Keys left;
        protected Keys right;

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
        public OneAnimation(Vector2 position) : base(position)
        {
            move = false;
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
        public OneAnimation(Vector2 position, int speed, Keys up, Keys down, Keys left, Keys right) : base(position)
        {
            move = true;
            this.speed = speed;
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
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
                if (position.Y >= 480 - currentAnimation.frameSize.Y)
                {
                    position.Y = 480 - currentAnimation.frameSize.Y;
                }
                if (position.X <= 0)
                {
                    position.X = 0;
                }
                if (position.X >= 480 - currentAnimation.frameSize.X)
                {
                    position.X = 480 - currentAnimation.frameSize.X;
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
