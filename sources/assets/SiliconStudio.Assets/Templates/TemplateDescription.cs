// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using SiliconStudio.Core;
using SiliconStudio.Core.IO;

namespace SiliconStudio.Assets.Templates
{
    /// <summary>
    /// Description of a template generator that can be displayed in the GameStudio.
    /// </summary>
    [DataContract("Template")]
    [DebuggerDisplay("Id: {Id}, Name: {Name}")]
    public class TemplateDescription : IFileSynchronizable
    {
        /// <summary>
        /// The file extension used when loading/saving this template description.
        /// </summary>
        public const string FileExtension = ".pdxtpl";

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateDescription"/> class.
        /// </summary>
        public TemplateDescription()
        {
            Screenshots = new List<UFile>();
        }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(0)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the short name of this template 
        /// </summary>
        /// <value>The name.</value>
        [DataMember(10)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the scope of this template.
        /// </summary>
        /// <value>The context.</value>
        [DataMember(15)]
        [DefaultValue(TemplateScope.Session)]
        public TemplateScope Scope { get; set; }

        /// <summary>
        /// Gets or sets the order (lower value means higher order)
        /// </summary>
        /// <value>The order.</value>
        [DataMember(17)]
        [DefaultValue(0)]
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        [DataMember(20)]
        [DefaultValue(null)]
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets the icon/bitmap.
        /// </summary>
        /// <value>The icon.</value>
        [DataMember(30)]
        [DefaultValue(null)]
        public UFile Icon { get; set; }

        /// <summary>
        /// Gets the screenshots.
        /// </summary>
        /// <value>The screenshots.</value>
        [DataMember(30)]
        public List<UFile> Screenshots { get; private set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(40)]
        [DefaultValue(null)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a longer description.
        /// </summary>
        /// <value>The longer description.</value>
        [DataMember(43)]
        [DefaultValue(null)]
        public string FullDescription { get; set; }

        /// <summary>
        /// Gets or set the default name for the output package/library.
        /// </summary>
        /// <value>The default output name.</value>
        [DataMember(45)]
        public string DefaultOutputName { get; set; }
        
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [DataMember(60)]
        [DefaultValue(TemplateStatus.None)]
        public TemplateStatus Status { get; set; }

        /// <inheritdoc/>
        [DataMemberIgnore]
        public bool IsDirty { get; set; }

        /// <inheritdoc/>
        [DataMemberIgnore]
        public UFile FullPath { get; set; }

        /// <summary>
        /// Gets the directory from where this template was loaded
        /// </summary>
        /// <value>The resource directory.</value>
        [DataMemberIgnore]
        public UDirectory TemplateDirectory
        {
            get
            {
                return FullPath != null ? FullPath.GetParent() : null;
            }
        }
    }
}