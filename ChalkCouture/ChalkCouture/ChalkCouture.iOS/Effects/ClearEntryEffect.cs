using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChalkCouture.iOS.Effects;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Effects")]
[assembly: ExportEffect(typeof(ClearEntryEffect), "ClearEntryEffect")]
namespace ChalkCouture.iOS.Effects
{
    public class ClearEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ConfigureControl();
        }

        protected override void OnDetached()
        {
        }

        private void ConfigureControl()
        {
            ((UITextField)Control).ClearButtonMode = UITextFieldViewMode.WhileEditing;
        }
    }
}