using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class GameItem : MonoBehaviour {

    [SerializeField]
    public UnityEvent _onFinish;
    [SerializeField]
    protected Vector3 _headsetPostion;
    [SerializeField]
    protected Transform _vrRoot;

    public abstract void StartGame();
    public abstract void FinishGame();


    protected void MoveHeadset()
    {
        _vrRoot.position = _headsetPostion;
    }

}
