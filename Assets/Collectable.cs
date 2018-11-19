using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK;

public class Collectable : MonoBehaviour {

	public enum Type
    {
        Helmet,
        Overall,
        Harness,
        Boots,
        SafetyjACKET,
        Gloves
    }

    [SerializeField]
    Type _myType;
    [SerializeField]
    VRTK_InteractableObject _myInteractableObject;
    
    public static ItemCollectedEvent _onItemCollected = new ItemCollectedEvent();


    private void Start()
    {
        _myInteractableObject.InteractableObjectGrabbed += _myInteractableObject_InteractableObjectGrabbed;
    }

    private void _myInteractableObject_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        _onItemCollected.Invoke(_myType);
        Destroy(gameObject);
    }
}
public class ItemCollectedEvent:UnityEvent<Collectable.Type>
{

}
