﻿using Markdig.Syntax.Inlines;
using System.Diagnostics;

namespace ResearchMarkDigParser.Renderer
{
    /// <summary>
    /// A HTML renderer for an <see cref="EmphasisInline"/>.
    /// </summary>
    /// <seealso cref="MauiObjectRenderer{EmphasisInline}" /
    public class MauiEmphasisInlineRenderer : MauiObjectRenderer<EmphasisInline>
    {
        /// <summary>
        /// Delegates to get the tag associated to an <see cref="EmphasisInline"/> object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The HTML tag associated to this <see cref="EmphasisInline"/> object</returns>
        public delegate string? GetTagDelegate(EmphasisInline obj);

        /// <summary>
        /// Initializes a new instance of the <see cref="EmphasisInlineRenderer"/> class.
        /// </summary>
        public MauiEmphasisInlineRenderer()
        {
            GetTag = GetDefaultTag;
        }

        /// <summary>
        /// Gets or sets the GetTag delegate.
        /// </summary>
        public GetTagDelegate GetTag { get; set; }

        protected override void Write(MauiRenderer renderer, EmphasisInline obj)
        {
            string? tag = null;
            if (renderer.EnableHtmlForInline)
            {
                tag = GetTag(obj);
                renderer.Write('<');
                renderer.WriteRaw(tag);
                //renderer.WriteAttributes(obj);
                renderer.WriteRaw('>');
            }
            renderer.WriteChildren(obj);
            if (renderer.EnableHtmlForInline)
            {
                renderer.Write("</");
                renderer.WriteRaw(tag);
                renderer.WriteRaw('>');
            }
        }

        /// <summary>
        /// Gets the default HTML tag for ** and __ emphasis.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string? GetDefaultTag(EmphasisInline obj)
        {
            if (obj.DelimiterChar is '*' or '_')
            {
                Debug.Assert(obj.DelimiterCount <= 2);
                return obj.DelimiterCount == 2 ? "strong" : "em";
            }
            return null;
        }
    }
}