using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;
using Unity.VisualScripting;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Testing : MonoBehaviour
{

    [SerializeField] private CharacterPathfindingMovementHandler characterPathfinding;
    private Pathfinding pathfinding;
    private float distance;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] private Rigidbody2D enemyRB;

    private void Start()
    {

        pathfinding = new Pathfinding(80, 50);

    }

    private void Update()
    {
        distance = Vector2.Distance(enemy.transform.position, player.transform.position);
        if (distance < 25f)
        {
            Vector3 PlayerPos = player.transform.position;
            Vector3 EnemyPos = enemy.transform.position;

            pathfinding.GetGrid().GetXY(PlayerPos, out int x, out int y);
            pathfinding.GetGrid().GetXY(EnemyPos, out int X, out int Y);
            List<PathNode> path = pathfinding.FindPath(X, Y, x, y);

            if (path != null)
            {
                //try
                //{
                    //print("Path count is: "+path.Count);
                    for (int i = 0; i < path.Count; i++)
                    {
                        //print("PATH" + i + path[i]);
                        //Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green);

                        characterPathfinding.SetTargetPosition(PlayerPos);
                        //print("Player Position: " + PlayerPos);
                        

                    }
                //}
                //catch
                //{
                    //print("Caught");
                //}

            }
        }




    }


}