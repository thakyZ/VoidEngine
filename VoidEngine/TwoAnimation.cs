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
    /// The TwoAnimation sub-class of Sprite
    /// </summary>
    public class TwoAnimation : Sprite
    {
        /// <summary>
        /// The creator of TwoAnimation class with default properties
        /// frameSize = (60, 50)
        /// sheetSize = (5, 6)
        /// fTime = 16
        /// </summary>
        /// <param name="tex">The texture</param>
        /// <param name="pos">The position</param>
        public TwoAnimation(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            frameSize = new Point(60, 50);
            sheetSize = new Point(5, 6);
            fTime = 16;
        }

        /// <summary>
        /// The creator of TwoAnimation class with custom properties
        /// </summary>
        /// <param name="tex">The texture</param>
        /// <param name="pos">The position</param>
        /// <param name="frameWidth">The frame's width</param>
        /// <param name="frameHeight">The frame's Height</param>
        /// <param name="sheetWidth">The amount of frames on the x axis</param>
        /// <param name="sheetHeight">The amount of frames on the y axis</param>
        /// <param name="fps">The frames per second in miliseconds</param>
        public TwoAnimation(Texture2D tex, Vector2 pos, int frameWidth, int frameHeight, int sheetWidth, int sheetHeight, int fps) : base(tex, pos, frameWidth, frameHeight, sheetWidth, sheetHeight, fps)
        {
            frameSize = new Point(frameWidth, frameHeight);
            sheetSize = new Point(sheetWidth, sheetHeight);
            fTime = fps;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
