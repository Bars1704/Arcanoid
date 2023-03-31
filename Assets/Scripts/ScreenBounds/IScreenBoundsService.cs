using Size;
using UnityEngine;

namespace ScreenBounds
{
    public interface IScreenBoundsService
    {
        Rect ScreenRect { get; }
        Rect WorldRect { get; }
        void RecalculateBounds();

        Vector3 ClampPosition(Vector3 position, IResizable size);
        public Side IsInsideBounds(Vector3 position, IResizable size);
        

    }
}