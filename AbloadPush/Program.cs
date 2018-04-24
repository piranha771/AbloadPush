using AbloadPush.ImageProcessing;
using AbloadPush.ImageService;
using AbloadPush.ImageService.Abload;
using AbloadPush.RegionSelector;
using AbloadPush.UI;
using System;
using System.IO;
using System.Windows.Forms;

namespace AbloadPush
{
    static class Program
	{
        private static Settings settings;
        private static KeyControlManager kcm;
        private static IRegionSelector selector;
        private static IImageCreator ic;
        private static IImageServiceProvider isp;

        [STAThread]
		static void Main()
        {
            settings = new Settings();
            settings.Load();
            isp = new AbloadService(settings.Cookies);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (ProcessIcon pi = new ProcessIcon(settings, isp))
            {
                kcm = new KeyControlManager();
                selector = new Windows10RegionSelector(kcm.GlobalHook);
                ic = new NQuantImageCreator();               

                kcm.RegionShotStart = selector.Start;
                kcm.AbortRegionShot = selector.Abort;

                selector.RegionFinished += new EventHandler<RegionSelector.Region>(
                    (sender, region) =>
                    {
                        Stream image = ic.CreateFromScreenRegion(region);
                        isp.Upload(image);
                    }
                );

                isp.UploadFinished += new EventHandler<UploadResult>(
                    (sender, result) =>
                    {
                        Clipboard.SetText(result.ImageUrl);
                        pi.NotifyUser(Enum.GetName(typeof(UploadResult.UploadStatus), result.Status), result.ImageUrl, result.ImageUrl);
                        
                    }
                );
    
                Application.Run();
            }
        }
    }
}