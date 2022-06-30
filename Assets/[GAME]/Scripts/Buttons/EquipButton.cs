namespace _GAME_.Scripts.Buttons
{
    public class EquipButton : BaseButtonBehaviour
    {
        #region Private Variables

        private Inventory _inventory;

        #endregion
        #region Override Methods

        protected override void Awake()
        {
            base.Awake();
            _inventory = GetComponentInParent<Inventory>();
        }

        protected override void OnClick()
        {
            base.OnClick();
            _inventory.PlaceToTheSlot();
        }

        #endregion
    }
}