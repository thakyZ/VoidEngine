using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using VoidEngine;

namespace VoidEngine
{
	public class Enemy : Player
	{
		public enum MovementType
		{
			FLY,
			HORIZONTAL,
			BOUNCE,
			NONE
		}

        public int HP;

		public MovementType _MovementType;

		public List<Rectangle> MapTiles;
		public List<Rectangle> MapSides;

        public bool DeleteMe = false;
        public bool MoveCircle = false;
        public bool DeleteCircle = false;

		public Enemy(Vector2 position, float gravity, MovementType movementType, Color color, List<AnimationSet> animationSetList, Player player, List<Rectangle> mapTiles, List<Rectangle> mapSides)
			: base(position, color, animationSetList)
		{
			this.myGame = myGame;
			SetAnimation("IDLE");
			DefaultGravityForce = gravity;
			MapSides = mapSides;
			MapTiles = mapTiles;
			GravityForce = gravity;
			isFalling = true;
			ProjectileList = new List<Projectile>();
			_MovementType = movementType;
			Direction = Vector2.Zero;
			playerCollisions = new Rectangle((int)Position.X, (int)Position.Y, animationSetList[0].frameSize.X, animationSetList[0].frameSize.Y);
		}

		public override void Update(GameTime gameTime)
		{
			playerCollisions.X = (int)Position.X;
			playerCollisions.Y = (int)Position.Y;

			if (_MovementType == MovementType.FLY)
			{
				Direction = new Vector2(myGame.gameManager.player.GetPosition.X - Position.X, myGame.gameManager.player.GetPosition.Y - Position.Y);
			}
			if (_MovementType == MovementType.HORIZONTAL || _MovementType == MovementType.BOUNCE)
			{
				Direction = new Vector2(myGame.gameManager.player.GetPosition.X - Position.X, Direction.Y);
			}

			if (Collision.Magnitude(Direction) <= 200)
			{
				Direction = Collision.UnitVector(Direction);

				if (myGame.gameManager.player.GetPosition.X == Position.X)
				{
					if (_MovementType == MovementType.FLY)
					{
						Direction = new Vector2(0, 0);
					}
					if (_MovementType == MovementType.HORIZONTAL || _MovementType == MovementType.BOUNCE)
					{
						Direction = new Vector2(0, Direction.Y);
					}
				}
				foreach (Rectangle r in MapTiles)
				{
					CheckCollision(playerCollisions, r);
				}
				foreach (Rectangle r in MapSides)
				{
					CheckCollision(playerCollisions, r);
				}
				if (_MovementType == MovementType.BOUNCE)
				{
					if (!isJumping && !canFall)
					{
						isJumping = true;
						isFalling = false;
						Direction.Y = 0;
						isJumping = true;
						Position.Y -= GravityForce * 1.5f;
					}
				}

				SetAnimation("CHASE");

				Position += Direction;
			}

			SetAnimation("IDLE");

			if (_MovementType == MovementType.BOUNCE || _MovementType == MovementType.HORIZONTAL)
			{
				UpdateGravity();
			}
		}
	}
}
