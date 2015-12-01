using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace VoidEngine.VGame
{
	public class Tile : Sprite
	{
		public enum TileCollisions
		{
			Passable,
			Impassable,
			Platform,
			Water
		}

		public TileCollisions TileType;

		protected int GridSize;

		List<Tile> TileList = new List<Tile>();
		int TileNum;

		public bool GeneratedRandom;
		public bool IsRandom;
		public int RandomNumber;

		Random random;

		public Tile(Texture2D texture, Vector2 position, TileCollisions tileType, int randomSeed, int tilenum, Color color)
			: base(position, color, texture)
		{
			AnimationSets = new List<AnimationSet>();
			GridSize = texture.Width / 4;
			random = new Random(randomSeed);
			IsRandom = true;
			AddAnimations(texture);
			this.TileNum = tilenum;
			this.TileType = tileType;
			inbounds = new Rectangle(0, 0, texture.Width / 4, texture.Height / 4);
		}

		public Tile(Texture2D texture, Vector2 position, TileCollisions tileType, List<Tile> tileList, int tilenum, Color color)
			: base(position, color, texture)
		{
			AnimationSets = new List<AnimationSet>();
			GridSize = texture.Width / 4;
			TileList = tileList;
			this.TileNum = tilenum;
			AddAnimations(texture);
			this.TileType = tileType;
			inbounds = new Rectangle(0, 0, texture.Width / 4, texture.Height / 4);
		}

		public void UpdateConnections()
		{
			bool mapright = IsSameResourceRightMe();
			bool mapleft = IsSameResourceLeftMe();
			bool mapup = IsSameResourceAboveMe();
			bool mapdown = IsSameResourceBelowMe();

			if (!mapright && !mapleft && !mapdown && !mapup)
				SetAnimation("0");
			else if (!mapright && mapleft && !mapdown && !mapup)
				SetAnimation("1");
			else if (mapright && mapleft && !mapdown && !mapup)
				SetAnimation("2");
			else if (mapright && !mapleft && !mapdown && !mapup)
				SetAnimation("3");
			else if (!mapright && !mapleft && mapdown && !mapup)
				SetAnimation("4");
			else if (!mapright && mapleft && mapdown && !mapup)
				SetAnimation("5");
			else if (mapright && mapleft && mapdown && !mapup)
				SetAnimation("6");
			else if (mapright && !mapleft && mapdown && !mapup)
				SetAnimation("7");
			else if (!mapright && !mapleft && mapdown && mapup)
				SetAnimation("8");
			else if (!mapright && mapleft && mapdown && mapup)
				SetAnimation("9");
			else if (mapright && mapleft && mapdown && mapup)
				SetAnimation("10");
			else if (mapright && !mapleft && mapdown && mapup)
				SetAnimation("11");
			else if (!mapright && !mapleft && !mapdown && mapup)
				SetAnimation("12");
			else if (!mapright && mapleft && !mapdown && mapup)
				SetAnimation("13");
			else if (mapright && mapleft && !mapdown && mapup)
				SetAnimation("14");
			else if (mapright && !mapleft && !mapdown && mapup)
				SetAnimation("15");
		}

		public override void Update(GameTime gameTime)
		{
			if (IsRandom && !GeneratedRandom)
			{
				RandomNumber = random.Next(0, 256);
				RandomNumber = (RandomNumber - 0) / (16 - 0);

				SetAnimation(RandomNumber.ToString());
				GeneratedRandom = true;
			}

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			base.Draw(gameTime, spriteBatch);
		}

		protected bool IsSameResourceAboveMe()
		{
			foreach (Tile t in TileList)
			{
				if (t.TileNum == TileNum && t.Position.Y == Position.Y - GridSize && t.Position.X == Position.X)
				{
					return true;
				}
			}

			return false;
		}

		protected bool IsSameResourceLeftMe()
		{
			foreach (Tile t in TileList)
			{
				if (t.TileNum == TileNum && t.Position.X == Position.X + GridSize && t.Position.Y == Position.Y)
				{
					return true;
				}
			}

			return false;
		}

		protected bool IsSameResourceRightMe()
		{
			foreach (Tile t in TileList)
			{
				if (t.TileNum == TileNum && t.Position.X == Position.X - GridSize && t.Position.Y == Position.Y)
				{
					return true;
				}
			}

			return false;
		}

		protected bool IsSameResourceBelowMe()
		{
			foreach (Tile t in TileList)
			{
				if (t.TileNum == TileNum && t.Position.Y == Position.Y + GridSize && t.Position.X == Position.X)
				{
					return true;
				}
			}

			return false;
		}

		public bool IsAResorceAboveMe()
		{
			foreach (Tile t in TileList)
			{
				if (t.Position.Y == Position.Y - GridSize && t.Position.X == Position.X)
				{
					return true;
				}
			}

			return false;
		}

		protected bool IsAResorceLeftMe()
		{
			foreach (Tile t in TileList)
			{
				if (t.Position.X == Position.X + GridSize && t.Position.Y == Position.Y)
				{
					return true;
				}
			}

			return false;
		}

		protected bool IsAResorceRightMe()
		{
			foreach (Tile t in TileList)
			{
				if (t.Position.X == Position.X - GridSize && t.Position.Y == Position.Y)
				{
					return true;
				}
			}

			return false;
		}

		protected bool IsAResorceBelowMe()
		{
			foreach (Tile t in TileList)
			{
				if (t.Position.Y == Position.Y + GridSize && t.Position.X == Position.X)
				{
					return true;
				}
			}

			return false;
		}

		protected override void AddAnimations(Texture2D texture)
		{
			AnimationSets.Add(new Sprite.AnimationSet("0", texture, new Point(GridSize, GridSize), Point.Zero, new Point(0, 0), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("1", texture, new Point(GridSize, GridSize), Point.Zero, new Point(GridSize, 0), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("2", texture, new Point(GridSize, GridSize), Point.Zero, new Point(GridSize * 2, 0), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("3", texture, new Point(GridSize, GridSize), Point.Zero, new Point(GridSize * 3, 0), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("4", texture, new Point(GridSize, GridSize), Point.Zero, new Point(0, GridSize), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("5", texture, new Point(GridSize, GridSize), Point.Zero, new Point(GridSize, GridSize), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("6", texture, new Point(GridSize, GridSize), Point.Zero, new Point(GridSize * 2, GridSize), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("7", texture, new Point(GridSize, GridSize), Point.Zero, new Point(GridSize * 3, GridSize), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("8", texture, new Point(GridSize, GridSize), Point.Zero, new Point(0, GridSize * 2), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("9", texture, new Point(GridSize, GridSize), Point.Zero, new Point(GridSize, GridSize * 2), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("10", texture, new Point(GridSize, GridSize), Point.Zero, new Point(GridSize * 2, GridSize * 2), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("11", texture, new Point(GridSize, GridSize), Point.Zero, new Point(GridSize * 3, GridSize * 2), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("12", texture, new Point(GridSize, GridSize), Point.Zero, new Point(0, GridSize * 3), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("13", texture, new Point(GridSize, GridSize), Point.Zero, new Point(GridSize, GridSize * 3), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("14", texture, new Point(GridSize, GridSize), Point.Zero, new Point(GridSize * 2, GridSize * 3), 0, false));
			AnimationSets.Add(new Sprite.AnimationSet("15", texture, new Point(GridSize, GridSize), Point.Zero, new Point(GridSize * 3, GridSize * 3), 0, false));
			SetAnimation("0");
		}
	}
}
