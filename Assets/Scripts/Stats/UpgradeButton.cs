using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public void UpgradeAlliedPeon() {
        FindObjectOfType<GameDirector>().UpgradeAlliedTroops();
    }
}
