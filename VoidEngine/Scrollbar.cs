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
    /// The Scrollbar class for VoidEngine
    /// </summary>
    public class Scrollbar
    {
        /// <summary>
        /// Creates the Scrollbar
        /// </summary>
        /// <param name="tex">The texture</param>
        /// <param name="pos">The position</param>
        /// <param name="width">The width</param>
        /// <param name="height">The Height</param>
        /// <param name="vertical">If this is a vertical or horizontal scroll bar</param>
        /// <param name="visible">If this is visible</param>
        /// <param name="vertPos">The Scroll bar's position (works for horizontal too)</param>
        public Scrollbar(Texture2D tex, Vector2 pos, int width, int height, bool vertical, bool visible, int vertPos, int horzPos)
        {
        }
    }
}