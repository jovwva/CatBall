using UnityEngine;

public class StarInResult : MonoBehaviour
{
    [SerializeField] private GameObject starObject;
    
    public void ShowStar() => starObject.SetActive(true);
}
