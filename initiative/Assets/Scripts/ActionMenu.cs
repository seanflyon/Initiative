using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ActionMenu : MonoBehaviour {

    //public Dictionary<string, Button> buttons;
    public List<Button> buttonList;

    private Unit activeUnit;

	// Use this for initialization
	void Start () {
        MyEventSystem.OnUnitActiveAction += OnUnitActive;


        buttonList[0].onClick.AddListener(OnAttackClicked);
        buttonList[1].onClick.AddListener(OnStunClicked);
        buttonList[2].onClick.AddListener(OnBombClicked);
        
    }

    void OnDestroy()
    {
        MyEventSystem.OnUnitActiveAction -= OnUnitActive;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnAttackClicked()
    {
        Debug.Log(activeUnit + " is deciding who to attack");
        MyEventSystem.TriggerEndTurn();
    }

    private void OnStunClicked()
    {
        Debug.Log(activeUnit + " is deciding who to stun");
        MyEventSystem.TriggerEndTurn();
    }

    private void OnBombClicked()
    {
        Debug.Log(activeUnit + " set us up the bomb, or they will once they decide how long of a fuse to use");
        MyEventSystem.TriggerEndTurn();
    }

    private void OnUnitActive(Unit unit)
    {
        activeUnit = unit;
    }
}
