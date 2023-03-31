using Reflex.Scripts.Attributes;
using ScreenBounds;
using Size;
using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(IResizable))]
    public class SetWidthByScreenBounds : MonoBehaviour
    {
        private IScreenBoundsService _screenBoundsService;

        [Inject]
        private void Inject(IScreenBoundsService screenBoundsService)
        {
            _screenBoundsService = screenBoundsService;
        }

        void Start()
        {
            var resizable = GetComponent<IResizable>();
            var oldSize = resizable.Size;
            oldSize.x = _screenBoundsService.WorldRect.size.x;
            resizable.Size = oldSize;
        }
    }
}