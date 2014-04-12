using System;

namespace One.Three.RectsAndPixels {
#if WINDOWS || XBOX
	static class Starter
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args){
			new GameController().Run();
		}
	}
#endif
}

