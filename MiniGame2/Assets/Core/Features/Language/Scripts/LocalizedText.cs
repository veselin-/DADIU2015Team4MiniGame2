using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    public string localizedID = string.Empty, localizedID2 = string.Empty;
    void Start()
    {
        LocalizeText();
    }

    public void LocalizeText()
    {
        Text text = GetComponent<Text>();
        TextMesh textMesh = GetComponent<TextMesh>();
        if (textMesh != null)
        {
            textMesh.text = LanguageManager.Instance.Get(localizedID2);
        }
        if (text != null)
        {
            text.text = LanguageManager.Instance.Get(localizedID);
        }
    }
}
