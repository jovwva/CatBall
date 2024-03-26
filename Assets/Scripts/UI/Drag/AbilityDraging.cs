using UnityEngine;

public class AbilityDraging : PlatformDrag
{
    [SerializeField] private GameObject effectZone;
    [SerializeField] private PointEffector2D effector2D;

    public override void StartDrag()
    {
        effector2D.enabled = false;
        effectZone.SetActive(true);
        base.StartDrag();
    }
    public override void EndDrag()
    {
        effector2D.enabled = true;
        effectZone.SetActive(false);
        base.EndDrag();
    }
}