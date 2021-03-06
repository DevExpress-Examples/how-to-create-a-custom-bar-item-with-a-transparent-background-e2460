﻿// Developer Express Code Central Example:
// How to create a custom bar item with a transparent background
// 
// This sample demonstrates how to create a custom bar item with a transparent
// background. As an ancestor of a custom bar item the BarLargeButtonItem control
// has been chosen. This approach can be used to create items with a custom shape
// by adding images to the LargeGlyph, LargeGlyphHot and LargeGlyphPressed
// properties.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2460

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Styles;

namespace CustomTransparentBarItem {
    public class BarTransparentButtonItem : BarLargeButtonItem {
        public const string BaseBarItemName = "BarLargeButtonItem";
        public const string BarItemName = "BarTransparentButtonItem";
        public const string BarItemCaption = "Transparent button";

        private Image largeGlyphPressed;
        private int largeImageIndexPressed;

        static BarTransparentButtonItem() {
            Register();
        }
        public static void Register() {
            Register(BarAndDockingController.Default);
        }
        public static void Register(BarAndDockingController controller) {
            Register(controller.PaintStyles);
        }
        public static void Register(BarManagerPaintStyleCollection styles) {
            for(int i = 0; i < styles.Count; i++) {
                BarManagerPaintStyle paintStyle = styles[i];
                BarItemInfo list = paintStyle.ItemInfoCollection[BaseBarItemName];
                if(list != null && paintStyle.ItemInfoCollection[BarItemName] == null) {
                    paintStyle.ItemInfoCollection.Add(new BarItemInfo(BarItemName, BarItemCaption, -1, typeof(BarTransparentButtonItem), list.LinkType,
                                                                        typeof(BarTransparentButtonLinkViewInfo), list.LinkPainter, true, false));
                }
            }
        }

        public BarTransparentButtonItem()
            : base() {
            largeGlyphPressed = null;
            largeImageIndexPressed = -1;
        }
        public BarTransparentButtonItem(BarManager manager, string caption)
            : base(manager, caption) {
        }
        public BarTransparentButtonItem(BarManager manager, string caption, int imageIndex)
            : base(manager, caption, imageIndex) {
        }
        public BarTransparentButtonItem(BarManager manager, string caption, int imageIndex, BarShortcut shortcut)
            : base(manager, caption, imageIndex, shortcut) {
        }

        [Description("Gets or sets the large image displayed within associated links when they are pressed."), DefaultValue(null), Category("Appearance")]
        public virtual Image LargeGlyphPressed {
            get {
                return largeGlyphPressed;
            }
            set {
                if(LargeGlyphHot == value)
                    return;
                largeGlyphPressed = UpdateImage(value);
                OnItemChanged();
            }
        }

        [Description("Gets or sets the index of the large image displayed within associated links when they are pressed."), DefaultValue(-1), Category("Appearance"), Editor(typeof(DevExpress.Utils.Design.ImageIndexesEditor), typeof(UITypeEditor)), ImageList("LargeImages")]
        public virtual int LargeImageIndexPressed {
            get {
                return largeImageIndexPressed;
            }
            set {
                if(LargeImageIndexHot == value)
                    return;
                largeImageIndexPressed = value;
                OnItemChanged();
            }
        }
    }
}
