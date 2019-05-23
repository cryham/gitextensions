using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GitUI.UserControls.RevisionGrid.Graph
{
    public static class RevisionGraphLaneColor
    {
        internal static readonly IReadOnlyList<Color> PresetGraphColors = new[]
{
            Color.FromArgb(33, 226, 33),
            Color.FromArgb(110, 160, 210), // light blue
            Color.FromArgb(214, 214, 23),
            Color.FromArgb(32, 203, 203),
            Color.FromArgb(201, 106, 30),
            Color.FromArgb(140, 120, 220),
            Color.FromArgb(26, 128, 216),
            Color.FromArgb(102, 203, 33),
            Color.FromArgb(201, 66, 35),
            Color.FromArgb(202, 33, 160),
            Color.FromArgb(32, 213, 160),
        };

        public static Color NonRelativeColor { get; } = Color.Gray;

        internal static Brush NonRelativeBrush { get; private set; }

        internal static readonly List<Brush> PresetGraphBrushes = new List<Brush>();

        static RevisionGraphLaneColor()
        {
            foreach (Color color in PresetGraphColors)
            {
                PresetGraphBrushes.Add(new SolidBrush(color));
            }

            NonRelativeBrush = new SolidBrush(NonRelativeColor);
        }

        public static Brush GetBrushForLane(int laneColor)
        {
            return PresetGraphBrushes[Math.Abs(laneColor) % PresetGraphBrushes.Count];
        }
    }
}
