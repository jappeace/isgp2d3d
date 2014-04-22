using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace One.Eight
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game : Microsoft.Xna.Framework.Game
	{
		const int CircleRadius = 10;
		const int CirclePoints = 18;

		GraphicsDeviceManager graphics;
		VertexPositionColor[] vertex;
		VertexBuffer vb;
		BasicEffect effect;
		bool canDraw = false;

		public Game()
		{
			graphics = new GraphicsDeviceManager(this);
			IsMouseVisible = true;
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
			effect = new BasicEffect(GraphicsDevice);
			base.Initialize();
		}

		private void CircleInitialize(int mouseX, int mouseY)
		{
			vertex = new VertexPositionColor[CirclePoints + 1];
			for (int i = 0; i < CirclePoints + 1; i++)
			{
				double radian = 2 * Math.PI / CirclePoints * i;
				int x = (int)(Math.Cos(radian) * CircleRadius)
					+ mouseX;
				int y = (int)(Math.Sin(radian) * CircleRadius)
					+ mouseY;
				vertex[i] = new VertexPositionColor(new Vector3(x, y, 0), Color.Red);
			}

			vb = new VertexBuffer(
				GraphicsDevice,
				typeof(VertexPositionColor),
				vertex.Length,
				BufferUsage.None
			);

			vb.SetData(vertex);
			GraphicsDevice.SetVertexBuffer(vb);
			canDraw = true;
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
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

			if (Mouse.GetState().LeftButton == ButtonState.Pressed)
			{
				CircleInitialize(Mouse.GetState().X, Mouse.GetState().Y);
			}

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.White);
			#region Transform
			effect.VertexColorEnabled = true;
			effect.World = Matrix.Identity;
			effect.View = new Matrix(
				1.0f, 0.0f, 0.0f, 0.0f,
				0.0f, 1.0f, 0.0f, 0.0f,
				0.0f, 0.0f, -1.0f, 0.0f,
				0.0f, 0.0f, 0.0f, 1.0f
			);
			effect.Projection = Matrix.CreateOrthographicOffCenter(
				0f, Window.ClientBounds.Width,
				Window.ClientBounds.Height, 0f,
				-10f, 10f
			);
			#endregion
			if (canDraw)
			{
				effect.CurrentTechnique.Passes[0].Apply();
				GraphicsDevice.DrawPrimitives(PrimitiveType.LineStrip, 0, CirclePoints);
			}
			base.Draw(gameTime);
		}
	}
}
