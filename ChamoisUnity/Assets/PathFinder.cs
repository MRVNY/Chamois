using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PathFinder : MonoBehaviour
{
    
    private Pathfinding pathfinding;

    // Start is called before the first frame update
    void Awake()
    {
        pathfinding = new Pathfinding(600, 600);

        for(int i = 0; i < 600; i++)
        {
            for(int j = 0; j < 600; j++)
            {
                var node = pathfinding.GetNode(i, j);
                var nodePos = pathfinding.GetGrid().GetWorldPosition(i, j);
                if(Physics2D.BoxCast(nodePos,Vector2.one, 0f, Vector2.zero, 0f, LayerMask.GetMask("Terrain")))
                {
                    node.SetIsWalkable(false);
                    // Debug.DrawLine(nodePos+Vector3.left, nodePos + Vector3.right, Color.red, 100f);
                    // Debug.DrawLine(nodePos + Vector3.up, nodePos + Vector3.down, Color.red, 100f);
                }
                // else
                // {
                //     node.SetIsWalkable(true);
                //     Debug.DrawLine(nodePos+Vector3.left, nodePos + Vector3.right, Color.green, 100f);
                //     Debug.DrawLine(nodePos + Vector3.up, nodePos + Vector3.down, Color.green, 100f);
                // }
            }
        }
        print("Finished");
    }
}
