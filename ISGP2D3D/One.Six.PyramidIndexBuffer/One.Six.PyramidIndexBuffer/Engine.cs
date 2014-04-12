using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace One.Six.PyramidIndexBuffer {
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Engine : Microsoft.Xna.Framework.Game {
		GraphicsDeviceManager graphics;
		VertexBuffer vectorBuffer;
		IndexBuffer indexBuffer;
		BasicEffect effect;
		float Height {get { return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; }}
		float Width {get { return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; }}
		float rotation;
		bool enable3D;
		public Engine() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize() {
            effect = new BasicEffect(GraphicsDevice);

			Color col = Color.DarkRed;
			const int MAX = 5;
			VertexPositionColor[] vertex = new VertexPositionColor[MAX]
			{
				new VertexPositionColor( new Vector3(0,  1, 0), col),
				new VertexPositionColor( new Vector3(-1, -1, -1), col),
				new VertexPositionColor( new Vector3( 1, -1, -1), col),
				new VertexPositionColor( new Vector3( 1, -1,  1), col),
				new VertexPositionColor( new Vector3(-1, -1,  1), col)
			};

			vectorBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), MAX, BufferUsage.None);
			vectorBuffer.SetData<VertexPositionColor>(vertex);

			const int indexbufferSize = 18;
			short[] index = new short[indexbufferSize] 
			{ 
				0,1,2,  // 4
				0,4,1,  // 3
				1,4,2,  // 4
				2,4,3,  // 8
				0,3,4,  //10
				0,2,3   //12
			};

			indexBuffer = new IndexBuffer(GraphicsDevice, typeof(short), indexbufferSize, BufferUsage.None);
			indexBuffer.SetData<short>(index);

			GraphicsDevice.SetVertexBuffer(vectorBuffer);

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent() {}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent() {}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime) {
			// Allows the game to exit

			KeyboardState keyboard = Keyboard.GetState();

			RasterizerState rstate = new RasterizerState();
			rstate.CullMode = CullMode.CullClockwiseFace;
			rstate.FillMode = FillMode.Solid;
			GraphicsDevice.RasterizerState = rstate;

			if(keyboard.IsKeyDown(Keys.W)) {
				RasterizerState rs = new RasterizerState();
				rs.FillMode = FillMode.WireFrame;
				GraphicsDevice.RasterizerState = rs;
			}

			if(keyboard.IsKeyDown(Keys.F1)){
				enable3D = false;
			}
			if(keyboard.IsKeyDown(Keys.F2)){
				enable3D = true;
			}
			if(keyboard.IsKeyDown(Keys.Down)){
				
			}
			if(keyboard.IsKeyDown(Keys.Up)){
				
			}
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime) {

			GraphicsDevice.Clear(Color.White);
			GraphicsDevice.Indices = indexBuffer; //connect to indexbuffer

			effect.CurrentTechnique.Passes[0].Apply();

			if (enable3D){
				effect.VertexColorEnabled = true;
				effect.World = Matrix.Identity;
				effect.World = Matrix.CreateRotationY(MathHelper.ToRadians(rotation++));
				if (rotation > 360) rotation = 0;
				effect.View = Matrix.CreateLookAt(new Vector3(3, 3, 3), Vector3.Zero, Vector3.Up);
				effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 1.3f, 0.1f, 10.0f);
			}else{
				effect.VertexColorEnabled = true;
				effect.World = Matrix.CreateRotationY(MathHelper.ToRadians(rotation++));
				effect.View = new Matrix(
					200.0f, 0.0f, 0.0f, 0.0f,
					0.0f, 200.0f, 0.0f, 0.0f,
					0.0f, 0.0f, -1.0f, 0.0f,
					0.0f, 0.0f, 0.0f, 1.0f
				);
				effect.Projection = Matrix.CreateOrthographicOffCenter(
					  -Width, Width,
					  Height, -Height,
					-10f, 10f
				);
			}

			GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 8, 0, 12);
			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}
