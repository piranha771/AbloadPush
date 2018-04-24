using System;

namespace AbloadPush.RegionSelector
{
    class Region
    {
        private Vector2 first;
        private Vector2 second;

        internal Vector2 First { get => first;}
        internal Vector2 Second { get => second;}

        public Region(Vector2 fist, Vector2 second)
        {
            this.first = fist;
            this.second = second;
        }

        public Region ToTLBR()
        {
            return new Region(
                new Vector2
                {
                    X = Math.Min(first.X, second.X),
                    Y = Math.Min(first.Y, second.Y)
                },
                new Vector2
                {
                    X = Math.Max(first.X, second.X),
                    Y = Math.Max(first.Y, second.Y)
                }
            );
        }

        public int Width()
        {
            return Math.Abs(first.X - second.X);
        }

        public int Height()
        {
            return Math.Abs(first.Y - second.Y);
        }
    }
}
