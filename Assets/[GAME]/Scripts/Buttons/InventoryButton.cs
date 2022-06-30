
namespace _GAME_.Scripts.Buttons
{
    public class InventoryButton : BaseButtonBehaviour
    {
        #region Private Variables

        private Inventory _inventory;

        #endregion
        #region Override Methods

        protected override void Awake()
        {
            base.Awake();
            _inventory = GetComponent<Inventory>();
        }

        protected override void OnClick()
        {
            base.OnClick();
            _inventory.CheckSlotStatus();
        }

        #endregion
    }
}