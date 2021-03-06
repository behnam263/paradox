﻿// <auto-generated>
// Do not edit this file yourself!
//
// This code was generated by Paradox Shader Mixin Code Generator.
// To generate it yourself, please install SiliconStudio.Paradox.VisualStudio.Package .vsix
// and re-save the associated .pdxfx.
// </auto-generated>

using System;
using SiliconStudio.Core;
using SiliconStudio.Paradox.Effects;
using SiliconStudio.Paradox.Graphics;
using SiliconStudio.Paradox.Shaders;
using SiliconStudio.Core.Mathematics;
using Buffer = SiliconStudio.Paradox.Graphics.Buffer;

using SiliconStudio.Paradox.Effects.Data;
namespace Test
{
    internal static partial class ShaderMixins
    {
        internal partial class MultipleRenderTargetsEffect  : IShaderMixinBuilder
        {
            public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
            {
                context.Mixin(mixin, "ShaderBase");
                context.Mixin(mixin, "TransformationWAndVP");
                context.Mixin(mixin, "PositionVSStream");
                context.Mixin(mixin, "NormalVSStream");
                mixin.Mixin.AddMacro("RENDER_TARGET_COUNT", 3);
                context.Mixin(mixin, "ShadingBase");
                if (context.GetParam(MaterialParameters.AlbedoDiffuse) != null)

                    {
                        var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };
                        context.PushComposition(mixin, "ShadingColor0", __subMixin);
                        context.Mixin(__subMixin, context.GetParam(MaterialParameters.AlbedoDiffuse));
                        context.PopComposition();
                    }

                {
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };
                    context.PushComposition(mixin, "ShadingColor1", __subMixin);
                    context.Mixin(__subMixin, "LinearDepth");
                    context.PopComposition();
                }

                {
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };
                    context.PushComposition(mixin, "ShadingColor2", __subMixin);
                    context.Mixin(__subMixin, "NormalColor");
                    context.PopComposition();
                }
            }

            [ModuleInitializer]
            internal static void __Initialize__()

            {
                ShaderMixinManager.Register("MultipleRenderTargetsEffect", new MultipleRenderTargetsEffect());
            }
        }
    }
}
