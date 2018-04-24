using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;

namespace AbloadPush.UI
{
    class KeyControlManager
    {
        public static readonly string RegionShotStartHotKey = "Control+Shift+D4";
        public static readonly string AbortRegionShotHotKey = "Escape";
        

        private readonly IKeyboardMouseEvents globalHook;

        private Action regionShotStart;
        private Action abortRegionShot;

        public Action RegionShotStart { get => regionShotStart; set => regionShotStart = value; }
        public Action AbortRegionShot { get => abortRegionShot; set => abortRegionShot = value; }

        public IKeyboardMouseEvents GlobalHook => globalHook;

        public KeyControlManager()
        {
            globalHook = Hook.GlobalEvents();
            globalHook.OnCombination(
                new Dictionary<Combination, Action>()
                {
                    { Combination.FromString(RegionShotStartHotKey), RegionShotStartProxy },
                    { Combination.FromString(AbortRegionShotHotKey), AbortRegionShotProxy },
                }
            );
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
