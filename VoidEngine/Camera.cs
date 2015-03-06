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
	public class Camera
	{
		const float zoomUpperLimit = 1.5f;
		const float zoomLowerLimit = 0.5f;

		float zoom;
		Matrix transform;
		Vector2 position;
		Vector2 overallPlayerPosition;
		float rotation;
		public Vector2 viewportSize;
		int worldWidth;
		int worldHeight;
		Vector2 screenCenter;
		Vector2 origin;

		public Camera(Viewport viewport, int worldWidth, int worldHeight, float initialZoom)
		{
			zoom = initialZoom;
			rotation = 0.0f;
			position = Vector2.Zero;
			overallPlayerPosition = Vector2.Zero;
			viewportSize = new Vector2(viewport.Width, viewport.Height);
			this.worldWidth = worldWidth;
			this.worldHeight = worldHeight;
			screenCenter = new Vector2(viewport.Width / 2, viewport.Height / 2);
			origin = screenCenter / zoom;
		}

		public float Zoom
		{
			get
			{
				return zoom;
			}
			set
			{
				zoom = value;

				if (zoom < zoomLowerLimit)
				{
					zoom = zoomLowerLimit;
				}
				if (zoom > zoomUpperLimit)
				{
					zoom = zoomUpperLimit;
				}
			}
		}

		public float Rotation
		{
			get
			{
				return rotation;
			}
			set
			{
				rotation = value;
			}
		}

		public Vector2 Size
		{
			get
			{
				return new Vector2(worldWidth, worldHeight);
			}
		}

		public void Move(Vector2 amount)
		{
			position += amount;
		}

		public Vector2 OverallPlayerPosition
		{
			get
			{
				return overallPlayerPosition;
			}
			set
			{
				float leftBarrier = (float)viewportSize.X * -1f / zoom;
				float rightBarrier = worldWidth - (float)viewportSize.X * -1f / zoom;
				float topBarrier = worldHeight - (float)viewportSize.Y * -1f / zoom;
				float bottomBarrier = (float)viewportSize.Y * -1f / zoom;
				overallPlayerPosition = value;
				if (overallPlayerPosition.X < leftBarrier)
				{
					overallPlayerPosition.X = leftBarrier;
				}
				if (overallPlayerPosition.X > rightBarrier)
				{
					overallPlayerPosition.X = rightBarrier;
				}
				if (overallPlayerPosition.Y > topBarrier)
				{
					overallPlayerPosition.Y = topBarrier;
				}
				if (overallPlayerPosition.Y < bottomBarrier)
				{
					overallPlayerPosition.Y = bottomBarrier;
				}
			}
		}

		public Vector2 Position
		{
			get
			{
				return position;
			}
			set
			{
				float leftBarrier = (float)viewportSize.X * .5f / zoom;
				float rightBarrier = worldWidth - (float)viewportSize.X * .5f / zoom;
				float topBarrier = worldHeight - (float)viewportSize.Y * .5f / zoom;
				float bottomBarrier = (float)viewportSize.Y * .5f / zoom;
				position = value;
				if (position.X < leftBarrier)
				{
					position.X = leftBarrier;
				}
				if (position.X > rightBarrier)
				{
					position.X = rightBarrier;
				}
				if (position.Y > topBarrier)
				{
					position.Y = topBarrier;
				}
				if (position.Y < bottomBarrier)
				{
					position.Y = bottomBarrier;
				}
			}
		}

		public Matrix GetTransformation()
		{
			transform = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) * Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) * Matrix.CreateTranslation(new Vector3(viewportSize.X * 0.5f, viewportSize.Y * 0.5f, 0));

			return transform;
		}

		/// <summary>
		/// Determines whether the target is in view given the specified position.
		/// This can be used to increase performance by not drawing objects
		/// directly in the viewport
		/// </summary>
		/// <param name="position">The position.</param>
		/// <param name="texture">The texture.</param>
		/// <returns>
		///     <c>true</c> if [is in view] [the specified position]; otherwise, <c>false</c>.
		/// </returns>
		public bool IsInView(Vector2 position, Vector2 textureSize)
		{
			// If the object is not within the horizontal bounds of the screen

			if ((position.X + textureSize.X) < (this.position.X - origin.X) || (position.X) > (this.position.X + origin.X))
			{
				return false;
			}

			// If the object is not within the vertical bounds of the screen
			if ((position.Y + textureSize.Y) < (this.position.Y - origin.Y) || (position.Y) > (this.position.Y + origin.Y))
			{
				return false;
			}

			// In View
			return true;
		}

	}
}
