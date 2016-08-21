using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace AutoDataTemplateSelector
{
    public class AutoDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore( object item ) => GetTemplateForItem( item, null );

        protected override DataTemplate SelectTemplateCore( object item, DependencyObject container ) => GetTemplateForItem( item, container );

        private DataTemplate GetTemplateForItem( object item, DependencyObject container )
        {
            if ( item != null )
            {
                var viewModelTypeName = item.GetType().Name;
                var dataTemplateInTree = FindResourceKeyUpTree( viewModelTypeName, container );
                //return or default to Application resource
                return dataTemplateInTree ?? ( DataTemplate )Application.Current.Resources[ viewModelTypeName ];
            }
            return null;
        }

        /// <summary>
        /// Tries to find the resources up the tree
        /// </summary>
        /// <param name="resourceKey">Key to find</param>
        /// <param name="container">Current container</param>
        /// <returns></returns>
        private DataTemplate FindResourceKeyUpTree( string resourceKey, DependencyObject container )
        {
            var frameworkElement = container as FrameworkElement;
            if ( frameworkElement != null )
            {
                if ( frameworkElement.Resources.ContainsKey( resourceKey ) )
                {
                    return frameworkElement.Resources[ resourceKey ] as DataTemplate;
                }
                else
                {
                    return FindResourceKeyUpTree( resourceKey, VisualTreeHelper.GetParent( frameworkElement ) );
                }
            }
            return null;
        }
    }
}