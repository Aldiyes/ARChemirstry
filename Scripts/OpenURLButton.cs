using UnityEngine;

public class OpenURLButton : MonoBehaviour
{
    public void OpenWebsite(string link)
    {
        Application.OpenURL(link);
    }
}
