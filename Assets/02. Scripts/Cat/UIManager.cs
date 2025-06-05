using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public GameObject playObj;
        public GameObject introUI;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        void Start()
        {
            startButton.onClick.AddListener(OnStartButton);
        }

        public void OnStartButton()
        {
            bool isInput = inputField.text != "";
            if (isInput)
            {
                playObj.SetActive(true);
                introUI.SetActive(false);
                nameTextUI.text = inputField.text;
            }
        }
    }
}