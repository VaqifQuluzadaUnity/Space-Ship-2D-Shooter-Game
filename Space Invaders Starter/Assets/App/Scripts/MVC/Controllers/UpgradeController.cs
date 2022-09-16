using UnityEngine;
using DynamicBox.EventManagement;

namespace GalaxyDefenders.MVC
{
    public class UpgradeController : MonoBehaviour
    {
        [SerializeField] private UpgradeView view;

        public void UpgradeMovement()
        {
            EventManager.Instance.Raise(new PurchaseEvent(1));
            EventManager.Instance.Raise(new UpgradeEvent(1));
        }

        public void UpgradeBullet()
        {
            EventManager.Instance.Raise(new PurchaseEvent(2));
            EventManager.Instance.Raise(new UpgradeEvent(2));
        }

        public void Back()
        {

        }
    }
}
