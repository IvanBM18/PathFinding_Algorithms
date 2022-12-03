using System.Collections.Generic;
using System;
using System.Drawing;

namespace P2_Laberinto{

	public class PriorityQueue{
		List<Node> queue;
		int end;
		public PriorityQueue(){
			queue = new List<Node>();
			end = -1;
		}
		
		public Node this[int i]{
			get {return queue[i]; }
			set {queue[i] = value; }
		}
		
		//Cuidado al insertar
		public void insertData(Node e){//Dar indice del fin de la lista de proridad
			if(end <= -1){ //Inserta vacio
				queue.Add(e);
				end++;
			}else{ //Insertado en otra parte
				int index = ++end;
				queue.Insert(index,e);
				Node padre = getFather(e);
				Node aux;
				int pIndex = findIndex(padre);
				while(queue[index].heuristic < queue[pIndex].heuristic){
					aux = padre;
					queue[pIndex] = e;
					queue[index] = aux;
					index = pIndex;
					padre = getFather(e);
					pIndex = findIndex(padre);
				}
			}
			
		}
		
		public void deleteFirst(){
			Node aux = queue[end];
			queue[0] = aux;
			queue.RemoveAt(end);
			end--;
			int son = getLowestSon(aux);
			if (son != -1) {
				Node swap;
				int index = 0;
				while (aux.heuristic > queue[son].heuristic ){
					swap = queue[son];
					queue[son] = aux;
					queue[index] = swap;
					index = son;
					son = getLowestSon(queue[index]);
					if(son == -1)
						return;
				}
			}
			
		}
		
		public Node getFather(Node e){
			int index = findIndex(e);
			if(index != -1){
				return queue[(index-1)/2];
			}else{
				return null;
			}
		}
		
		public int End {
			get { return end; }
		}
		
		public int Count{
			get{ return queue.Count;}
		}
		
		public int getLowestSon(Node e){
			if(!isLeaf(e)){
				int index = findIndex(e);
				int right = 2*index+2;
				int left = 2*index+1;
				if(right == -1 && left != -1){
					return left;
				}else if(right != -1 && left == -1){
					return right;
				}else if(queue[right].heuristic < queue[left].heuristic){
					return right;
				}else{
					return left;
				}
			}else{
				return -1;
			}
		}
		
		public bool isLeaf(Node e){
			int index = findIndex(e);
			if(2*index + 1 < end){
				return false;
			}else if(2*index + 2 < end){
				return false;
			}else{
				return true;
			}
		}
		
		public int findIndex(Node e){
			for(int i = 0; i < queue.Count;i++){
				if(queue[i].p == e.p)
					return i;
			}
			return -1;
		}
		
		public Node getMin(){
			if(queue.Count == 1){
				end--;
				return queue[0];
			}
			
			Node root = queue[0];
			queue[0] = queue[end-1];
			queue.RemoveAt(end);
			end--;
			minHeapify(0);
			
			return root;
				
		}
		
//		Reorder tree from a given index
		public void minHeapify(int index){
			int l = 2*index+1;
			int r = 2*index+2;
			
			int smallest = index;
			if(l < end && queue[l].heuristic < queue[smallest].heuristic){
				smallest = l;
			}
			if(r < end && queue[r].heuristic < queue[smallest].heuristic){
				smallest = r;
			}
			
			if(smallest != index){
//				Swap
				Node aux = queue[index];
				queue[index] = queue[smallest];
				queue[smallest] = aux;
				minHeapify(smallest);
			
			}
		}
		
		public void unionList(List<Node> l){
			foreach (Node e in l) {
				insertData(e);
			}
		}
	}
}
