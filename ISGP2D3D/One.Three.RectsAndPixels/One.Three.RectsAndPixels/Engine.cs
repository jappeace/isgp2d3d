using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace One.Three.RectsAndPixels {
	// I wanted to call this one graphics but allas, it would probably confuse the teacher to much
	class Engine{

		public Color Color { get; set; }
		private bool isBufferModified = true;
		private List<VertexPositionColor> _vertex;
		private List<VertexPositionColor> VertexList{
			get{
				isBufferModified = true;
				return _vertex;
			}
			set{
				_vertex = value;
			}
		}

		public Engine(){
			VertexList = new List<VertexPositionColor>();
		}
		public int PrimitiveCount { get; set; }
		private VertexBuffer vertexBuffer;

		// creates a VertexList buffer based on what was drawn, has a caching mechanism inside it
		public VertexBuffer CreateVertexBuffer(GraphicsDevice forDevice){
			if(!isBufferModified){
				return vertexBuffer;
			}
			vertexBuffer = new VertexBuffer(forDevice, typeof(VertexPositionColor), VertexList.ToArray().Length, BufferUsage.None);
			vertexBuffer.SetData<VertexPositionColor>(VertexList.ToArray());
			isBufferModified = false;
			return vertexBuffer;
		}
		public void Rectangle(Vector2 position, Vector2 size, Color color, bool isOpen = false){
			Color = color;
			if(!isOpen){
				FillRect(position, size);
			}
			else{
				DrawRect(position, size);
			}

		}

		public void FillRect(Vector2 position, Vector2 size){
			PrimitiveCount += 6;
			VertexList.Add(new VertexPositionColor(new Vector3(position, 0), Color));
			VertexList.Add(new VertexPositionColor(new Vector3(position + size, 0), Color));
			VertexList.Add(new VertexPositionColor(new Vector3(position + size * new Vector2(0,1), 0), Color));
			VertexList.Add(new VertexPositionColor(new Vector3(position, 0), Color));
			VertexList.Add(new VertexPositionColor(new Vector3(position + size * new Vector2(1,0), 0), Color));
			VertexList.Add(new VertexPositionColor(new Vector3(position + size, 0), Color));
		}

		public void DrawRect(Vector2 position, Vector2 size){

			FillRect(position, size * new Vector2(1,0) + new Vector2(0,1));
			FillRect(position, size * new Vector2(0,1) + new Vector2(1,0));

			FillRect(position + size * new Vector2(1,0), size * new Vector2(0,1) + new Vector2(1,0));
			FillRect(position + size * new Vector2(0,1), size * new Vector2(1,0) + new Vector2(0,1));
		}
	}
}
