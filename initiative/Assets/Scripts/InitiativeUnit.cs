using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InitiativeUnit : MonoBehaviour {

    public Unit unit { get; private set; }

    private float posBuffer = 20f;

    private float y;
    private float maxX;
    private float minX;
    private float initiativeWidth;

    //public float initiative = 100f;
    public float initiative { get { return unit.initiative; } }

	// Use this for initialization
	public void init () {
        unit = new Unit();
        Debug.Log("unit " + unit + " with init " + unit.initiative);
        GetComponent<Image>().color = unit.color;

        //float height = transform.parent.gameObject.GetComponent<RectTransform>().rect.height;
        float width = transform.parent.gameObject.GetComponent<RectTransform>().rect.width;
        y = 0f;
        maxX = width/2f - posBuffer;
        minX = posBuffer - width/2f;
        initiativeWidth = maxX - minX;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void position (float now, float maxInitiative)
    {
        float pos = minX + (unit.initiative - now) / (maxInitiative - now) * initiativeWidth;
        transform.localPosition = new Vector3(pos, y, 0f);
    }

    public void takeTurn()
    {
        Debug.Log("Unit " + unit + " taking its turn");
        MyEventSystem.TriggerUnitActive(unit);
    }

    public void endTurn() // TODO: remove this function
    {
        unit.initiative += Random.Range(10f, 100f);
    }

    public void rescaleInitiative(float shift)
    {
        unit.initiative -= shift;
    }
}
