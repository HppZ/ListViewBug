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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ListViewBug
{
    public sealed partial class MyUserControl1 : UserControl
    {
        public MyUserControl1()
        {
            this.InitializeComponent();
            Loaded += MyUserControl1_Loaded;
        }

        private void MyUserControl1_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MyUserControl1_Loaded;

            Load();
        }

        public void Load()
        {
            var source = new List<Model1>();
            for (int i = 0; i < 8; i++)
            {
                if (i == 3)
                {
                    source.Add(new Model1()
                    {
                        Str = @"C:\Users\hp\AppData\Local\Packages\5401eb92-f593-4f07-9653-7e7d720d694d_frh6kvfkqjj2p\LocalState\thumbnails\4b3b3c1b-65d0-4e1e-8670-3de4b8024409.jpg"
                    });
                }
                else
                {
                    source.Add(new Model1()
                    {
                        Str = @"http://pic8.iqiyipic.com/image/20181030/56/d3/v_109324118_m_601_m1_284_160.jpg"
                    });
                }
            }

            ListView1.ItemsSource = source;
        }

    }

    class Model1
    {
        public string Str { get; set; }
    }
}
