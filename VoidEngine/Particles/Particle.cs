using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using VoidEngine.VGame;

namespace VoidEngine.Particles
{
	public class Particle : Sprite
	{
		/// <summary>
		/// Gets or sets if the particle should be deleted.
		/// <summary>
		public bool DeleteMe
		{
			get;
			protected set;
		}
		/// <summary>
		/// Gets or sets the elapsed time that the particle as been active.
		/// </summary>
		public int ElapsedTime
		{
			get;
			protected set;
		}
		/// <summary>
		/// Gets or sets the life span of the particle.
		/// </summary>
		public int LifeSpan
		{
			get;
			protected set;
		}
		/// <summary>
		/// The random number generator.
		/// </summary>
		Random random = new Random();
		/// <summary>
		/// The center of the particle.
		/// </summary>
		Vector2 PositionCenter;
		/// <summary>
		/// The diretion of the particle.
		/// </summary>
		Vector2 Direction;
		/// <summary>
		/// Gets or sets the speed of the particle.
		/// </summary>
		public float Speed
		{
			get;
			protected set;
		}

		/// <summary>
		/// Creates the particle object
		/// </summary>
		/// <param name="position">The starting position of the particle.</param>
		/// <param name="texture">The texture of the particle.</param>
		/// <param name="lifespan">The life span of the particle.</param>
		/// <param name="speed">The speed of the particle.</param>
		/// <param name="washcolor">The Color to wash the particle with.</param>
		/// <param name="angle">The angle of the particles movement.</param>
		public Particle(Vector2 position, Texture2D texture, int lifespan, int speed, Color washcolor, float angle)
			: base(position, washcolor, texture)
		{
			// Set the angle of the angle in degrees.
			angle *= (float)(Math.PI / 180);
			// Set the direction based off of the Cosine and Sine of the angle.
			Direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
			// Set the LifeSpan of the particle.
			LifeSpan = lifespan;
			// Set the color of the particle.
			Color = washcolor;
			// Set the speed of the particle.
			Speed = speed;
			// Create the animations.
			AddAnimations(texture);
		}

		/// <summary>
		/// Update the particle.
		/// </summary>
		/// <param name="gameTime">The GameTime that the game runs off of.</param>
		public override void Update(GameTime gameTime)
		{
			HandleAnimations(gameTime);
			// Update the Position of the particle.
			position += Direction * Speed;
			// Update the elapsed time of the particle.
			ElapsedTime += gameTime.ElapsedGameTime.Milliseconds;
			//ratio = 1- (elapsedTime / lifeSpan) ;
			//washColor = new Color(washColor.R, washColor.G, washColor.B, ratio);
			// If the Elapsed time is greater than the life span then delete particle.
			if (ElapsedTime >= LifeSpan)
			{
				DeleteMe = true;
			}
			// Update the center position of the particle.
			PositionCenter = new Vector2((CurrentAnimation.frameSize.X / 2), (CurrentAnimation.frameSize.Y / 2));

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			base.Draw(gameTime, spriteBatch);
		}


		protected override void AddAnimations(Texture2D texture)
		{
			AddAnimation("IDLE", texture, new Point(texture.Width, texture.Height), new Point(0, 0), new Point(0, 0), 1600, false);
			SetAnimation("IDLE");
		}
	}
}
