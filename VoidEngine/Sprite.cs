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
		/// <summary>
		/// The animation set for each type of animation in the player sprite sheet.
		/// </summary>
		public struct AnimationSet
		{
			/// <summary>
			/// The name "In all caps" that is used in the animation
			/// </summary>
			public string name;
			/// <summary>
			/// The texture of the sprite sheet
			/// </summary>
			public Texture2D texture;
			/// <summary>
			/// The size of each frame, all frames have to be the same size in one animation.
			/// </summary>
			public Point frameSize;
			/// <summary>
			/// The size of that animation in the sheet in frames.
			/// </summary>
			public Point sheetSize;
			/// <summary>
			/// The rate in milliseconds that the frames change
			/// </summary>
			public int framesPerMillisecond;
			/// <summary>
			/// The start Position in exact cordinates that the animation starts at.
			/// </summary>
			public Point startPosition;

			/// <summary>
			/// For creating a new animation set.
			/// </summary>
			/// <param name="name2">The name "In all caps" that is used in the animation</param>
			/// <param name="texture2">The texture of the sprite sheet</param>
			/// <param name="frameSize2">The size of each frame, all frames have to be the same size in one animation.</param>
			/// <param name="sheetSize2">The size of that animation in the sheet in frames.</param>
			/// <param name="startPosition2">The rate in milliseconds that the frames change</param>
			/// <param name="name2"></param>
			/// <param name="texture2"></param>
			/// <param name="frameSize2"></param>
			/// <param name="sheetSize2"></param>
			/// <param name="startPosition2"></param>
			/// <param name="framesPerMillisecond2"></param>
			/// <param name="framesPerMillisecond2">The start Position in exact cordinates that the animation starts at.</param>
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

		#region Animations
		/// <summary>
		/// Gets or sets the sprite's current animation.
		/// </summary>
		public AnimationSet CurrentAnimation;
		/// <summary>
		/// Gets or sets the animation sets.
		/// </summary>
		public List<AnimationSet> AnimationSets
		{
			get;
			protected set;
		}
		/// <summary>
		/// Gets or sets the sprites current animation frame.
		/// </summary>
		public Point CurrentFrame;
		/// <summary>
		/// Gets or sets the animations last frame time.
		/// </summary>
		public int LastFrameTime
		{
			get;
			protected set;
		}
		/// <summary>
		/// Gets or sets if the sprite is flipped.
		/// </summary>
		public SpriteEffects isFlipped
		{
			get;
			protected set;
		}
		#endregion
		#region Movement
		/// <summary>
		/// Gets or sets the direction that the sprite is moving towards.
		/// </summary>
		protected Vector2 Direction;
		/// <summary>
		/// Gets the dirtection of the sprite, publicly.
		/// </summary>
		public Vector2 GetDirection
		{
			get
			{
				return Direction;
			}
		}
		/// <summary>
		/// Gets or sets the position that the sprite is at.
		/// </summary>
		protected Vector2 Position;
		/// <summary>
		/// Gets the position that the sprite is at, publicly.
		/// </summary>
		public Vector2 GetPosition
		{
			get
			{
				return Position;
			}
		}
		/// <summary>
		/// Gets or sets the Speed that the sprite moves at.
		/// <summary>
		public float Speed
		{
			get;
			protected set;
		}
        /// <summary>
        /// 
        /// </summary>
        public float Rotation
        {
            get;
            protected set;
        }
        /// <summary>
        /// 
        /// </summary>
        public Vector2 RotationCenter;
		/// <summary>
		/// Gets or sets weither the spite can move or not.
		/// </summary>
		public bool CanMove
		{
			get;
			protected set;
		}

		public bool isMoving
		{
			get;
			protected set;
		}
		/// <summary>
		/// Gets or sets the list of keys that the sprite uses.
		/// Indexes: [0]: Left | [1]: Up | [2]: Right | [3]: Down | [4]: Custom1 | [5]: Custom2 | [6]: Custom3 | [?]: etc.
		/// </summary>
		protected List<Keys> MovementKeys;
		#endregion

		/// <summary>
		/// Gets or sets the sprites color.
		/// </summary>
		public Color _Color
		{
			get;
			protected set;
		}

		/// <summary>
		/// Creates the sprite with custom properties
		/// </summary>
		/// <param name="postion">The Position of the sprite.</param>
		/// <param name="animationSetList">The list of animations.</param>
		public Sprite(Vector2 position, Color color, List<AnimationSet> animationSetList)
		{
			MovementKeys = new List<Keys>();
			AnimationSets = new List<AnimationSet>();
			AnimationSets = animationSetList;
			Position = position;
			LastFrameTime = 0;
			_Color = color;
		}

		/// <summary>
		/// Put this in the Update function
		/// </summary>
		/// <param name="gameTime">The main GameTime</param>
		public virtual void Update(GameTime gameTime)
		{
			LastFrameTime += gameTime.ElapsedGameTime.Milliseconds;

			if (LastFrameTime >= CurrentAnimation.framesPerMillisecond)
			{
				CurrentFrame.X++;

				if (CurrentFrame.X >= CurrentAnimation.sheetSize.X)
				{
					CurrentFrame.Y++;
					CurrentFrame.X = 0;

					if (CurrentFrame.Y >= CurrentAnimation.sheetSize.Y)
					{
						CurrentFrame.Y = 0;
					}
				}

				LastFrameTime = 0;
			}
		}

		/// <summary>
		/// Put inbetween the spriteBatch.Begin and spriteBatch.End
		/// </summary>
		/// <param name="gameTime">The main GameTime</param>
		/// <param name="spriteBatch">The main SpriteBatch</param>
		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(CurrentAnimation.texture, this.Position + RotationCenter, new Rectangle(CurrentAnimation.startPosition.X + (CurrentFrame.X * CurrentAnimation.frameSize.X), CurrentAnimation.startPosition.Y + (CurrentFrame.Y * CurrentAnimation.frameSize.Y), CurrentAnimation.frameSize.X, CurrentAnimation.frameSize.Y), _Color, Rotation, RotationCenter, 1f, isFlipped, 0);
		}

		/// <summary>
		/// Set the currentAnimation.
		/// </summary>
		/// <param name="setName">The name of the animation to set.</param>
		public void SetAnimation(string setName)
		{
			if (CurrentAnimation.name != setName)
			{
				foreach (AnimationSet a in AnimationSets)
				{
					if (a.name == setName)
					{
						CurrentAnimation = a;
						CurrentFrame = Point.Zero;
					}
				}
			}
		}

		/// <summary>
		/// Flips the sprite texture based off a bool
		/// </summary>
		/// <param name="isFlip">The bool to flip</param>
		protected void FlipSprite(bool isFlip, bool flipHorizontally, bool flipVertically)
		{
			if (!isFlip)
			{
				isFlipped = SpriteEffects.None;

				return;
			}

			if (isFlip && flipHorizontally)
			{
				isFlipped = SpriteEffects.FlipHorizontally;
			}
			if (isFlip && flipVertically)
			{
				isFlipped = SpriteEffects.FlipVertically;
			}
		}
	}
}