using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void FlipObject(GameObject gm)
    {
        if (gm.activeSelf)
        {
            gm.SetActive(false);
        }
        else
        {
            gm.SetActive(true);
        }
    }
}
