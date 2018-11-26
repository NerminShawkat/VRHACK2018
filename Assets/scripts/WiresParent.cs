using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WiresParent : MonoBehaviour
{


    Dictionary<string, Material> materials;
    public int CorrectWires = 0;
    public int _sectionsize;
    public GameObject[] completedsections;
    public Transform parent;
    public  string[] files;
    // Use this for initialization
    void Awake()
    {
        materials = new Dictionary<string, Material>();
        // = Directory.GetFiles(Application.re + "/Resources/Wires");
        Debug.Log(files.Length);
        for (int i = 0; i < files.Length; i++)
        {
            if (files[i].Contains("meta"))
                continue;
            else
            {
                //string splitter = @"\";
                string name = files[i];// (files[i].Split(splitter[0]))[1];
                //name = name.Substring(0, name.Length - 4);
                materials.Add(name, Resources.Load<Material>("Wires/" + name) );
            }
        }

        _sectionsize = parent.childCount / 4;
    }

    public Material GetMaterial(string colorname)
    {
        return materials[colorname];
    }

    public void CheckSections()
    {
        int numberofdonesections = CorrectWires / _sectionsize;
        if (numberofdonesections > 0)
        {
            completedsections[numberofdonesections-1].GetComponent<Renderer>().material = GetMaterial("Green");
        }
    }
}
