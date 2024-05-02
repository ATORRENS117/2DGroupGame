using UnityEngine;

/*
 * The `SimpleCameraFollow2D` class is a MonoBehaviour that provides functionality for a simple 2D camera follow system in Unity.
 *
 * The class has several public properties that can be adjusted in the Unity editor:
 * - `target`: The Transform of the object that the camera should follow.
 * - `offset`: The offset of the camera from the target in the x and y directions.
 * - `cameraSpeed`: The speed at which the camera moves to follow the target.
 *
 * In the `Awake` method, it caches a reference to the Transform component of the camera.
 *
 * In the `FixedUpdate` method, it checks if a target has been assigned. If a target is assigned, it calculates the target position by adding the offset to the target's position.
 * It then smoothly interpolates the camera's position towards the target position using the `Vector3.Lerp` method and the `cameraSpeed`.
 */

public class SimpleCameraFollow2D : MonoBehaviour
{
    public Transform target;
    public Vector2 offset = new Vector2(0, 3);
    public float cameraSpeed = 4;
    
    private Transform cachedTransform;

    void Awake()
    {
        cachedTransform = transform;
    }

    void FixedUpdate()
    {
        if (!target){
            return;
        }         

        Vector3 pos = cachedTransform.position;
        Vector3 targetPos = target.position;
        cachedTransform.position = Vector3.Lerp(pos, new Vector3(targetPos.x + offset.x, targetPos.y + offset.y, pos.z), Time.deltaTime * cameraSpeed);
    }
}