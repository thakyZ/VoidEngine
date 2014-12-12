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
    class GUI
    {
        public List<Rectangle> guiWindows;
        public List<Color> guiWindowsColor;
        public List<Texture2D> guiWindowsTexture;
        public List<Buttons> guiButtons;
        public Color shadedColor;
        public Vector2 position;
        public bool active = false;


        public GUI(Vector2 position, List<Rectangle> guiWindows, List<Texture2D> guiWindowsTexture, List<Color> guiWindowsColor, List<Buttons> guiButtons, bool active)
        {
            this.guiWindows = guiWindows;
            this.guiWindowsColor = guiWindowsColor;
            this.guiWindowsTexture = guiWindowsTexture;
            this.guiButtons = guiButtons;
            this.position = position;
            this.active = active;
        }

        public GUI(Vector2 position, List<Rectangle> guiWindows, List<Texture2D> guiWindowsTexture, List<Color> guiWindowsColor, List<Buttons> guiButtons, bool active, Color shadedColor)
        {
            this.guiWindows = guiWindows;
            this.guiWindowsColor = guiWindowsColor;
            this.guiWindowsTexture = guiWindowsTexture;
            this.guiButtons = guiButtons;
            this.position = position;
            this.shadedColor = shadedColor;
            this.active = active;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (Button b in guiButtons)
            {
                b.Update(gameTime);
            }
        }

        public void Clicked(int buttonIndex)
        {
            if (guiButtons[buttonIndex].Clicked())
            {
                return true;
            }

            return false;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (active)
            {
                foreach (Rectangle r in guiWindows())
                {
                    foreach (Texture2D t in guiWindowsTexture)
                    {
                        foreach (Color c in guiWindowsColor)
                        {
                            foreach (Button b in guiButtons)
                            {
                                spriteBatch.Draw(t, new Rectange(0, 0, position.X, position.Y), r, c);

                                b.Draw();
                            }
                        }
                    }
                }
            }
        }
    }
}
