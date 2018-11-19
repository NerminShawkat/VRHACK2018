using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour {

    //string selectedcolor = "Green"; // da 7yb2a static f controller w byt3dl b al click f panel ali hia created mn al list f wire parent aw fixed
    public string OriginalMaterial;
    WiresParent _parent;

    private void Start()
    {
        _parent = GetComponentInParent<WiresParent>();
        OriginalMaterial = GetComponent<Renderer>().material.name.Split('(')[0].Trim();
        GetComponent<Renderer>().material = _parent.GetMaterial("White");
    }

    private void OnMouseDown()
    {
        GetComponent<Renderer>().material = _parent.GetMaterial(SelectableColor.SelectedColor);
        CheckWire();
    }

    void CheckWire()
    {
        //print(selectedcolor + " -- " + OriginalMaterial);
        //print(selectedcolor == OriginalMaterial);
        if(SelectableColor.SelectedColor == OriginalMaterial)
        {
            _parent.CorrectWires++;
            GetComponent<CapsuleCollider>().enabled = false;
            _parent.CheckSections();
        }
    }
}
