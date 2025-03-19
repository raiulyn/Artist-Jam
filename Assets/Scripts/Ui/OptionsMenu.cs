using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Button ReturnButton;

    private void Start()
    {
        ReturnButton.onClick.AddListener(Close);
    }

    private void Close()
    {
        Destroy(this.gameObject);
    }
}
