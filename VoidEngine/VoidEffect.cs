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
    ///
    /// </summary>
    public class VoidEffect
    {
        BloomComponent bloom = null;
        Microsoft.Xna.Framework.Game myGame;

        /// <summary>
        /// This is for creating bloom effect.
        /// </summary>
        public VoidEffect(Microsoft.Xna.Framework.Game myGame)
        {
            bloom = new BloomComponent(myGame);
            this.myGame = myGame;
            myGame.Components.Add(bloom);
            bloom.Settings = new BloomSettings(null, 0.25f, 4, 2, 1, 1.5f, 1);
        }

        public virtual void Update(GameTime gameTime)
        {
            bloom.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (bloom != null)
            {
                bloom.BeginDraw();
            }
        }
    }
}