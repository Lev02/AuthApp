using Material.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace AuthApp.Client.Windows.Presentation.Resources.Controls
{
    public partial class IconTabItem : TabItem
    {
        #region Text Dependency Property
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            name: nameof(Text),
            propertyType: typeof(string),
            ownerType: typeof(IconTabItem),
            typeMetadata: new PropertyMetadata(defaultValue: null));

        public string? Text
        {
            get { return (string?)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        #endregion

        #region Icon Dependency Property
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            name: nameof(Icon),
            propertyType: typeof(MaterialIconKind?),
            ownerType: typeof(IconTabItem),
            typeMetadata: new PropertyMetadata(defaultValue: null)
        );

        public MaterialIconKind? Icon
        {
            get { return (MaterialIconKind?)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        #endregion
    }
}
