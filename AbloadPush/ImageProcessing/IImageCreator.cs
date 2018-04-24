using AbloadPush.RegionSelector;
using System.IO;

namespace AbloadPush.ImageProcessing
{
    interface IImageCreator
    {
        Stream CreateFromScreenRegion(Region region);
    }
}
