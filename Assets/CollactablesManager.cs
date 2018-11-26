using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CollactablesManager : GameItem {

    [SerializeField]
    CollactableItem[] _collactablesList;
    Dictionary<Collectable.Type, int> _collactables ;
    public VRTK_BasicTeleport teleporter;
    public GameObject glass;
    public Transform position;

    private void Start()
    {
        _collactables = new Dictionary<Collectable.Type, int>();
        for (int i = 0; i < _collactablesList.Length; i++)
        {
            if(_collactables.ContainsKey(_collactablesList[i]._type))
            {
                _collactables[_collactablesList[i]._type] += _collactablesList[i]._count;
            }
            else
            {
                _collactables.Add(_collactablesList[i]._type, _collactablesList[i]._count);
            }
        }

        Collectable._onItemCollected.AddListener(OnItemCollectedHandler);
    }

    void OnItemCollectedHandler(Collectable.Type type)
    {
        if (_collactables.ContainsKey(type))
        {
            _collactables[type]--;
            if (_collactables[type] <= 0)
            {
                _collactables.Remove(type);
            }

            if (_collactables.Count == 0)
            {
                FinishGame();
            }
        }
    }

    public override void StartGame()
    {
        MoveHeadset();
    }

    public override void FinishGame()
    {
        _onFinish.Invoke();
        teleporter.ForceTeleport(position.position, position.rotation);
    }
}
[System.Serializable]
public class CollactableItem
{
    public Collectable.Type _type;
    public int _count;
}
