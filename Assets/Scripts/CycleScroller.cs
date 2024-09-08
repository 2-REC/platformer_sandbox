using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: rename class/script
public class CycleScroller : MonoBehaviour {
    public Camera cam;

    float width;
    //float height;
    float halfCamHeight;
    float halfCamWidth;
    float widthCount;
    float heightCount;

    void Start() {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        //print(renderer.bounds.size);
        width = renderer.bounds.size.x;
        print("WIDTH: " + width);
        //height = renderer.bounds.size.y;

        print(cam.orthographicSize);
        print(cam.pixelWidth);
        print(cam.scaledPixelWidth);
        print(cam.aspect * cam.orthographicSize);

        /*
        float camHeight = cam.orthographicSize * 32 * 2;
        float camWidth = camHeight * cam.aspect;
        print("---");
        print(camHeight);
        print("CAM WIDTH: " + camWidth);
        */
        halfCamHeight = cam.orthographicSize;
        halfCamWidth = halfCamHeight * cam.aspect;
        print("CAM HEIGHT: " + halfCamHeight);
        print("CAM WIDTH: " + halfCamWidth);

        /*
        print("WIDTH FACTOR: " + (halfCamWidth*2 / width));
        */

        //widthCount = halfCamWidth * 2 / width + 1f;
        //widthCount = Mathf.Ceil(halfCamWidth * 2 / width);
        widthCount = Mathf.Ceil(halfCamWidth * 2 / width) + 2;
        //widthCount = Mathf.Ceil(halfCamWidth*2 / width) + 1f;
        //heightCount = Mathf.Ceil(halfCamHeight * 2 / height) + 1f;
        print("widthCount: " + widthCount);
        //print("heightCount: " + heightCount);
    }

    void Update() {
        Vector3 offset = cam.transform.position - transform.position;
        // TODO: optimise!
        //print("Offset: " + offset.x);
        print("offset: " + offset);
        print("width + halfCamWidth: " + (width + halfCamWidth));
        //if (offset.x > width * widthCount) {
        if (offset.x > width*1.5f + halfCamWidth) {
            //transform.localPosition = new Vector3(transform.localPosition.x + width * widthCount * 2, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition += new Vector3(width * widthCount, 0f, 0f);
        //} else if (offset.x < -width * widthCount) {
        } else if (offset.x < -(width*1.5f + halfCamWidth)) {
            //transform.localPosition = new Vector3(transform.localPosition.x - width * widthCount * 2, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition += new Vector3(-width * widthCount, 0f, 0f);
        }
        /*
        TODO: CREATE OBJECTS!!!!
        float NB = 2;
        float offset_obj = halfCamWidth * 2 / NB;
        widthCount = NB + 2;
        if (offset.x > offset_obj * 1.5f + halfCamWidth) {
            transform.localPosition += new Vector3(widthCount * offset_obj, 0f, 0f);
        } else if (offset.x < -(offset_obj * 1.5f + halfCamWidth)) {
            transform.localPosition += new Vector3(-widthCount * offset_obj, 0f, 0f);
        }
        */

        /*
        if (offset.x > halfCamWidth * 4) {
            transform.localPosition = new Vector3(transform.localPosition.x + width * 5, transform.localPosition.y, transform.localPosition.z);
        } else if (offset.x < -halfCamWidth * 4) {
            transform.localPosition = new Vector3(transform.localPosition.x - width * 5, transform.localPosition.y, transform.localPosition.z);
        }
        */

        /*
        if (offset.y > height * 2) {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + height * 4, transform.localPosition.z);
        } else if (offset.y < -height * 2) {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - height * 4, transform.localPosition.z);
        }
        */
    }
}
