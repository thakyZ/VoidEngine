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
	/// The sprite class for VoidEngine.
	/// </summary>
	public class Sprite
	{
		/// <summary>
		/// The sprites animation properties.
		/// </summary>
		public struct AnimationSet
		{
			/// <summary>
			/// The name of the animation.
			/// </summary>
			public string name;
			/// <summary>
			/// The texture of the sprite sheet.
			/// </summary>
			public Texture2D texture;
			/// <summary>
			/// The size of the frame on the sprite sheet.
			/// </summary>
			public Point frameSize;
			/// <summary>
			/// The amount of the frames in the animation
			/// </summary>
			public Point sheetSize;
			/// <summary>
			/// The starting cordinates of the animation of the spritesheet.
			/// </summary>
			public Point startPosition;
			/// <summary>
			/// The tick of the animation.
			/// </summary>
			public int framesPerMillisecond;

			/// <summary>
			/// For creating a new animation set.
			/// </summary>
			/// <param name="name">The name of the animation.</param>
			/// <param name="texture">The texture of the sprite sheet.</param>
			/// <param name="frameSize">The size of the frame on the sprite sheet.</param>
			/// <param name="sheetSize">The amount of frames in the animation.</param>
			/// <param name="startPosition">The starting cordinates of the animation on the spritesheet.</param>
			/// <param name="framesPerMillisecond">The tick of the animation.</param>
			public AnimationSet(string name, Texture2D texture, Point frameSize, Point sheetSize, Point startPosition, int framesPerMillisecond)
			{
				this.name = name;
				this.texture = texture;
				this.frameSize = frameSize;
				this.sheetSize = sheetSize;
				this.startPosition = startPosition;
				this.framesPerMillisecond = framesPerMillisecond;
			}
		}
		
		/// <summary>
		/// The axis of the sprite to flip at.
		/// </summary>
		public enum Axis
		{
			X,
			Y,
			NONE
		}

		#region Animations
		/// <summary>
		/// Gets the current animation that the sprite is set to.
		/// </summary>
		public AnimationSet CurrentAnimation;
		/// <summary>
		/// Gets or sets the animation sets.
		/// Can only be set by child or self.
		/// </summary>
		public List<AnimationSet> AnimationSets
		{
			get;
			protected set;
		}
		/// <summary>
		/// The current frame that the sprite is at in its animation.
		/// </summary>
		public Point CurrentFrame;
		/// <summary>
		/// Gets or sets the animations frame tick time.
		/// </summary>
		protected int LastFrameTime
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the SpriteEffects value of the sprite.
		/// </summary>
		protected SpriteEffects flipEffect
		{
			get;
			set;
		}
		/// <summary>
		/// Gets if the sprite is flipped.
		/// </summary>
		public bool isFlipped
		{
			get
			{
				if (flipEffect != SpriteEffects.None)
				{
					return true;
				}
				
				return false;
			}
		}
		/// <summary>
		/// The offset position of the sprite.
		/// </summary>
		public Vector2 Offset = Vector2.Zero;
		/// <summary>
		/// Gets ors sets the scale factor of the sprite.
		/// </summary>
		public float Scale
		{
			get;
			protected set;
		}
		#endregion
		#region Movement
		/// <summary>
		/// The direction the player is moving twords.
		/// Can only be used by child or self.
		/// Only use -1, 0, or 1.
		/// </summary>
		protected Vector2 Direction;
		/// <summary>
		/// Gets the dirtection of the sprite.
		/// </summary>
		public Vector2 GetDirection
		{
			get
			{
				return Direction;
			}
		}
		/// <summary>
		/// The position that the player is at.
		/// Can only be used by child or self.
		/// </summary>
		protected Vector2 Position;
		/// <summary>
		/// Gets the position that the sprite is at.
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
		/// Can only be set by child or self.
		/// Used for the movement speed of the sprite.
		/// It is recomended to use values between -1 and 1.
		/// <summary>
		public float Speed
		{
			get;
			protected set;
		}
		/// <summary>
		/// Gets or sets the rotation of the sprite.
		/// Can only be set by child or self.
		/// Use values between 0 and 1.
		/// Ex. 'Rotation = $Degree$ * (float)Math.PI / 180;'
		/// </summary>
		public float Rotation
		{
			get;
			protected set;
		}
		/// <summary>
		/// The point to move the sprite from.
		/// Other wise known as the origin.
		/// </summary>
		public Vector2 RotationCenter = Vector2.Zero;
		/// <summary>
		/// Gets or sets weither the spite can move or not.
		/// Can be only set by child or self.
		/// Used to stop the player from moving.
		/// </summary>
		public bool CanMove
		{
			get;
			protected set;
		}
		/// <summary>
		/// Gets or sets if the sprite is moving.
		/// Can be only set by child or self.
		/// Used to tell if the player is moving.
		/// </summary>
		public bool isMoving
		{
			get;
			protected set;
		}
		/// <summary>
		/// Gets or sets the list of keys that the sprite uses.
		/// Can be only set by child or self.
		/// Indexes: [0]: Left | [1]: Up | [2]: Right | [3]: Down | [4]: Custom1 | [5]: Custom2 | [6]: Custom3 | [?]: etc.
		/// </summary>
		public List<Keys> MovementKeys
		{
			get;
			protected set;
		}
		#endregion

		/// <summary>
		/// Gets or sets the sprites color.
		/// Can be only set by child or self.
		/// </summary>
		public Color _Color
		{
			get;
			protected set;
		}

		/// <summary>
		/// Creates a sprite.
		/// </summary>
		/// <param name="postion">The stating position of the sprite.</param>
		/// <param name="color">The color to mask the sprite with.</param>
		/// <param name="animationSetList">The animation set of the sprite.</param>
		public Sprite(Vector2 position, Color color, List<AnimationSet> animationSetList)
		{
			MovementKeys = new List<Keys>();
			AnimationSets = new List<AnimationSet>();
			AnimationSets = animationSetList;
			Position = position;
			LastFrameTime = 0;
			_Color = color;
			Scale = 1f;
		}

		/// <summary>
		/// Update's the sprites frames.
		/// To make custom update functions, add the sprite class as
		/// a child of a class. Be sure to use 'using VoidEngine;'.
		/// </summary>
		/// <param name="gameTime">The game time that the game runs off of.</param>
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
		/// Used to draw the sprite.
		/// Put inbetween the spriteBatch.Begin and spriteBatch.End
		/// </summary>
		/// <param name="gameTime">The game time, that the game runs off of.</param>
		/// <param name="spriteBatch">The sprite batch to draw from.</param>
		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(CurrentAnimation.texture, Position - Offset, new Rectangle(CurrentAnimation.startPosition.X + (CurrentFrame.X * CurrentAnimation.frameSize.X), CurrentAnimation.startPosition.Y + (CurrentFrame.Y * CurrentAnimation.frameSize.Y), CurrentAnimation.frameSize.X, CurrentAnimation.frameSize.Y), _Color, Rotation, RotationCenter, Scale, flipEffect, 0);
		}

		/// <summary>
		/// Sets the current animation based off of it's name.
		/// </summary>
		/// <param name="setName">The name of the animation to set the sprite to.</param>
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
		/// Flips the sprite texture based off a bool and axis.
		/// To flip back turn isFlip to false or use the second version.
		/// </summary>
		/// <param name="isFlip">The bool to flip</param>
		/// <param name="axis">The axis to flip on</param>
		protected void FlipSprite(Axis axis)
		{
			if (axis == Axis.Y)
			{
				flipEffect = SpriteEffects.FlipHorizontally;
			}
			if (axis == Axis.X)
			{
				flipEffect = SpriteEffects.FlipVertically;
			}
			if (axis == Axis.NONE)
			{
				flipEffect = SpriteEffects.None;
			}
		}
	}
}