using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotManager : MonoBehaviour {

    public GameObject slotPrefab;

    private Queue<Slot> slots = new Queue<Slot>();

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private Slot makeNewSlot()
    {
        GameObject obj = Instantiate(slotPrefab);
        obj.transform.SetParent(transform, false);
        Slot s = obj.GetComponent<Slot>();
        s.init();
        slots.Enqueue(s);
        return s;
    }

    public void shiftAndArange(List<Unit> units)
    {
        if (slots.Count > 0)
        {
            Slot gone = slots.Dequeue();
            Destroy(gone.gameObject);
        }

        //IEnumerator<Slot> slotEnum = slots.GetEnumerator();

        //slotEnum.MoveNext();

        Slot[] slotArray = slots.ToArray();

        int count = 0;

        foreach (Unit u in units)
        {
            Slot s;
            if (count < slotArray.Length)
            {
                s = slotArray[count];
            } else
            {
                s = makeNewSlot();
            }

            s.setUnit(u);
            s.setPos(count);

            //slotEnum.MoveNext();

            count++;
        }

        //IEnumerator<Unit> enumerator = units.GetEnumerator();

        //foreach (Slot s in slots)
        //{
        //    Debug.Log(enumerator.Current);
        //    Debug.Log(enumerator.MoveNext());
        //}
    }
}
