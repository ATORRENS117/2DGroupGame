using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPathfindingMovementHandler : MonoBehaviour
{
<<<<<<< Updated upstream
    public float speed = 1f; //for some reason 0.01f is the best speed - we can leave it at 1 and divide by 100?
    private int currentPathIndex;
    public List<Vector3> pathVectorList;
    private int i;
=======
    private const float speed = 6f;
    private int currentPathIndex;
    private List<Vector3> pathVectorList;

    [SerializeField] GameObject angelBarrierScript;

    public bool resetPath = false;
>>>>>>> Stashed changes

    private bool shouldMove = true;
    
    private void Start()
    {
        {
            Transform bodyTransform = transform.Find("Body");
        }
    }

    private void Update()
    {
<<<<<<< Updated upstream
        // HandleMovement();
        StartCoroutine(HandleMovement()); 

        /* if (Input.GetMouseButtonDown(0))
         {
             SetTargetPosition(UtilsClass.GetMouseWorldPosition());
         }*/


=======
        
        print("Reset Path is" + resetPath);
        if (resetPath == false)
        {
            HandleMovement();
        }
        
>>>>>>> Stashed changes
    }
    
    //Critical
    // private void HandleMovement()
    // {
    //     if (pathVectorList != null)
    //     {
    //         
    //         Vector3 targetPosition = pathVectorList[currentPathIndex];
    //         print("Target POS: " + targetPosition);
    //         print("PVL: "+pathVectorList[currentPathIndex]);
    //         if (Vector3.Distance(transform.position, targetPosition) > 1f)
    //         {
    //             Vector3 moveDir = (targetPosition - transform.position).normalized;
    //             print("targetPos is: " + targetPosition);
    //             print("transformPos is: " + transform.position);
    //             print("moveDir is: " + moveDir);
    //
    //             float distanceBefore = Vector3.Distance(transform.position, targetPosition);
    //             transform.position = transform.position + moveDir * speed * Time.deltaTime;
    //         }
    //         else
    //         {
    //             currentPathIndex++;
    //             if (currentPathIndex >= pathVectorList.Count)
    //             {
    //                 StopMoving();
    //             }
    //         }
    //
    //     }
    // }
    
    // Critical - new HandleMovement method using IEnumerator
    /// <summary>
    ///  Handles the movement of the character along the path
    ///  This method is a coroutine, so it will run over multiple frames
    ///  This is necessary because we need to wait for the character to reach the target position before moving to the next waypoint
    ///  This method will move the character to the next waypoint in the path, one waypoint at a time
    ///  The character will move towards the target position until it reaches the waypoint
    ///  Once it reaches the waypoint, it will move to the next waypoint in the path
    ///  This will continue until the character reaches the end of the path
    ///  If shouldMove is set to false, the character will stop moving
    ///  This method will also handle the speed of the character
    ///  The speed is divided by 100 to make it more manageable
    /// </summary>
    /// <returns></returns>
    private IEnumerator HandleMovement()
    {
<<<<<<< Updated upstream
        float reachDistance = 0.1f; // The distance at which the character will start moving to the next waypoint

        if (pathVectorList != null && shouldMove) // Check shouldMove here
        {
            currentPathIndex = 0;
            while (currentPathIndex < pathVectorList.Count)
=======
        if (pathVectorList != null)
        {
            
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > 1f)
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;
                float distanceBefore = Vector3.Distance(transform.position, targetPosition);
                CheckPathCancellation();
                try
                {
                    if (resetPath == true)
                    {
                        transform.position = transform.position;
                        pathVectorList = null;
                        resetPath = false;
                    }
                    else
                    {
                        transform.position = transform.position + moveDir * speed * Time.deltaTime;
                    }
                }
                catch
                {

                }
                
            }
            else
>>>>>>> Stashed changes
            {
                Vector3 targetPosition = pathVectorList[currentPathIndex];
                while (Vector3.Distance(transform.position, targetPosition) > reachDistance)
                {
                    if (!shouldMove) // Check shouldMove here
                        break;

                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, (speed/100) * Time.fixedDeltaTime);
                    yield return null; // Wait for next frame
                }
                if (!shouldMove) // Check shouldMove here
                    break;

                currentPathIndex++;

                // If we've reached the end of the path, stop moving
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                }

                yield return null; // Wait for next frame
            }
        }
    }

    private void CheckPathCancellation()
    {
        resetPath = angelBarrierScript.GetComponent<AngelBarrierBehaviour>().cancelChase;
        
    }

    private void StopMoving()
    {
        shouldMove = false;
        //pathVectorList = null;
    }
    public void StartMoving()
    {
        shouldMove = true; // Set shouldMove to true here
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);
      
        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.Remove(pathVectorList[0]);
        }
        
        // Start moving after setting the path
        StartMoving();
        
    }
}
