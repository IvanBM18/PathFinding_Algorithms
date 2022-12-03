using System;
using System.Collections.Generic;
using System.Drawing;

namespace P2_Laberinto
{
	public class BmpEditor
	{
		Bitmap bmp;
		public BmpEditor(Bitmap bmp){
			this.bmp = bmp;
		}
		
		public void setBitMap(Bitmap bmp){
			this.bmp = bmp;
		}
		
		public void drawCircle(Point p, double r,Color c){
			if(bmp == null)
				return;
			Graphics graphic = Graphics.FromImage(bmp);
			Brush cBrush = new SolidBrush(c);
			
			graphic.FillEllipse(cBrush,(float)(p.X-r),(float)(p.Y-r),(float)r*2,(float)r*2);
		}
		
		public void drawPoint(Point p, Color c){
			if(bmp == null)
				return;
			try {
				bmp.SetPixel(p.X,p.Y,c);
				bmp.SetPixel(p.X+1,p.Y,c);
				bmp.SetPixel(p.X-1,p.Y,c);
			} catch (Exception) {
				return;
			}			
		}
		
		
	}
}
