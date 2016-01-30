
using UnityEngine;

public class Unit {

    private static string[] names = { "Bobby", "Billy", "Bruce", "Becky", "Bart", "Beta", "Bugger", "Bowler", "Beast" };
    private static int nameIndex = 0;
    private static string getName()
    {
        string name = "Bob";
        if (nameIndex < names.Length) name = names[nameIndex];
        nameIndex++;
        return name;
    }

    private string name = Unit.getName();

    public float health = 100f;

    public Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    public float initiative = Random.Range(0f, 100f);

    public override string ToString() { return name; }
}
