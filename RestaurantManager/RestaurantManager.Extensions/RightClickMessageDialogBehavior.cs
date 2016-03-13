using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace RestaurantManager.Extensions
{
    public class RightClickMessageDialogBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }
        

        public void Attach(DependencyObject associatedObject)
        {
            this.AssociatedObject = associatedObject;
            (this.AssociatedObject as Page).RightTapped += Page_RightClick;
        }

        public void Detach()
        {
            (this.AssociatedObject as Page).RightTapped -= Page_RightClick;

        }

        private void Page_RightClick(object sender, RoutedEventArgs e)
        {
            new MessageDialog("Thank you for trying out the demo").ShowAsync();
        }
    }
}
