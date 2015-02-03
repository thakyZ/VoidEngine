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
        // <summary>
        // The type of AI the sprite or enemy or player will have
        // Only PLAYER and NONE are implemented
        // </summary>
        public enum AIType { NONE, ENEMY, AI, PLAYER };

        // <summary>
        // The type of movement that the player or AI or sprite will have
        // </summary>
        public enum MovementType { NONE, HORIZONTAL, VERTICAL, TOPDOWN, PLATFORMER };

        // <summary>
        // The animation set for each type of animation in the player sprite sheet.
        // </summary>
        public struct AnimationSet
        {
            // <summary>
            // The name "In all caps" that is used in the animation
            // </summary>
            public string name;
            // <summary>
            // The texture of the sprite sheet
            // </summary>
            public Texture2D texture;
            // <summary>
            // The size of each frame, all frames have to be the same size in one animation.
            // </summary>
            public Point frameSize;
            // <summary>
            // The size of that animation in the sheet in frames.
            // </summary>
            public Point sheetSize;
            // <summary>
            // The rate in milliseconds that the frames change
            // </summary>
            public int framesPerMillisecond;
            // <summary>
            // The start position in exact cordinates that the animation starts at.
            // </summary>
            public Point startPosition;

            // <summary>
            // For creating a new animation set.
            // </summary>
            // <param name="name2">The name "In all caps" that is used in the animation</param>
            // <param name="texture2">The texture of the sprite sheet</param>
            // <param name="frameSize2">The size of each frame, all frames have to be the same size in one animation.</param>
            // <param name="sheetSize2">The size of that animation in the sheet in frames.</param>
            // <param name="startPosition2">The rate in milliseconds that the frames change</param>
            // <param name="framesPerMillisecond2">The start position in exact cordinates that the animation starts at.</param>
            public AnimationSet(string name2, Texture2D texture2, Point frameSize2, Point sheetSize2, Point startPosition2, int framesPerMillisecond2)
            {
                name = name2;
                texture = texture2;
                frameSize = frameSize2;
                sheetSize = sheetSize2;
                framesPerMillisecond = framesPerMillisecond2;
                startPosition = startPosition2;
            }
        }

        // <summary>
        // The current AnimationSet.
        // </summary>
        public AnimationSet currentAnimation;
        List<AnimationSet> animationSets = new List<AnimationSet>(); // The list of animation sets.
        Point currentFrame; // The current frame's position in sheet cords.
        int lastFrameTime; // frame time before the update.

        /// <summary>
        /// The current direction that the sprite is moving at.
        /// </summary>
        public Vector2 direction;
        /// <summary>
        /// The current direction that the sprite is at.
        /// </summary>
        public Vector2 position;
        /// <summary>
        /// The current speed that the sprite is moving at.
        /// <summary>
        public float speed;
        /// <summary>
        /// Weither the sprite can move or not.
        /// </summary>
        public bool canMove = false;
        /// <summary>
        /// The type of AI the sprite has.
        /// </summary>
        public AIType aiType;
        /// <summary>
        /// The type of movement the sprite has.
        /// </summary>
        public MovementType movementType;
        /// <summary>
        /// The list of keys that the sprite can move at.
        /// indexes: [0]: Left | [1]: Up | [2]: Right | [3]: Down | [4]: Custom1 | [5]: Custom2 | [6]: Custom3
        /// </summary>
        public List<Keys> MovementKeys = new List<Keys>();

        /// <summary>
        /// The keyboard detection
        /// </summary>
        protected KeyboardState keyboardState, previousKeyboardState;


        /// <summary>
        /// Creates the sprite with custom properties
        /// </summary>
        /// <param name="postion">The position of the sprite.</param>
        /// <param name="animationSetList">The list of animations.</param>
        public Sprite(Vector2 position, List<AnimationSet> animationSetList)
        {
            animationSets = animationSetList;
            this.position = position;
            lastFrameTime = 0;
        }

        /// <summary>
        /// Put this in the Update function
        /// </summary>
        /// <param name="gameTime">The main GameTime</param>
        public virtual void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            previousKeyboardState = keyboardState;

            lastFrameFTime += gameTime.ElapsedGameTime.Milliseconds;

            if (lastFrameTime >= currentAnimation.framesPerMillisecond)
            {
                currentFrame.X++;

                if (currentFrame.X >= currentAnimation.sheetSize.X)
                {
                    currentFrame.Y++;
                    currentFrame.X = 0;

                    if (currentFrame.Y >= currentAnimation.sheetSize.Y)
                    {
                        currentFrame.Y = 0;
                    }
                }

                lastFrameTime = 0;
            }
        }

        /// <summary>
        /// Put inbetween the spriteBatch.Begin and spriteBatch.End
        /// </summary>
        /// <param name="gameTime">The main GameTime</param>
        /// <param name="spriteBatch">The main SpriteBatch</param>
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentAnimation.texture, this.position, new Rectangle(currentAnimation.startPosition.X + (currentFrame.X * currentAnimation.frameSize.X), currentAnimation.startPosition.Y + (currentFrame.Y * currentAnimation.frameSize.Y), currentAnimation.frameSize.X, currentAnimation.frameSize.Y), Color.White);
        }

        /// <summary>
        /// Set the currentAnimation.
        /// </summary>
        /// <param name="setName">The name of the animation to set.</param>
        public void SetAnimation(string setName)
        {
            if (currentAnimation.name != setName)
            {
                foreach (AnimationSet a in animationSets)
                {
                    if (a.name == setName)
                    {
                        currentAnimation = a;
                        currentFrame = Point.Zero;
                    }
                }
            }
        }

        /// <summary>
        /// The check if the sprite collides rectangulary.
        /// </summary>
        public Rectangle collisionRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, currentAnimation.frameSize.X, currentAnimation.frameSize.Y);
        }
    }
}