using UnityEngine;

// TODO: rename class/script
public class CycleScroller2 : MonoBehaviour {
    public new Camera camera;

    public bool horizontal = true;
    public bool vertical = false;
    public float width;
    public float height;
    public float wOffset;
    public float hOffset;
    public float widthCount;
    public float heightCount;

    float halfCamHeight;
    float halfCamWidth;

    void Start() {
        // TODO: could/should be provided when creating instance
        halfCamHeight = camera.orthographicSize;
        halfCamWidth = halfCamHeight * camera.aspect;
    }

    void FixedUpdate() {
        Vector3 offset = camera.transform.position - transform.position;

        // TODO: optimise!
        if (horizontal) {
            if (offset.x > width / 2f + wOffset + halfCamWidth) {
                transform.localPosition += new Vector3(wOffset * widthCount, 0f, 0f);
            } else  if (offset.x < -(width/2f + wOffset + halfCamWidth)) {
                transform.localPosition += new Vector3(-wOffset * widthCount, 0f, 0f);
            }
        }

        if (vertical) {
            if (offset.y > height / 2f + hOffset + halfCamHeight) {
                transform.localPosition += new Vector3(0f, hOffset * heightCount, 0f);
            } else if (offset.y < -(height / 2f + hOffset + halfCamHeight)) {
                transform.localPosition += new Vector3(0f, -hOffset * heightCount, 0f);
            }
        }
    }
}
