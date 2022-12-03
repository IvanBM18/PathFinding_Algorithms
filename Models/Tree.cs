using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;

namespace P2_Laberinto
{
	public class Node {
		enum movements{N, NE, E, SE, S, SO, O, NO}
		public Point p {get; set;}
		public Node[] children {get;set;} //Each Node can have up to 8 Children, N, NE, E,
		public Node parent {get;set;}
		public double heuristic {get;set;}
		public double cost {get;set;}
		public double function {get;set;}
		
		public Node(){
			heuristic = -1;
			cost = 0;
			function = -1;
			
		}
//		Change to void?
		public double getHeuristic(Point referenceP){
			double dx = Math.Abs(p.X - referenceP.X);
			double dy = Math.Abs(p.Y - referenceP.Y);
			
			if(dx < dy)
				heuristic = (dx+dy) + (Math.Sqrt(2) - 2) * dx;
			else
				heuristic = (dx+dy) + (Math.Sqrt(2) - 2) * dy;
//			heuristic = Math.Sqrt(Math.Pow(p.X - referenceP.X, 2) + Math.Pow(p.Y - referenceP.Y, 2));
			return heuristic;
		}
		
		public double updateFunction(double c){
			cost = c;
			function = c + heuristic;
			return function;			
		}
		
//		public int CompareTo(object obj){
//			if(obj == null) return 1;
//			var otherNode = obj as Node;
//			return heuristic.CompareTo(otherNode.heuristic);
//		}
		
		public Point moveNode(int movement){
			if(movement == (int)movements.N){
				return new Point(p.X,p.Y-1);
			}else if(movement == (int)movements.NE){
				return new Point(p.X+1,p.Y-1);
			}else if(movement == (int)movements.E){
				return new Point(p.X+1,p.Y);
			}else if(movement == (int)movements.SE){
				return new Point(p.X+1,p.Y+1);
			}else if(movement == (int)movements.S){
				return new Point(p.X,p.Y+1);
			}else if(movement == (int)movements.SO){
				return new Point(p.X-1,p.Y+1);
			}else if(movement == (int)movements.O){
				return new Point(p.X-1,p.Y);
			}else if(movement == (int)movements.NO){
				return new Point(p.X-1,p.Y-1);
			}
			return new Point(-1,-1);
		}
		
		public void expand(int depth, Bitmap bmp){
			children= new Node[8];
			if(depth <= 0)
				return;
			
			for (int i = 0; i < 8; i++) {
				if(children[i] != null)
					continue;
				children[i] = new Node();
				Point newP = moveNode(i);
				if(isBlack(bmp.GetPixel(newP.X,newP.Y))){
					children[i] = null;
					continue;
				}
				children[i].p = newP;
				children[i].parent = this;
				if(depth-1 > 0) {
					children[i].expand(depth-1,bmp);
				}
				
			}
		}
		
		bool isBlack(Color c){
			if(c.R > 10)
				return false;
			if(c.G > 10)
				return false;
		  	if(c.B > 10)
				return false;
		  	return true;
		}
		
	}
//	Check if its useful
	public class Tree{
		public Node root{get;set;}
		
		public HashSet<Point> visited{get;set;}
		SortedSet<Node> frontier;
		
		public Tree(Node r){
			root = r;
			frontier = new SortedSet<Node>();
			
			
			
		}
		
	}
	
	
}
