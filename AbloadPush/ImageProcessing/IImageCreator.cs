using AbloadPush.RegionSelector;
using System.IO;

namespace AbloadPush.ImageProcessing
{
    interface IImageCreator
    {
        Stream CreateFromScreenRegion(Region region);
        void Save(Stream image, string path, string name);
    }
}
