using UnityEngine.UI;
using UnityEngine;

public class ScrollViewSystem : MonoBehaviour
{   
    private ScrollRect _scrollRect;
    [SerializeField] private ScrollButton _upButton;
    [SerializeField] private ScrollButton _downButton;

    [SerializeField] private float scrollSpeed = 0.01f;
    void Start()
    {
        _scrollRect = GetComponent<ScrollRect>();
    }

    void FixedUpdate()
    {
        if (_upButton != null)
        {
            if(_upButton.isDown)
            {
                ScrollUp();
            }
        }

        if (_downButton != null)
        {
            if(_downButton.isDown)
            {
                ScrollDown();
            }
        }
    }

    private void ScrollUp()
    {
        if(_scrollRect != null)
        {
            if(_scrollRect.verticalNormalizedPosition <= 1f)
            {
                _scrollRect.verticalNormalizedPosition += scrollSpeed;
            }
        }
    }

        private void ScrollDown()
    {
        if(_scrollRect != null)
        {
            if(_scrollRect.verticalNormalizedPosition >= 0f)
            {
                _scrollRect.verticalNormalizedPosition -= scrollSpeed;
            }
        }
    }
}
