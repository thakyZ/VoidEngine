using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace VoidEngine
{
	public class Tile : Sprite
	{
		public int Type
		{
			get;
			protected set;
		}
		
		public Point Size
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
			}
		}

		public Rectangle Collisions
		{
			get
			{
				return collisions;
			}
			set
			{
				collisions = value;
			}
		}

		private Rectangle collisions;

		public enum TileCollisions
		{
			Passable = 0,
			Impassable = 1,
			Platform = 2,
		}
		
		public TileCollisions tileCollisions;

		protected Point size;

		public Tile(Vector2 position, int type, TileCollisions tileCollisions, Rectangle collisions, Color color, List<AnimationSet> animationSetLists)
			: base(position, color, animationSetLists)
		{
			this.tileCollisions = tileCollisions;
			this.collisions = collisions;

			Type = type;
			SetAnimation(type.ToString());
		}

		public override void Update(GameTime gameTime)
		{
			Size = CurrentAnimation.frameSize;
			
			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			base.Draw(gameTime, spriteBatch);
		}
	}
}
