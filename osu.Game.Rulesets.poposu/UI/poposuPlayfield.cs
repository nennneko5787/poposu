// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Graphics;
using osu.Game.Graphics.Containers;
using osu.Game.Rulesets.UI.Scrolling;
using osuTK.Graphics;

namespace osu.Game.Rulesets.poposu.UI
{
    [Cached]
    public partial class poposuPlayfield : ScrollingPlayfield
    {
        public const float WIDE_LANE_WIDTH = 70;
        public const float NARROW_LANE_WIDTH = 50;

        public const float LANE_COUNT = 9;

        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                new LaneContainer
                {
                    RelativeSizeAxes = Axes.Y,
                    AutoSizeAxes = Axes.X,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Child = new Container
                    {
                        RelativeSizeAxes = Axes.Y,
                        AutoSizeAxes = Axes.X,
                        Padding = new MarginPadding
                        {
                            Left = WIDE_LANE_WIDTH * 5 + NARROW_LANE_WIDTH * 4,
                            Right = WIDE_LANE_WIDTH * 5 + NARROW_LANE_WIDTH * 4,
                        },
                    },
                    Children = new Drawable[]
                    {
                        HitObjectContainer,
                    }
                },
            });
        }

        private partial class LaneContainer : BeatSyncedContainer
        {
            private OsuColour colours;
            private FillFlowContainer fill;

            private readonly Container content = new Container
            {
                RelativeSizeAxes = Axes.Both,
            };

            protected override Container<Drawable> Content => content;

            [BackgroundDependencyLoader]
            private void load(OsuColour colours)
            {
                this.colours = colours;

                InternalChildren = new Drawable[]
                {
                fill = new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.Y,
                    AutoSizeAxes = Axes.X,
                    Colour = colours.BlueLight,
                    Direction = FillDirection.Horizontal,
                },
                content,
                };

                for (int i = 0; i < LANE_COUNT; i++)
                {
                    if (i % 2 == 0)
                    {
                        fill.Add(new Lane
                        {
                            RelativeSizeAxes = Axes.Y,
                            Width = WIDE_LANE_WIDTH,
                        });
                    }
                    else
                    {
                        fill.Add(new Lane
                        {
                            RelativeSizeAxes = Axes.Y,
                            Width = NARROW_LANE_WIDTH,
                        });
                    }
                }
            }

            private partial class Lane : CompositeDrawable
            {
                public Lane()
                {
                    InternalChildren = new Drawable[]
                    {
                    new Box
                    {
                        Colour = Color4.White,
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Width = 0.95f,
                    },
                    };
                }
            }

            protected override void OnNewBeat(int beatIndex, TimingControlPoint timingPoint, EffectControlPoint effectPoint, ChannelAmplitudes amplitudes)
            {
                if (effectPoint.KiaiMode)
                    fill.FlashColour(colours.PinkLight, 800, Easing.In);
            }
        }
    }
}
