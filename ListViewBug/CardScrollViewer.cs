using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Devices.Input;
using Windows.UI.Xaml.Input;

namespace QYClient.UIKit
{
    public delegate void NonTouchScrollEnhancerButtonVisiblityChanged(Visibility leftButtonVisiblity, Visibility rightButtonVisiblity);

    public class CardScrollViewer
    {
        private ScrollViewer scrollViewer;
        private Button leftBtn;
        private Button rightBtn;
        private PointerDeviceType? currentDeviceType;

        public int Step { get; set; }
        public double StepOffset { get; set; }

        public event NonTouchScrollEnhancerButtonVisiblityChanged ButtonVisibilityChangedEvent;

        public CardScrollViewer(UIElement layout, ScrollViewer scrollViewer, Button leftBtn, Button rightBtn)
        {
            this.scrollViewer = scrollViewer;

            if (this.scrollViewer != null)
            {
                if (leftBtn != null)
                {
                    this.leftBtn = leftBtn;
                    leftBtn.Opacity = 0;
                    leftBtn.Click += LeftBtn_Click;
                }

                if (rightBtn != null)
                {
                    this.rightBtn = rightBtn;
                    rightBtn.Opacity = 0;
                    rightBtn.Click += RightBtn_Click;
                }

                scrollViewer.IsHorizontalScrollChainingEnabled = false;
                scrollViewer.IsHorizontalRailEnabled = true;

                scrollViewer.HorizontalScrollMode = ScrollMode.Disabled;
                scrollViewer.VerticalScrollMode = ScrollMode.Disabled;

                scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled; // 它导致的

                layout.PointerEntered += CardScrollViewer_PointerEntered;
                layout.PointerMoved += CardScrollViewer_PointerMoved;
                layout.PointerExited += CardScrollViewer_PointerExited;

                scrollViewer.ViewChanged += ScrollViewer_ViewChanged;
            }
        }
        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            UpdateScrollButtonVisibility();
        }

        private void UpdateScrollButtonVisibility()
        {
            if (_isPointerOver && scrollViewer != null && rightBtn != null && leftBtn != null && scrollViewer.ScrollableWidth > 0 
                && currentDeviceType.HasValue && currentDeviceType.Value != PointerDeviceType.Touch)//手指触摸时，不显示
            {
                leftBtn.Visibility = scrollViewer.HorizontalOffset > 0 ? Visibility.Visible : Visibility.Collapsed;
                rightBtn.Visibility = scrollViewer.ScrollableWidth == scrollViewer.HorizontalOffset ? Visibility.Collapsed : Visibility.Visible;
                ButtonVisibilityChangedEvent?.Invoke(leftBtn.Visibility, rightBtn.Visibility);
            }
        }

        private void CardScrollViewer_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            e.Handled = true;
            leftBtn.Visibility = rightBtn.Visibility = Visibility.Collapsed;
            _isPointerOver = false;
            ButtonVisibilityChangedEvent?.Invoke(leftBtn.Visibility, rightBtn.Visibility);
        }

        private void CardScrollViewer_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            e.Handled = true;
            DeviceStatusCheck(e);
        }
        private bool _isPointerOver = false;
        private void CardScrollViewer_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            e.Handled = true;
            _isPointerOver = true;
            DeviceStatusCheck(e);
            UpdateScrollButtonVisibility();
        }

        void DeviceStatusCheck(PointerRoutedEventArgs e)
        {
            if (scrollViewer == null)
                return;

            currentDeviceType = e.Pointer.PointerDeviceType;
            scrollViewer.HorizontalScrollMode = currentDeviceType == PointerDeviceType.Mouse ? ScrollMode.Disabled : ScrollMode.Enabled;
        }

        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            scrollViewer?.ChangeView(scrollViewer.HorizontalOffset + GetOffset(), null, null);
        }

        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            scrollViewer?.ChangeView(scrollViewer.HorizontalOffset - GetOffset(), null, null);
        }

        private double GetOffset()
        {
            if (Step > 0)
            {
                var offset = Step * StepOffset;
                while (offset > scrollViewer.ViewportWidth && offset > StepOffset)
                {
                    offset -= StepOffset;
                }
                return offset;
            }
            else
            {
                return 600;
            }
        }
    }
}
