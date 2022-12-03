// raiz(x2-x1)**2 + (y2-y1)**2)
using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace P2_Laberinto
{
	public partial class MainForm : Form
	{
		#region ImgVariables
		Bitmap bmp;
		Bitmap bmpAnimation;
		BmpEditor editor;
		Color visitedC = Color.FromArgb(50, 130, 246);
		Color openC = Color.FromArgb(255,242,0);
		#endregion
		
		#region Flags
		bool imgSelected;
		#endregion
		
		#region AlgorithmVariables
		HashSet<Point> visited;
		List<Point> Path;
//		DFS
		List<Point> frontierList;
//		BFS
		Queue<Point> frontierQueue;
//		BF 
		Tree t; //?
		PriorityQueue openQ;
		
//		General
		Point startingPoint, finishPoint;
		enum algorithm{ DFS , BFS, BEST, A_STAR}
		#endregion
		
		public MainForm()
		{
			InitializeComponent();
			imgSelected = false;
		}
		
		#region ButtonEvents
		void btnOpenImageClick(object sender, EventArgs e)
		{
			openImgDialog.ShowDialog();
			if(openImgDialog.FileName != "openImgDialog" && openImgDialog.FileName != null){
				bmp = new Bitmap(openImgDialog.FileName);
				bmpAnimation = new Bitmap(openImgDialog.FileName);
				
				pictureBox.BackgroundImage = bmp;
				pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
				pictureBox.Image = bmpAnimation;
				imgSelected = true;
				startingPoint = getStartingPoint();
				editor = new BmpEditor(bmpAnimation);
				bmpAnimation.SetPixel(startingPoint.X,startingPoint.Y,visitedC);
              	pictureBox.Refresh();
				
			}
		}
		
		void ButtonRestartClick(object sender, EventArgs e){
			bmpAnimation = new Bitmap(openImgDialog.FileName);
			bmp = new Bitmap(openImgDialog.FileName);
			pictureBox.BackgroundImage = bmp;
			pictureBox.Image = bmpAnimation;
			pictureBox.Refresh();
		}
		
		void GroupBox1Enter(object sender, EventArgs e)
		{
			return;
		}
		
		void BtnDFSIClick(object sender, EventArgs e)
		{
			if(!imgSelected)
				return;
			if(startingPoint.X == -1  && startingPoint.Y == -1)
				return;
//			Agregar Hijos (Izquierda a derecha), luego hijos del nodo de hasta arriba, algo asi como PreOrder
			frontierList = new List<Point>();
			editor.setBitMap(bmpAnimation);
			Point actualP;
			
			frontierList.Add(startingPoint);
			while (frontierList.Count >= 1) {
				actualP = frontierList[0];
				
//				Mark actual Point as Visited
				editor.drawPoint(actualP,visitedC);
				pictureBox.Refresh();
				
//				If actualP is End
				if(isEnd(actualP))
					return;
				
//				Adding childs to frontier
				expandFrontier(actualP,(int)algorithm.DFS);
				frontierList.RemoveAt(0);
			}
		}
		
		void ButtonBFSClick(object sender, EventArgs e)
		{
			if(!imgSelected)
				return;
			if(startingPoint.X == -1  && startingPoint.Y == -1)
				return;
			frontierQueue = new Queue<Point>();
			visited = new HashSet<Point>();
			editor.setBitMap(bmpAnimation);
			Point actualP;
			
			frontierQueue.Enqueue(startingPoint);
			visited.Add(startingPoint);
			while (frontierQueue.Count >= 1) {
				actualP = frontierQueue.Dequeue();
				
//				Mark actual Point as Visited
				editor.drawPoint(actualP,visitedC);
				pictureBox.Refresh();
				
//				If actualP is End
				if(isEnd(actualP))
					return;
				
//				Adding childs to frontier
				expandFrontier(actualP,(int)algorithm.BFS);
			}
		}
		
		void ButtonBetterFirstClick(object sender, EventArgs e){
			openQ = new PriorityQueue();
			visited = new HashSet<Point>();
			finishPoint = getFinishPoint();
			
			t = new Tree(new Node());
			t.root.p = startingPoint;
			t.root.getHeuristic(finishPoint);
			openQ.insertData(t.root);
			
			BestFirst(t.root);
		}
		
		void ButtonAStarClick(object sender, EventArgs e){
			finishPoint = getFinishPoint();
			openQ = new PriorityQueue();
			visited = new HashSet<Point>();
			
			Node startingNode = new Node();
			startingNode.p = startingPoint;
			startingNode.getHeuristic(finishPoint);
			startingNode.updateFunction(0);
			
			AStar(startingNode);
		}
		
		#endregion
		
		#region recursiveFunctions
//		Open/Frontier Generated and H(n) applied to them
//		Closed/Visitd Examinated Nodes
		void BestFirst(Node startingNode){
			Node actualNode,ni;
			int cont = 10;
			visited.Add(startingPoint);
			
			while (openQ.Count > 0) {
//				Updates every 10 Iterations
				if(cont-- <= 0){
					cont = 10;
					pictureBox.Refresh();
				}
				
//				Remove Lowest Element of Opn/Frontier and place it in CloseList/Visited
				actualNode = openQ.getMin();
				bmpAnimation.SetPixel(actualNode.p.X,actualNode.p.Y,visitedC);
				
//				Expand Node		
				actualNode.expand(1,bmpAnimation);
				for(int i = 0; i < actualNode.children.Length;i++) {
					ni = actualNode.children[i];
//					Invalid Node
					if(ni == null)
						continue;
					
//					Finish Reached?
					if(isEnd(ni.p)){
						return;
					}
					ni.getHeuristic(finishPoint);
//					Hasnt been visited/Closed nor in frontier/Open
					if(!visited.Contains(ni.p) && openQ.findIndex(ni) == -1 ){
						bmpAnimation.SetPixel(ni.p.X,ni.p.Y,openC);
						visited.Add(ni.p);
						openQ.insertData(ni);
					}
				}
			}
			pictureBox.Refresh();			
		}
		
		void AStar(Node startNode){
			Node n,ni;
			int cont = 15;
			int index;
			
//			Adding to Open/List
			openQ.insertData(startNode);
			
//			AStar Search
			while (openQ.Count > 0) {
//				Update pictureBox
				if(cont-- <= 0){
					cont = 30;
					pictureBox.Refresh();
				}
				
				n = openQ.getMin();
				bmpAnimation.SetPixel(n.p.X,n.p.Y,visitedC);
				if(isEnd(n.p))
					return;
//				expand node
				n.expand(1,bmp);
				for (int i = 0; i < n.children.Length; i++) {
					ni = n.children[i];
					if(ni == null)
						continue;

//					Compute cost and heuristic
					ni.getHeuristic(finishPoint);
					ni.updateFunction(n.cost);
					
					index = openQ.findIndex(ni);
//					If in Frontier/OpenQ
					if(index != -1){
//						Update node if better function
						if(openQ[index].function > ni.function){
							openQ[index] = ni;
						}
					}
//					If not in Visited/Closed
					if(!visited.Contains(ni.p)){
					   openQ.insertData(ni);
					   visited.Add(ni.p);
					   bmpAnimation.SetPixel(ni.p.X,ni.p.Y,openC);
				   }
				}
//				Add node to visited/Closed
				visited.Add(n.p);
			}
			pictureBox.Refresh();
			
		}
		
		#endregion
		
		Point getStartingPoint(){
			Color cI;
			for(int x =0; x < bmp.Width; x++){
				for(int y=0; y < bmp.Height; y++){
					cI = bmp.GetPixel(x,y);
					if(isRed(cI)){
					   	return new Point(x,y);
				   }
				}
			}
			return new Point(-1,-1);
		}
		
		Point getFinishPoint(){
			Color cI;
			for(int y =0; y < bmp.Height; y++){
				for(int x=0; x < bmp.Width; x++){
					cI = bmp.GetPixel(x,y);
					if(isRed(cI)){
					   	return new Point(x,y);
				   }
				}
			}
			return new Point(-1,-1);
		}
		
//		For use in DFS and BFS
		void expandFrontier(Point p,int type){
			int x = p.X;
			int y = p.Y;
			Point newP;
				
//			Left
			if(!isBlack(bmp.GetPixel(x-2,y)) && !isBlue(bmpAnimation.GetPixel(x-2,y))){
				newP = new Point(x-2,y);
				if(type == (int)algorithm.DFS){
					frontierList.Insert(1,newP);
				}else if (type == (int)algorithm.BFS){
					if(!visited.Contains(newP)){
						frontierQueue.Enqueue(newP);
						visited.Add(newP);
					}
				}
			}
//			Down
			if(!isBlack(bmp.GetPixel(x,y+1)) && !isBlue(bmpAnimation.GetPixel(x,y+1))){
				newP = new Point(x,y+1);
				if(type == (int)algorithm.DFS){
					frontierList.Insert(1,newP);
				}else if (type == (int)algorithm.BFS){
					if(!visited.Contains(newP)){
						frontierQueue.Enqueue(newP);
						visited.Add(newP);
					}
				}
			}
//			Right
			if(!isBlack(bmp.GetPixel(x+2,y)) && !isBlue(bmpAnimation.GetPixel(x+2,y))){
				newP = new Point(x+2,y);
				if(type == (int)algorithm.DFS){
					frontierList.Insert(1,newP);
				}else if (type == (int)algorithm.BFS){
					if(!visited.Contains(newP)){
						frontierQueue.Enqueue(newP);
						visited.Add(newP);
					}
				}
			}
//			Up
			if(!isBlack(bmp.GetPixel(x,y-1)) && !isBlue(bmpAnimation.GetPixel(x,y-1))){
				newP = new Point(x,y-1);
				if(type == (int)algorithm.DFS){
					frontierList.Insert(1,newP);
				}else if (type == (int)algorithm.BFS){
					if(!visited.Contains(newP)){
						frontierQueue.Enqueue(newP);
						visited.Add(newP);
					}
				}
			}
			
		}
		
		
		#region PointValidation
		bool isEnd(Point p){
			Color c = bmp.GetPixel(p.X,p.Y);
			if(!isRed(c))
				return false;
			if(Math.Abs(startingPoint.X - p.X) < 40)
				return false;
			if(Math.Abs(startingPoint.Y - p.Y) < 40)
				return false;
			return true;
		}
		
		bool isRed(Color c) {
			if(isWhite(c))
			   return false;
			if(isBlack(c))
				return false;
			if(c.R < 200)
				return false;
			return true;
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
		
		bool isWhite(Color c){
			if(c.R < 190)
				return false;
			if(c.G < 190)
				return false;
		  	if(c.B < 190)
				return false;
		  	return 	true;
		}
		
		bool isBlue(Color c){
			if(c.R != 50)
				return false;
			if(c.G != 130)
				return false;
			if(c.B != 246)
				return false;
			return true;
		}
#endregion
		
		
		
	}
}
