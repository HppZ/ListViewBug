using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ListViewBug
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var source = new List<string>();
            {
                
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\85hdWh8KtR4.jpg");

                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\4b3b3c1b-65d0-4e1e-8670-3de4b8024409.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\75121f0c-6376-4258-b828-1fe8effd9255.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\3ff21256-3cd4-4c4f-9c8d-08b01579af70.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\d2e44b1a-07ef-42ac-bae0-17722960e514.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\42fc9253-59c5-47bc-b52c-d48e876567b1.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\98dc7fb1-0842-4934-b2e8-8be7b3f50181.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\32c51993-b680-4240-8d68-627658e3a1e4.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\cae8cbc0-c6e6-4800-95ba-4eab27d262b9.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\d306d997-9632-412f-ae05-739d030d205d.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\4f3cd5f6-d2e9-48bd-a7be-57282bbace1b.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\a46f488f-e7ef-4a49-9b85-440688e10602.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\22c40c0c-d38c-46b6-b37a-d4c5fe3fca2e.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\f33e29bc-4e72-4ae2-8d0a-2b403a44c810.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\5794773b-1650-45b8-aa94-0aff24e59cba.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\b0532bc7-2e08-4fcd-866a-58aec0c5569a.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\c68222ec-6273-4c99-a898-b658c3d3285f.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\49562ba6-9504-496b-b9a8-f2d4f1958963.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\3982c6ac-5218-43b4-a24c-8cac9dc56144.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\70ec3db8-9408-4d11-a540-620bca2ea769.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\62ed57bb-e9b4-47a9-900d-24cee619f34e.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\a43a4c73-8da2-4697-b1cb-d48ced9584ae.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\8ef6fad8-e403-46b7-add4-6fd1dfa0295c.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\7d13f924-3a94-4617-85e6-0f66fee587e1.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\79fe6b20-b145-481f-bc45-032e5d12fd11.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\e254c3e3-6354-43e8-9403-db4d59ef2af7.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\de8fbfe9-828a-4cb7-9b1d-f047512db055.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\513660f5-28c8-4336-a9d6-1e1b0f87e219.jpg");
                source.Add(
                    @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\159311bc-4cbf-4ede-b3ef-978931e91ed5.jpg");
            }

            ListView1.ItemsSource = source;

        }
    }
}
