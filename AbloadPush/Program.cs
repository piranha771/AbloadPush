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
        private static Config settings;
        private static KeyControlManager kcm;
        private static IRegionSelector selector;
        private static IImageCreator ic;
        private static IImageServiceProvider isp;

        [STAThread]
		static void Main()
        {
#if !DEBUG
            try
#endif
            {

                settings = new Config();
                settings.Load();
                isp = new AbloadService(settings.Cookies);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (ProcessIcon pi = new ProcessIcon(settings, isp))
                {
                    kcm = new KeyControlManager();
                    selector = new Windows10RegionSelector(kcm.GlobalHook);
                    ic = new NQuantImageCreator();

                    // Tie display shot to key action
                    kcm.DisplayShot = new Action(() =>
                    {
                        Region region = selector.GetAllScreenRegion();
                        Stream image = ic.CreateFromScreenRegion(region);
                        SaveAndUpload(image);
                    });

                    // Tie single display shot to key action
                    kcm.SingleDisplayShot = new Action(() =>
                    {
                        Region region = selector.GetCurrentScreenRegion();
                        Stream image = ic.CreateFromScreenRegion(region);
                        SaveAndUpload(image);
                    });

                    // Tie window shot to key action
                    kcm.WindowShot = new Action(() =>
                    {
                        Region region = selector.GetCurrentWindowRegion();
                        Stream image = ic.CreateFromScreenRegion(region);
                        SaveAndUpload(image);
                    });

                    // Tie region selector to key events
                    kcm.RegionShotStart = selector.Start;
                    kcm.AbortRegionShot = selector.Abort;

                    selector.RegionFinished += new EventHandler<Region>(
                        (sender, region) =>
                        {
                            Stream image = ic.CreateFromScreenRegion(region);
                            SaveAndUpload(image);
                        }
                    );

                    isp.UploadFinished += new EventHandler<UploadResult>(
                        (sender, result) =>
                        {
                            if (result.Status == UploadResult.UploadStatus.Succeeded)
                            {
                                Clipboard.SetText(result.ImageUrl);
                                pi.NotifyUserSuccess(
                                    Enum.GetName(typeof(UploadResult.UploadStatus), result.Status),
                                    result.ImageUrl,
                                    (string)result.Reason
                                );
                            }
                            else
                            {
                                var ex = result.Reason as Exception;
                                pi.NotifyUserFail(
                                    Enum.GetName(typeof(UploadResult.UploadStatus), result.Status),
                                    ex.Message,
                                    ex.InnerException.Message                      
                                );
                            }
                            

                        }
                    );

                    Application.Run();
                }

            }
#if !DEBUG
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message + "\r\n\r\nIf this is helpful for you, here is the stack trace:\r\n\r\n" + ex.GetType().ToString() + ex.StackTrace, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
#endif
        }

        private static void SaveAndUpload(Stream image)
        {
            string name = DateTime.Now.ToString("yyyyMMddHHmmss") + "-push.png";

            // SAVE DISK
            if (settings.DoSaveToDisk)
            {
                ic.Save(image, settings.ImagePath, name);
            }

            // SAVE ONLINE
            isp.Upload(image, name);
        }
    }
}