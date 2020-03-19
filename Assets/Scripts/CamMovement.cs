using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    private Vector3 touchStart;
    private Camera thisCamera = null;

    [SerializeField]
    private float zoomOutMin = 1;

    [SerializeField]
    private float zoomOutMax = 8;

    private bool isFocused = false;

    protected void Awake()
    {
        thisCamera = this.GetComponent<Camera>();
    }

    private void OnApplicationFocus(bool focus)
    {
        isFocused = focus;
    }

    protected void LateUpdate()
    {
        if (isFocused || MenuUpdater.Instance.IsPaused)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            touchStart = thisCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        }

        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - thisCamera.ScreenToWorldPoint(Input.mousePosition);
            thisCamera.transform.position += direction;
        }

        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    private void Zoom (float increment)
    {
        thisCamera.orthographicSize = Mathf.Clamp(thisCamera.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

}
