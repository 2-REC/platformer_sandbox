using UnityEngine;

// TODO: rename class/script
public class CycleScroller1 : MonoBehaviour {
    public new Camera camera;
    public GameObject sprite;

    public bool horizontalScroll = true;
    public float horizontalDistance = 0;
    public bool verticalScroll = false;
    public float verticalDistance = 0;

    void Start() {
        SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
        float width = renderer.bounds.size.x;
        float height = renderer.bounds.size.y;

        float halfCamHeight = camera.orthographicSize;
        float halfCamWidth = halfCamHeight * camera.aspect;

        int widthCount = 1;
        float wOffset = 0f;
        if (horizontalScroll) {
            if (horizontalDistance == 0) {
                wOffset = width;
                widthCount = Mathf.CeilToInt((halfCamWidth * 2f + width + wOffset) / wOffset);
            } else {
                wOffset = (halfCamWidth * 2f) * horizontalDistance;
                widthCount = Mathf.CeilToInt((halfCamWidth * 2f + width + wOffset) / wOffset);
            }
        }

        int heightCount = 1;
        float hOffset = 0f;
        if (verticalScroll) {
            if (verticalDistance == 0) {
                hOffset = height;
                heightCount = Mathf.CeilToInt((halfCamHeight * 2f + height + hOffset) / hOffset);
            } else {
                hOffset = (halfCamHeight * 2f) * verticalDistance;
                heightCount = Mathf.CeilToInt((halfCamHeight * 2f + height + hOffset) / hOffset);
            }
        }

        for (var i = 0; i < widthCount; i++) {
            for (var j = 0; j < heightCount; j++) {
                GameObject obj = Instantiate(sprite,
                                             new Vector3(sprite.transform.position.x + i * wOffset,
                                                         sprite.transform.position.y + j * hOffset,
                                                         sprite.transform.position.z),
                                             Quaternion.identity,
                                             gameObject.transform);

                CycleScroller2 cs = obj.AddComponent<CycleScroller2>();
                cs.horizontal = horizontalScroll;
                cs.vertical = verticalScroll;
                cs.camera = camera;
                cs.wOffset = wOffset;
                cs.width = width;
                cs.hOffset = hOffset;
                cs.height = height;
                cs.widthCount = widthCount;
                cs.heightCount = heightCount;
            }
        }

        sprite.SetActive(false);
    }

}
