using Gma.System.MouseKeyHook;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AbloadPush.RegionSelector
{
    class Windows10RegionSelector : IRegionSelector
    {
        private static readonly int CursorPadding = 6;    

        private readonly IKeyboardMouseEvents kmEvents;
        private bool isActive = false;
        private bool isDragging = false;

        private Point firstPoint;
        private Point secondPoint;

        private Form shield;
        private Form regionSelector;

        public Action Start => StartShooting;
        public Action Abort => AbortShooting;
        public bool IsActive => isActive;

        public event EventHandler<Region> RegionFinished;

        public Windows10RegionSelector(IKeyboardMouseEvents kmEvents)
        {
            this.kmEvents = kmEvents;
            this.kmEvents.MouseDown += StartDragRegion;
            this.kmEvents.MouseUp += StopShooting;
            this.kmEvents.MouseMoveExt += MouseMove;

            shield = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                Opacity = 0.01,
                MinimumSize = new Size(1, 1),
                Size = new Size(CursorPadding * 2, CursorPadding * 2),
                ShowInTaskbar = false,
                Cursor = Cursors.Cross
            };

            regionSelector = new Form
            {
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.None,
                TopMost = true,
                Opacity = 0.5,
                MinimumSize = new Size(1, 1),
                Size = new Size(1, 1),
                ShowInTaskbar = false,
            };
        }

        private void StartShooting()
        {
            if (!isActive && !isDragging)
            {
                isActive = true;
                shield.Show();
                shield.Location = new Point(Control.MousePosition.X - CursorPadding, Control.MousePosition.Y - CursorPadding);
            }
        }

        private void StartDragRegion(object sender, MouseEventArgs e)
        {
            if (isActive && !isDragging)
            {
                isDragging = true;
                firstPoint = Control.MousePosition;
                regionSelector.Show();
            }     
        }

        void MouseMove(object sender, MouseEventExtArgs e)
        {
            if (isActive)
            {
                shield.Location = new Point(e.Location.X - CursorPadding, e.Location.Y - CursorPadding);
                secondPoint = e.Location;
                var r = Rectangle.FromLTRB(
                    Math.Min(firstPoint.X, secondPoint.X), 
                    Math.Min(firstPoint.Y, secondPoint.Y), 
                    Math.Max(firstPoint.X, secondPoint.X), 
                    Math.Max(firstPoint.Y, secondPoint.Y)
                );
                regionSelector.Location = r.Location;
                regionSelector.Size = r.Size;             
            }
        }

        private void StopShooting(object sender, MouseEventArgs e)
        {
            if (isActive & isDragging)
            {
                isActive = false;
                isDragging = false;

                var region = FormToRegion(regionSelector);

                shield.Hide();
                regionSelector.Hide();

                
                RegionFinished(this, region);
            }
        }

        public void AbortShooting()
        {
            shield.Hide();
            regionSelector.Hide();
            isActive = false;
            isDragging = false;
        }

        public void Started(object sender, MouseEventArgs e)
        {
            if (isActive)
            {
                isDragging = true;
                firstPoint = e.Location;
                regionSelector.Location = firstPoint;
                regionSelector.Size = new Size(1, 1);
                regionSelector.Show();

            }
        }

        public Region GetAllScreenRegion()
        {
            return new Region(
                new Vector2 { X = 0, Y = 0 },
                new Vector2 { X = SystemInformation.VirtualScreen.Width, Y = SystemInformation.VirtualScreen.Height }
            );
        }

        private static Region FormToRegion(Form form)
        {
            return new Region(
                new Vector2 { X = form.Location.X, Y = form.Location.Y },
                new Vector2 { X = form.Location.X + form.Width, Y = form.Location.Y + form.Height}    
            );
        }
    }
}
