using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    private float minX = 0f;
    private float spacing = 110f;

    public Unit unit;

    public GameObject portrait;

	// Use this for initialization
	void Start () {
	
	}

    public void init()
    {
        float width = transform.parent.gameObject.GetComponent<RectTransform>().rect.width;
        minX = 60f - width / 2f;
    }

    public void setUnit(Unit unit)
    {
        this.unit = unit;
        portrait.GetComponent<Image>().color = unit.color;
    }

    public void setPos(int index)
    {
        float x = minX + index * spacing;
        transform.localPosition = new Vector3(x, 0f, 0f);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
