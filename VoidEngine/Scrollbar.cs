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
	/// The Scrollbar class for VoidEngine
	/// </summary>
	public class Scrollbar : Sprite
	{
		Game myGame;

		/// <summary>
		/// Creates the Scrollbar
		/// </summary>
		/// <param name="position">The position of the sprite</param>
		/// <param name="animationSetList">The list of animation sets</param>
		/// <param name="myGame">The class of the game that this is created in</param>
		public Scrollbar(Vector2 position, Color color, List<AnimationSet> animationSetList, Game myGame)
			: base(position, color, animationSetList)
		{
			this.myGame = myGame;
			_Color = color;
			AnimationSets = animationSetList;
			Position = position;
		}
	}
}