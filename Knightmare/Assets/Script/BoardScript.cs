using UnityEngine;
using System.Collections;

public class BoardScript : MonoBehaviour {

	public class BoardPartInfo 
	{
		public Vector3 Pos;
		public bool ChessOnPiece;
		BoardPartInfo()
		{
			ChessOnPiece = false;
		}
	}
	BoardPartInfo[][] theBoardPart;

	// Use this for initialization
	void Start () {
		theBoardPart = new BoardPartInfo[8][8];

		for (float a = 0.5, i = 0; i < 8; i++, a++) {
			for(float b = 0.5, j = 0; j < 8; j++, b++) {
				theBoardPart[i][j].Pos.x = a;
				theBoardPart[i][j].Pos.y = b;
				}
			}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
