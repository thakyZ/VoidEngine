using Microsoft.Xna.Framework;
using System.Collections.Generic;
using VoidEngine.VGame;

namespace VoidEngine.VGUI
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
			Color = color;
			AnimationSets = animationSetList;
			this.position = position;
		}
	}
}