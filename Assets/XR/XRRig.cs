using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRRig: MonoBehaviour
{
    public XRNodeData head;
    public XRNodeData leftHand;
    public XRNodeData rightHand;

    private List<UnityEngine.XR.XRNodeState> xrNodeStates = new List<UnityEngine.XR.XRNodeState>();

    public void Init ( bool mine )
    {
        Debug.Assert ( head.GetComponent<Camera> ( ) != null, "Head camera component is null" );
        Debug.Assert ( head.GetComponent<AudioListener> ( ) != null, "Head audio listener component is null" );

        head.Init ( );
        leftHand.Init ( );
        rightHand.Init ( );
        // me = mine;

        if ( mine )
        {
            head.GetComponent<Camera> ( ).enabled = true;
            head.XRCamera = head.GetComponent<Camera> ( );
            head.gameObject.tag = "MainCamera";

            head.GetComponent<AudioListener> ( ).enabled = true;

            leftHand.XRNode = UnityEngine.XR.XRNode.LeftHand;
            rightHand.XRNode = UnityEngine.XR.XRNode.RightHand;
        }
        else
        {
            head.GetComponent<Camera> ( ).enabled = false;
            head.GetComponent<AudioListener> ( ).enabled = false;
        }
    }

    public void XRRigUpdate ( )
    {
        UnityEngine.XR.InputTracking.GetNodeStates ( xrNodeStates );
        SetTransforms ( );
    }

    private bool IsTracking ( UnityEngine.XR.XRNode xrNode )
    {
        for ( int i = 0; i < xrNodeStates.Count; i++ )
        {
            if ( xrNodeStates [ i ].nodeType == xrNode )
            {
                return xrNodeStates [ i ].tracked;
            }
        }
        return false;
    }

    private void UpdateTransformFromTracking ( Transform tran, XRNode xrNode )
    {
        if ( IsTracking ( xrNode ) )
        {
            tran.localPosition = InputTracking.GetLocalPosition ( xrNode );
            tran.localRotation = InputTracking.GetLocalRotation ( xrNode );
        }
    }

    private void SetTransforms ( )
    {
        if ( !UnityEngine.XR.XRDevice.isPresent )
            return;

        UpdateTransformFromTracking ( head.transform, XRNode.Head );
        UpdateTransformFromTracking ( leftHand.transform, XRNode.LeftHand );
        UpdateTransformFromTracking ( rightHand.transform, XRNode.RightHand );
    }
}
