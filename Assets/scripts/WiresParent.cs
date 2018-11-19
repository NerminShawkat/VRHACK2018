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
    // Use this for initialization
    void Awake()
    {
        materials = new Dictionary<string, Material>();
        string[] files = Directory.GetFiles(Application.dataPath + "/Resources/Wires");
        for (int i = 0; i < files.Length; i++)
        {
            if (files[i].Contains("meta"))
                continue;
            else
            {
                string splitter = @"\";
                string name = (files[i].Split(splitter[0]))[1];
                name = name.Substring(0, name.Length - 4);
                materials.Add(name, Resources.Load("Wires/" + name) as Material);
            }
        }

        _sectionsize = transform.childCount / 4;
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
