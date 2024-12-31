// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.ComponentModel;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.poposu
{
    public partial class poposuInputManager : RulesetInputManager<poposuAction>
    {
        public poposuInputManager(RulesetInfo ruleset)
            : base(ruleset, 0, SimultaneousBindingMode.Unique)
        {
        }
    }

    public enum poposuAction
    {
        [Description("Button 1")]
        Button1,

        [Description("Button 2")]
        Button2,

        [Description("Button 3")]
        Button3,

        [Description("Button 4")]
        Button4,

        [Description("Button 5")]
        Button5,

        [Description("Button 6")]
        Button6,

        [Description("Button 7")]
        Button7,

        [Description("Button 8")]
        Button8,

        [Description("Button 9")]
        Button9,
    }
}
