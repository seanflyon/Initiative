using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitiativePanelScript : MonoBehaviour {

    public GameObject unitPrefab;

    public SlotManager slotManager;

    public enum State {Scrolling, UnitActive };
    private State state = State.Scrolling;

    public float timeFactor = 20f;

    private float now = 0f;

    private float maxSizeUp = 1.2f;
    //private float maxSizeDown = 0.01f;

    private float currentMaxInitiative = 0f;

    private List<InitiativeUnit> units = new List<InitiativeUnit>();

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 8; i++)
        {
            GameObject obj = Instantiate(unitPrefab);
            obj.transform.SetParent(transform, false);
            //obj.transform.parent = transform;
            InitiativeUnit unit = obj.GetComponent<InitiativeUnit>();
            unit.init();
            units.Add(unit);
            rescale();
        }

        units.Sort(CompareByInitiative);
        List<Unit> slotUnits = new List<Unit>(units.Count);
        foreach (InitiativeUnit u in units)
        {
            slotUnits.Add(u.unit);
        }
        slotManager.shiftAndArange(slotUnits);
    }
	
	// Update is called once per frame
	void Update () {
        if (state == State.Scrolling)
        {
            now += Time.deltaTime * timeFactor;
            checkMinInitiative();
            rescale();

        }
        else
        {
            rescale();
            if (Input.anyKeyDown)
            {
                InitiativeUnit minUnit = units.ToArray()[0];
                minUnit.endTurn();
                units.Sort(CompareByInitiative);
                List<Unit> slotUnits = new List<Unit>(units.Count);
                foreach (InitiativeUnit u in units)
                {
                    slotUnits.Add(u.unit);
                }
                slotManager.shiftAndArange(slotUnits);
                state = State.Scrolling;
            }
        }
	}

    private void OnEndTurn()
    {
        //InitiativeUnit minUnit = units.ToArray()[0];
        //minUnit.endTurn();
        units.Sort(CompareByInitiative);
        List<Unit> slotUnits = new List<Unit>(units.Count);
        foreach (InitiativeUnit u in units)
        {
            slotUnits.Add(u.unit);
        }
        slotManager.shiftAndArange(slotUnits);
        state = State.Scrolling;
    }

    private static int CompareByInitiative(InitiativeUnit a, InitiativeUnit b)
    {
        return a.initiative.CompareTo(b.initiative);
    }

    private void checkMinInitiative()
    {
        units.Sort(CompareByInitiative);
        InitiativeUnit minUnit = units.ToArray()[0];
        float minInitiative = minUnit.initiative;

        if (minInitiative <= now)
        {
            state = State.UnitActive;
            minUnit.takeTurn();
        }

        if (minInitiative > 10000f)
        {
            foreach (InitiativeUnit u in units)
            {
                u.rescaleInitiative(10000f);
            }
        }
    }

    public void rescale()
    {
        // now = 0 width, farthest out unit = max width
        float maxInitiative = 0f;
        foreach (InitiativeUnit u in units)
        {
            maxInitiative = Mathf.Max(maxInitiative, u.initiative);
        }

        if(maxInitiative > currentMaxInitiative)
        {
            currentMaxInitiative = Mathf.Min(currentMaxInitiative + maxSizeUp, maxInitiative);
        } else if (maxInitiative <= currentMaxInitiative && state == State.Scrolling)
        {
            currentMaxInitiative += Time.deltaTime * timeFactor / 2f;
        }

        foreach (InitiativeUnit u in units)
        {
            u.position(now, currentMaxInitiative);
        }
    }
}
