using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace QYClient.UIKit
{
    public sealed class NonTouchScrollEnhancer : ContentControl
    {
        CardScrollViewer _viewer;

        public event NonTouchScrollEnhancerButtonVisiblityChanged ButtonVisibilityChangedEvent;

        public int Step
        {
            get { return (int)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(int), typeof(NonTouchScrollEnhancer), new PropertyMetadata(0, (d, e) => {
                var viewer = ((NonTouchScrollEnhancer)d)._viewer;
                if (viewer != null)
                {
                    viewer.Step = (int)e.NewValue;
                }
            }));

        public double StepOffset
        {
            get { return (double)GetValue(StepOffsetProperty); }
            set { SetValue(StepOffsetProperty, value); }
        }

        public static readonly DependencyProperty StepOffsetProperty =
            DependencyProperty.Register("StepOffset", typeof(double), typeof(NonTouchScrollEnhancer), new PropertyMetadata(0d, (d, e) => {
                var viewer = ((NonTouchScrollEnhancer)d)._viewer;
                if (viewer != null)
                {
                    viewer.StepOffset = (double)e.NewValue;
                }
            }));

        public static readonly DependencyProperty ScrollButtonHeightProperty = DependencyProperty.Register(
            "ScrollButtonHeight", typeof(double), typeof(NonTouchScrollEnhancer), new PropertyMetadata(double.NaN));

        public double ScrollButtonHeight
        {
            get { return (double) GetValue(ScrollButtonHeightProperty); }
            set { SetValue(ScrollButtonHeightProperty, value); }
        }

        private ContentPresenter _contentPresenter;
        private Button _leftButton;
        private Button _rightButton;

        public NonTouchScrollEnhancer()
        {
            this.DefaultStyleKey = typeof(NonTouchScrollEnhancer);
        }
        
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this._contentPresenter != null)
                _contentPresenter.SizeChanged -= ContentPresenter_SizeChanged;

            _contentPresenter = GetTemplateChild("contentPresenter") as ContentPresenter;
            if (_contentPresenter != null)
            {
                _contentPresenter.SizeChanged += ContentPresenter_SizeChanged;
            }
        }

        private void ContentPresenter_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var scrollViewer = _contentPresenter.FindDescendant<ScrollViewer>();
            if (scrollViewer != null)
            {
                _viewer = new CardScrollViewer(GetTemplateChild("rootGrid") as Grid, 
                    scrollViewer,
                    GetTemplateChild("btnLeft") as Button, 
                    GetTemplateChild("btnRight") as Button);
                _viewer.ButtonVisibilityChangedEvent += _viewer_ButtonVisibilityChangedEvent;
                _viewer.Step = Step;
                _viewer.StepOffset = StepOffset;
                _contentPresenter.SizeChanged -= ContentPresenter_SizeChanged;
            }
        }

        private void _viewer_ButtonVisibilityChangedEvent(Visibility leftButtonVisiblity, Visibility rightButtonVisiblity)
        {
            this.ButtonVisibilityChangedEvent?.Invoke(leftButtonVisiblity, rightButtonVisiblity);
        }



    }


    public static class   MyClass
    {
        public static T FindDescendant<T>(this DependencyObject element)
            where T : DependencyObject
        {
            T retValue = null;
            var childrenCount = VisualTreeHelper.GetChildrenCount(element);

            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(element, i);
                var type = child as T;
                if (type != null)
                {
                    retValue = type;
                    break;
                }

                retValue = FindDescendant<T>(child);

                if (retValue != null)
                {
                    break;
                }
            }

            return retValue;
        }
    }

}
