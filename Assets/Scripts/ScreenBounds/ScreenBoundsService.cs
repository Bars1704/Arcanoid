using Size;
using UnityEngine;

namespace ScreenBounds
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ScreenBoundsService : IScreenBoundsService
    {
        public Rect ScreenRect { get; private set; }
        public Rect WorldRect { get; private set; }

        public void RecalculateBounds()
        {
            var camera = Camera.main;
            var screenSize = new Vector2(camera.pixelWidth, camera.pixelHeight);
            var worldTopRightPoint = new Vector3(screenSize.x, screenSize.y, camera.nearClipPlane);
            var worldTopRightCorner = camera.ScreenToWorldPoint(worldTopRightPoint);
            var worldBottomLeftCorner = camera.ScreenToWorldPoint(Vector3.zero);
            var worldBoundSize = worldTopRightCorner - worldBottomLeftCorner;
            ScreenRect = new Rect(Vector2.zero, screenSize);
            WorldRect = new Rect(worldBottomLeftCorner, new Vector2(worldBoundSize.x, worldBoundSize.y));
        }

        private (Vector2 min, Vector2 max) GetAllowedBounds(IResizable resizable)
        {
            var xMin = WorldRect.xMin + resizable.Size.x / 2;
            var xMax = WorldRect.xMax - resizable.Size.x / 2;

            var yMin = WorldRect.yMin + resizable.Size.y / 2;
            var yMax = WorldRect.yMax - resizable.Size.y / 2;

            return (new Vector2(xMin, yMin), new Vector2(xMax, yMax));
        }

        public Vector3 ClampPosition(Vector3 position, IResizable size)
        {
            var (min, max) = GetAllowedBounds(size);
            position.x = Mathf.Clamp(position.x, min.x, max.x);
            position.y = Mathf.Clamp(position.y, min.y, max.y);
            return position;
        }

        public Side IsInsideBounds(Vector3 position, IResizable size)
        {
            var (min, max) = GetAllowedBounds(size);
            if (position.x <= min.x)
            {
                return Side.Left;
            }

            if (position.x >= max.x)
            {
                return Side.Right;
            }

            if (position.y <= min.y)
            {
                return Side.Bottom;
            }

            if (position.y >= max.y)
            {
                return Side.Top;
            }

            return Side.None;
        }
    }
}