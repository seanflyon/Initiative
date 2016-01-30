
public class MyEventSystem {

    public delegate void UnitActiveAction(Unit unit);
    public static event UnitActiveAction OnUnitActiveAction;

    public static void TriggerUnitActive(Unit unit)
    {
        if (OnUnitActiveAction != null)
        {
            OnUnitActiveAction(unit);
        }
    }

    public delegate void EndTurnAction();
    public static event EndTurnAction OnEndTurnAction;

    public static void TriggerEndTurn()
    {
        if (OnEndTurnAction != null)
        {
            OnEndTurnAction();
        }
    }
}
