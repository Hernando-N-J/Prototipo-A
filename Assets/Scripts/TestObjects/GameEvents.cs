using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake() => instance = this;

    public event Action OnDoorwayTriggerEnter, OnDoorwayTriggerExit;

    public void DoorwayTriggerEnter() { if (OnDoorwayTriggerEnter != null) OnDoorwayTriggerEnter(); }
    public void DoorwayTriggerExit() { if (OnDoorwayTriggerExit != null) OnDoorwayTriggerExit(); }
}
