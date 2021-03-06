using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace One.One
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		int DisplayModeCount = GraphicsAdapter.DefaultAdapter.SupportedDisplayModes.Count();
		int DisplayModeIndex;

		public Game()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			var picker = new ResolutionPicker();
			if (picker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				DisplayModeIndex = GraphicsAdapter.DefaultAdapter.SupportedDisplayModes.ToList()
					.IndexOf(picker.SelectedDisplayMode);

				// Bigger mouse means lower resolution. Useful for debugging.
				IsMouseVisible = true;

				// Set fullscreen with requested resolution.
				graphics.IsFullScreen = true;
				graphics.PreferredBackBufferFormat = picker.SelectedDisplayMode.Format;
				graphics.PreferredBackBufferWidth = picker.SelectedDisplayMode.Width;
				graphics.PreferredBackBufferHeight = picker.SelectedDisplayMode.Height;

				// Apply changes.
				graphics.ApplyChanges();
			}
			else
			{
				// No resolution chosen. Exit.
				Exit();
			}

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				this.Exit();
			}

			if (Keyboard.GetState().IsKeyDown(Keys.F1))
			{
				graphics.IsFullScreen = false;
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.F2))
			{
				graphics.IsFullScreen = true;
			}

			if (Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				NextDisplayMode();
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				PreviousDisplayMode();
			}

			graphics.ApplyChanges();

			base.Update(gameTime);
		}

		/// <summary>
		/// Switch to the next displaymode. Does nothing if the last displaymode
		/// is selected.
		/// </summary>
		private void NextDisplayMode()
		{
			if (DisplayModeIndex + 1 < DisplayModeCount)
			{
				DisplayModeIndex++;
				UpdateDisplayMode();
			}
		}

		/// <summary>
		/// Switch to the previous displaymode. Does nothing if the first
		/// displaymode is selected.
		/// </summary>
		private void PreviousDisplayMode()
		{
			if (DisplayModeIndex > 0)
			{
				DisplayModeIndex--;
				UpdateDisplayMode();
			}
		}

		/// <summary>
		/// Changes the displaymode to the currently selected one.
		/// </summary>
		private void UpdateDisplayMode()
		{
			var displayMode = GraphicsAdapter.DefaultAdapter.SupportedDisplayModes
				.ElementAt(DisplayModeIndex);

			graphics.PreferredBackBufferFormat = displayMode.Format;
			graphics.PreferredBackBufferWidth = displayMode.Width;
			graphics.PreferredBackBufferHeight = displayMode.Height;

			graphics.ApplyChanges();
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}
