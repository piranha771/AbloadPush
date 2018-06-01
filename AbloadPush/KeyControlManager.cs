using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;

namespace AbloadPush
{
    class KeyControlManager
    {
        public static readonly string DisplayShotHotKey = "Control+Shift+D1";
        public static readonly string SingleDisplayShotHotKey = "Control+Shift+D2";
        public static readonly string WindowShotHotKey = "Control+Shift+D3";
        public static readonly string RegionShotStartHotKey = "Control+Shift+D4";
        public static readonly string AbortRegionShotHotKey = "Escape";    

        private readonly IKeyboardMouseEvents globalHook;
        
        private Action displayShot;
        private Action singleDisplayShot;
        private Action windowShot;
        private Action regionShotStart;
        private Action abortRegionShot;

        public Action DisplayShot { get => displayShot; set => displayShot = value; }
        public Action SingleDisplayShot { get => singleDisplayShot; set => singleDisplayShot = value; }
        public Action WindowShot { get => windowShot; set => windowShot = value; }
        public Action RegionShotStart { get => regionShotStart; set => regionShotStart = value; }
        public Action AbortRegionShot { get => abortRegionShot; set => abortRegionShot = value; }

        public IKeyboardMouseEvents GlobalHook => globalHook;

        public KeyControlManager()
        {
            globalHook = Hook.GlobalEvents();
            globalHook.OnCombination(
                new Dictionary<Combination, Action>()
                {
                    { Combination.FromString(DisplayShotHotKey), DisplayShotProxy },
                    { Combination.FromString(SingleDisplayShotHotKey), SingleDisplayShotProxy },
                    { Combination.FromString(WindowShotHotKey), WindowShotProxy },
                    { Combination.FromString(RegionShotStartHotKey), RegionShotStartProxy },
                    { Combination.FromString(AbortRegionShotHotKey), AbortRegionShotProxy },
                }
            );
        }

        private void DisplayShotProxy()
        {
            if (displayShot != null)
                displayShot();
        }

        private void SingleDisplayShotProxy()
        {
            if (displayShot != null)
                singleDisplayShot();
        }

        private void WindowShotProxy()
        {
            if (displayShot != null)
                windowShot();
        }

        private void RegionShotStartProxy()
        {
            if (regionShotStart != null)
                regionShotStart();
        }

        private void AbortRegionShotProxy()
        {
            if (abortRegionShot != null)
                abortRegionShot();
        }
    }
}
