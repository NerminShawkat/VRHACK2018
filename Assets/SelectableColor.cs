using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SelectableColor : MonoBehaviour {

    [SerializeField]
    string _myColor;
    [SerializeField]
    VRTK_InteractableObject _myInteractableObject;
    [SerializeField]
    VRTK_ControllerEvents _controllerEvents;

    GameObject _interactingObject;

    bool _isTouched = false;

    public static string SelectedColor
    {
        get;
        private set;
    }

    private void Start()
    {
        SelectedColor = "Green";
        _myInteractableObject.InteractableObjectTouched += _myInteractableObject_InteractableObjectTouched;
        _myInteractableObject.InteractableObjectUntouched += _myInteractableObject_InteractableObjectUntouched;
        _controllerEvents.TriggerClicked += _controllerEvents_TriggerClicked;
    }

    private void _controllerEvents_TriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        if(_isTouched)
        {
            SelectedColor = _myColor;
            Debug.Log(_myColor);
        }
    }

    private void _myInteractableObject_InteractableObjectUntouched(object sender, InteractableObjectEventArgs e)
    {
        if (e.interactingObject == _interactingObject)
        {
            _isTouched = false;
        }
        
    }

    private void _myInteractableObject_InteractableObjectTouched(object sender, InteractableObjectEventArgs e)
    {
        _isTouched = true;
        _interactingObject = e.interactingObject;
    }
    

    private void _myInteractableObject_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        
    }
}
