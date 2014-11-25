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
        protected bool move;
        protected int speed;
        protected Keys up;
        protected Keys down;
        protected Keys left;
        protected Keys right;

        /// <summary>
        /// The creator of TwoAnimation class.
        /// </summary>
        /// <param name="tex">The texture</param>
        /// <param name="pos">The position</param>
        /// <param name="frameWidth">The frame's width</param>
        /// <param name="frameHeight">The frame's Height</param>
        /// <param name="sheetWidth">The amount of frames on the x axis</param>
        /// <param name="sheetHeight">The amount of frames on the y axis</param>
        /// <param name="fps">The frames per second in miliseconds</param>
        public TwoAnimation(Vector2 position) : base(position)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void AddAnimations(Texture2D tex)
        {
            Addanimation("IDLE", tex, new Point(60, 50), new Point(1, 1), new Point(0, 0), 16);
            Addanimation("WALK", tex, new Point(60, 50), new Point(3, 4), new Point(0, 60), 16);
            Addanimation("BLOCK", tex, new Point(60, 50), new Point(2, 2), new Point(150, 200), 16);
            Addanimation("SHOOT", tex, new Point(60, 50), new Point(1, 3), new Point(240, 0), 16);
            Addanimation("JUMP", tex, new Point(60, 50), new Point(5, 1), new Point(0, 150), 16);
            Addanimation("SWING", tex, new Point(60, 50), new Point(3, 2), new Point(0, 200), 16);
            SetAnimation("IDLE");
        }
    }
}
