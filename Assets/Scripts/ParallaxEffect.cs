using UnityEngine;

/*
 * ????
 * TODO: move script to parent (1 script, getting children, instead of 1 script on each child...)
 * ????
 * 
 * !!!!
 * TODO: add a confiner to the cinemachine camera (block at level edges)
 * https://www.youtube.com/watch?v=xxshfe3yzqA
 * 
 * !!!!
 * TODO: instead of tiling with sprite renderers, use actual duplicated objects, moved from a side to the other when scrolling
 * (repeatable sprites)
 * !!!!
 * 
 * TODO: keep '=>' operations or move all to 'Update'?
 */

public class ParallaxEffect : MonoBehaviour {
    public Camera cam;
    // Both can't be on same z! (else no need for parallax anyway)
    public Transform followTarget;
    public Transform horizonTarget;

    Transform parent;
    Vector2 startingPosition;

    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;
    // TODO: Following 3 variables could be constant, if don't want to handle moving objects on z axis
    float zDistanceFromTarget => transform.position.z - followTarget.position.z;
    float horizon => horizonTarget.position.z - followTarget.position.z;
    // 0 instead of 1, as we want to stop/cancel the parallax
    float parallaxFactor => (horizon == 0f) ? 0f : zDistanceFromTarget / horizon;

    void Start() {
        /* NOTE: needs a SpriteRenderer on the object, which we don't always have (eg when using CycleScroller)
         * (also, not setting 'sortingLayerName' allows more control (for fancy/weird things))
        // TODO: should be done in update, if want to handle moving objects on z axis
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sortingLayerName = (transform.position.z - followTarget.position.z >= 0) ? "Background" : "Foreground";
        */

        parent = transform.parent;
        startingPosition = transform.position;
    }

    private void FixedUpdate() {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);

    }
}
