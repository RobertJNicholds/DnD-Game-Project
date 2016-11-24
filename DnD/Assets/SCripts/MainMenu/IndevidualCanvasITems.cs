using UnityEngine;
using System.Collections;

public class IndevidualCanvasITems : MonoBehaviour {

	public void GenerateGridWithDimentions(string mapType, int x, int y)
    {
        Debug.Log(mapType + " " + x + y);

        for (int i = (x/2)*-1; i < x/2; ++i)
        {
            for (int j = (y/2)*-1; j < y/2; ++j)
            {
               GameObject quad = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Quad), new Vector3(i,j+0.5f, -5), Quaternion.identity) as GameObject;
                quad.GetComponent<MeshRenderer>().material = Resources.Load("red") as Material;
            }
        }
    }
}
