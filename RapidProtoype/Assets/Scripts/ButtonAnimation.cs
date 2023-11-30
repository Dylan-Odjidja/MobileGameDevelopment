using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    Button button;
    Vector3 upScale = new Vector3(1.2f, 1.2f, 1);

    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Anim);
    }

    void Anim()
    {
        LeanTween.scale(gameObject, upScale, 0.1f);
        LeanTween.scale(gameObject, Vector3.one, 0.1f).setDelay(0.1f);
    }
}
