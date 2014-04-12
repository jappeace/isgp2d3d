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
		VertexBuffer vb;
		IndexBuffer ib;
		BasicEffect effect;
		float Height {get { return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; }}
		float Width {get { return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; }}
		float rot;
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
			const int MAX = 8;
			VertexPositionColor[] vertex = new VertexPositionColor[MAX]
			{
				new VertexPositionColor( new Vector3(-1,  1, -1), col),
				new VertexPositionColor( new Vector3( 1,  1, -1), col),
				new VertexPositionColor( new Vector3(-1, -1, -1), col),
				new VertexPositionColor( new Vector3( 1, -1, -1), col),
				new VertexPositionColor( new Vector3(-1,  1,  1), col),
				new VertexPositionColor( new Vector3( 1,  1,  1), col),
				new VertexPositionColor( new Vector3( 1, -1,  1), col),
				new VertexPositionColor( new Vector3(-1, -1,  1), col)
			};

			vb = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), MAX, BufferUsage.None);
			vb.SetData<VertexPositionColor>(vertex);

			short[] index = new short[36] 
			{ 
				0,1,5,  // 1
				0,5,4,  // 2
				0,2,1,  // 3
				1,2,3,  // 4
				0,4,2,  // 5
				4,7,2,  // 6
				2,7,3,  // 7
				3,7,6,  // 8
				4,5,6,  // 9
				4,6,7,  //10
				1,6,5,  //11
				1,3,6   //12
			};

			ib = new IndexBuffer(GraphicsDevice, typeof(short), 36 /*3 x 12*/, BufferUsage.None);
			ib.SetData<short>(index);

			GraphicsDevice.SetVertexBuffer(vb);

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
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime) {

			GraphicsDevice.Clear(Color.White);
			GraphicsDevice.Indices = ib; //connect to indexbuffer

			effect.CurrentTechnique.Passes[0].Apply();

			if (enable3D){
				effect.VertexColorEnabled = true;
				effect.World = Matrix.Identity;
				effect.World = Matrix.CreateRotationY(MathHelper.ToRadians(rot++));
				if (rot > 360) rot = 0;
				effect.View = Matrix.CreateLookAt(new Vector3(3, 3, 3), Vector3.Zero, Vector3.Up);
				effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 1.3f, 0.1f, 10.0f);
			}else{
				effect.VertexColorEnabled = true;
				effect.World = Matrix.CreateRotationY(MathHelper.ToRadians(rot++));
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
