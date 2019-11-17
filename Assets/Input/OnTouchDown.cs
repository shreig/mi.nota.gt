using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchDown : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = new RaycastHit();
        for (int i = 0; i< Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
            {
                Debug.Log("Tap");
                Ray ray = CommonObjects.camera.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    hit.transform.gameObject.SendMessage("OnMouseDown");
                }
            }
        }
        
    }
}
