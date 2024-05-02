using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPathfindingMovementHandler : MonoBehaviour
{
    private const float speed = 6f;
    private int currentPathIndex;
    private List<Vector3> pathVectorList;

    [SerializeField] GameObject angelBarrierScript;

    public bool resetPath = false;

    private void Start()
    {
        {
            Transform bodyTransform = transform.Find("Body");
        }
    }

    private void Update()
    {

        //print("Reset Path is" + resetPath);
        if (resetPath == false)
        {
            HandleMovement();
        }

    }

    //Critical
    private void HandleMovement()
    {
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
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                }
            }

        }
    }

    private void CheckPathCancellation()
    {
        resetPath = angelBarrierScript.GetComponent<AngelBarrierBehaviour>().cancelChase;

    }

    private void StopMoving()
    {
        pathVectorList = null;
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
    }
}
