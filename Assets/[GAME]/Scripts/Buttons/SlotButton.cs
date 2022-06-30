namespace _GAME_.Scripts.Buttons
{
    public class SlotButton : BaseButtonBehaviour
    {
        #region Private Variables

        private Slot _slot;

        #endregion

        #region MonoBehaviour Methods

        protected override void Awake()
        {
            base.Awake();
            _slot = GetComponent<Slot>();
        }

        #endregion

        #region Override Methods

        protected override void OnClick()
        {
            base.OnClick();
            _slot.OnClickSlot();
        }

        #endregion

       
    }
}