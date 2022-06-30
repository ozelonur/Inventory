using UnityEngine;
using UnityEngine.UI;

namespace _GAME_.Scripts.Buttons
{
    public class BaseButtonBehaviour : MonoBehaviour
    {
        #region Private Variables

        protected Button Button;

        #endregion

        #region MonoBehaviour Buttons

        protected virtual void Awake()
        {
            Button = GetComponent<Button>();
            Button.onClick.AddListener(OnClick);
        }

        #endregion

        #region Private Methods

        protected  virtual void OnClick()
        {
            Debug.Log("Button Clicked!");
        }

        #endregion

        #region Public Methods

        public virtual void ButtonActiveStatus(bool status)
        {
            Button.interactable = status;
        }

        #endregion
    }
}