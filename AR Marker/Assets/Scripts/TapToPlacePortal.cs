using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TapToPlacePortal : MonoBehaviour
{
    [SerializeField] private Text debugText;
    [SerializeField] private Image touchVisulatizer;
    [SerializeField] private ARRaycastManager arRaycastManager;
    [SerializeField] private AotList hits;
    private Touch touch;
    void Start()
    {
        debugText.text = "App Started";
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchVisulatizer.gameObject.SetActive(true);
            Invoke("CloseTouchViusal",1);
            touchVisulatizer.transform.position = touch.position;
            debugText.text = "Touch Detected";
        }
    }


    private void CloseTouchViusal()
    {
        touchVisulatizer.gameObject.SetActive(false);
    }
}
