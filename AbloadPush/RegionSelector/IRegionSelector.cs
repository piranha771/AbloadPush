using System;

namespace AbloadPush.RegionSelector
{
    interface IRegionSelector
    {
        bool IsActive { get; }
        Action Start { get; }
        Action Abort { get; }
        event EventHandler<Region> RegionFinished;
        
    }
}
