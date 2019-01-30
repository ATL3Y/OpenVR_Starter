using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class XRNodeData: MonoBehaviour
{
    public UnityEngine.XR.XRNode XRNode { get; set; }
    public Camera XRCamera { get; set; }

    // For more information on OpenVR Controllers, see: 
    // https://docs.unity3d.com/2017.1/Documentation/Manual/OpenVRControllers.html

    // Oculus: B or Y, Vive: Menu
    public bool ButtonPress { get; set; }
    public bool ButtonPressDown { get; set; }
    public bool ButtonPressUp { get; set; }

    // Oculus: Thumbstick, Vive: Trackpad
    public bool ThumbPress { get; set; }
    public bool ThumbPressDown { get; set; }
    public bool ThumbPressUp { get; set; }
    public bool ThumbTouch { get; set; }
    public bool ThumbTouchDown { get; set; }
    public bool ThumbTouchUp { get; set; }
    public Vector2 ThumbPos { get; set; }

    // Oculus: Index Trigger, Vive: Trigger
    public float IndexTriggerSqueeze { get; set; }
    public bool IndexTriggerTouch { get; set; }
    public bool IndexTriggerTouchDown { get; set; }
    public bool IndexTriggerTouchUp { get; set; }

    // Oculus: Hand Trigger, Vive: Hand Grip
    public float HandTriggerSqueeze { get; set; }

    // Custom index trigger usage.
    public bool IndexTrigger { get; set; }
    public bool IndexTriggerDown { get; set; } 
    public bool IndexTriggerUp { get; set; } 

    public XRRig XRRig { get; set; }
    private bool debug = true;

    private bool isHead = false;

    public void Init ()
    {
        isHead = name.Contains ( "Head" );
        if ( isHead )
        {

        }
    }
}
