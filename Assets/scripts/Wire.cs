using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Wire : MonoBehaviour
{

    //string selectedcolor = "Green"; // da 7yb2a static f controller w byt3dl b al click f panel ali hia created mn al list f wire parent aw fixed
    public string OriginalMaterial;
    WiresParent _parent;
    [SerializeField]
    VRTK_InteractableObject _myInteractableObject;
    [SerializeField]
    VRTK_ControllerEvents _controllerEvents;
    GameObject _interactingObject;

    bool _isTouched = false;

    private void Start()
    {
        _parent = GetComponentInParent<WiresParent>();
        //OriginalMaterial = GetComponent<Renderer>().material.name.Split('(')[0].Trim();
        GetComponent<Renderer>().material = _parent.GetMaterial("White");
        Debug.Log(_parent);
        _myInteractableObject.InteractableObjectTouched += _myInteractableObject_InteractableObjectTouched;
        _myInteractableObject.InteractableObjectUntouched += _myInteractableObject_InteractableObjectUntouched;
        _controllerEvents.TriggerClicked += _controllerEvents_TriggerClicked;
    }


    private void _controllerEvents_TriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        if (_isTouched)
        {
            GetComponent<Renderer>().material = _parent.GetMaterial(SelectableColor.SelectedColor);
            CheckWire();
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
    void CheckWire()
    {
        //print(selectedcolor + " -- " + OriginalMaterial);
        //print(selectedcolor == OriginalMaterial);
        if (SelectableColor.SelectedColor == OriginalMaterial)
        {
            _parent.CorrectWires++;
            GetComponent<Collider>().enabled = false;
            _parent.CheckSections();
        }
    }
}