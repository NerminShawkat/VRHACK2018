using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
    public GameObject Helmet;
    public GameObject vest;
    public GameObject boots;
    public GameObject gloves;
    public GameObject Averoll;

    // Use this for initialization
    void Start () {
        Collectable._onItemCollected.AddListener(OnItemCollectedUI);

    }

    void OnItemCollectedUI(Collectable.Type type)
    {
        switch (type)
        {
            case Collectable.Type.Helmet:
                Helmet.SetActive(true);
                break;
            case Collectable.Type.Overall:
                Averoll.SetActive(true);
                break;
            case Collectable.Type.Boots:
                boots.SetActive(true);
                break;
            case Collectable.Type.SafetyjACKET:
                vest.SetActive(true);
                break;
            case Collectable.Type.Gloves:
                gloves.SetActive(true);
                break;
            default:
                break;
        }
    }


}
