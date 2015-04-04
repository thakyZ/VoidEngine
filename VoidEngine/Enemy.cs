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
			BOSSHEAD,
			BOSSBOUNCE,
			RAT,
			NONE
		}

		public MovementType movementType;

		public Player player;

		public Vector2 tempVelocity;

		public float JumpDelayTimer = 500;
		public bool isJumping2 = false;

		public bool DeleteMe = false;

		public Enemy(Vector2 position, float gravity, MovementType movementType, Color color, List<AnimationSet> animationSetList, Player player)
			: base(position, color, animationSetList)
		{
			Level = 1;
			MainHP = 30;
			MaxHP = 30;
			JumpbackTimer = 0;
			MaxMoveSpeed = 200;

			SetAnimation("IDLE" + Level);

			#region Set default variables
			this.player = player;
			this.movementType = movementType;
			this.CanShoot = true;
			#endregion

			if (movementType == MovementType.FLY)
			{
				RotationCenter = new Vector2(animationSetList[0].frameSize.X / 2, animationSetList[0].frameSize.Y / 2);
				Offset = new Vector2(-(animationSetList[0].frameSize.X / 2), -(animationSetList[0].frameSize.Y / 2));
			}

			int width = (int)(animationSetList[0].frameSize.X);
			int left = (animationSetList[0].frameSize.X - width);
			int height = (int)(animationSetList[0].frameSize.Y);
			int top = animationSetList[0].frameSize.Y - height;
			inbounds = new Rectangle(left, top, width, height);
		}

		public void Update(GameTime gameTime, Player player, List<Tile> TileList, List<Rectangle> RectangleList)
		{
			this.TileList = TileList;
			this.MapBoundries = RectangleList;
			this.player = player;

			tempVelocity = new Vector2(player.PositionCenter.X - PositionCenter.X, player.PositionCenter.Y - PositionCenter.Y);

			HandleMovement(gameTime);

			HandleHealth();

			HandleAnimations(gameTime);

			Center = new Vector2(Inbounds.Width / 2, Inbounds.Height / 2);

			if (!isDead && isGrounded)
			{
				if (Math.Abs(Velocity.X) - 0.02f > 0)
				{
					SetAnimation("WALK" + Level);
				}
				else
				{
					SetAnimation("IDLE" + Level);
				}
			}

			Movement = 0.0f;
			isJumping = false;
		}

		protected void HandleMovement(GameTime gameTime)
		{
			if (Math.Abs(Movement) < 0.5f)
			{
				Movement = 0.0f;
			}

			if (Collision.Magnitude(tempVelocity) <= 200)
			{
				if (player.PositionCenter.X - PositionCenter.X < 0)
				{
					Movement = -1;
				}
				else if (player.PositionCenter.X - PositionCenter.X > 0)
				{
					Movement = 1;
				}
				else if (player.PositionCenter.X == PositionCenter.X)
				{
					Movement = 0;
				}

				if (movementType != MovementType.BOUNCE)
				{
					SetAnimation("WALK" + Level);
				}

				if (movementType == MovementType.FLY)
				{
					Rotation += 0.05f;
				}

				if (movementType != MovementType.BOUNCE && movementType != MovementType.FLY)
				{
					foreach (Tile t in TileList)
					{
						if (t.tileCollisions == Tile.TileCollisions.Impassable)
						{
							if (BoundingCollisions.TouchLeftOf(t.Collisions) || BoundingCollisions.TouchRightOf(t.Collisions))
							{
								isJumping2 = true;
							}
						}
					}
				}
			}
			else
			{
				if (movementType != MovementType.BOUNCE && movementType != MovementType.BOSSBOUNCE)
				{
					SetAnimation("IDLE" + Level);
				}
			}

			if (movementType == MovementType.BOUNCE || movementType == MovementType.BOSSBOUNCE)
			{
				isJumping2 = true;
			}

			if (isJumping2)
			{
				JumpDelayTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

				if (JumpDelayTimer > 0)
				{
					isJumping = true;
				}
				if (JumpDelayTimer <= 0)
				{
					isJumping = false;
				}
				if (JumpDelayTimer < -200)
				{
					isJumping2 = false;
					JumpDelayTimer = 500;
				}
			}

			ApplyPhysics(gameTime);
		}

		protected override void HandleHealth()
		{
			if (MainHP < 0)
			{
				MainHP = 0;
			}
			if (MainHP > MaxHP)
			{
				MainHP = MaxHP;
			}

			if (HP <= 0)
			{
				isDead = true;
			}

			if (movementType == MovementType.BOSSHEAD)
			{
				if (HP <= 27 && HP > 18)
				{
					SetAnimation("IDLE1");
				}
				else if (HP <= 18 && HP > 9)
				{
					SetAnimation("IDLE2");
				}
				else if (HP <= 9)
				{
					SetAnimation("IDLE3");
				}
			}
		}
	}
}
