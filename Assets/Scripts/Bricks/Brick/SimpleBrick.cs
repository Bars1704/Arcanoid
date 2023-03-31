namespace Bricks.Brick
{
    public class SimpleBrick : BrickBase
    {
        public override void OnBrickCollided()
        {
            DestroyBrick();
        }
    }
}