using UnityEngine;

public class StarInResult : MonoBehaviour
{
    // Сомнительно, но пока что пойдет. 
    // Данный класс висит на иконке звезды в панельке результатов
    [SerializeField] private GameObject starObject;
    
    public void ShowStar() => starObject.SetActive(true);
}
