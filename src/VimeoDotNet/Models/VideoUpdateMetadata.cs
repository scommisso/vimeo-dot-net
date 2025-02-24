﻿using JetBrains.Annotations;
using System.Collections.Generic;
using VimeoDotNet.Enums;

namespace VimeoDotNet.Models
{
    /// <summary>
    /// Video update metadata model
    /// </summary>
    public class VideoUpdateMetadata
    {
        /// <summary>
        /// The new title for the video
        /// </summary>
        /// <value>The name.</value>
        [PublicAPI]
        public string Name { get; set; }

        /// <summary>
        /// The new description for the video
        /// </summary>
        /// <value>The description.</value>
        [PublicAPI]
        public string Description { get; set; }

        /// <summary>
        /// The new privacy setting for the video.
        /// Content-type application/json is the only valid type for type "users",
        /// basic users can not set privacy to unlisted.
        /// </summary>
        /// <value>The privacy.</value>
        [PublicAPI]
        public VideoPrivacyEnum? Privacy { get; set; }

        /// <summary>
        /// The videos new embed settings. Whitelist allows you to define all valid embed domains.
        /// Check out our docs for adding and removing domains.
        /// </summary>
        /// <value>The embed privacy.</value>
        [PublicAPI]
        public VideoEmbedPrivacyEnum? EmbedPrivacy { get; set; }

        /// <summary>
        /// Enable or disable the review page
        /// </summary>
        /// <value><c>null</c> if [review link enabled] contains no value, <c>true</c> if [review link enabled]; otherwise, <c>false</c>.</value>
        [PublicAPI]
        public bool? ReviewLinkEnabled { get; set; }

        /// <summary>
        /// When you set privacy to password, you must provide the password as an additional parameter
        /// </summary>
        /// <value>The password.</value>
        [PublicAPI]
        public string Password { get; set; }

        /// <summary>
        /// The privacy for who can comment on the video.
        /// </summary>
        /// <value>The comments.</value>
        [PublicAPI]
        public VideoCommentsEnum? Comments { get; set; }

        /// <summary>
        /// Enable or disable the ability for anyone to add the video to an album, channel, or group.
        /// </summary>
        /// <value><c>null</c> if [allow add to album channel group] contains no value, <c>true</c> if [allow add to album channel group]; otherwise, <c>false</c>.</value>
        [PublicAPI]
        public bool? AllowAddToAlbumChannelGroup { get; set; }

        /// <summary>
        /// Enable or disable the ability for anyone to download video.
        /// </summary>
        /// <value><c>null</c> if [allow download video] contains no value, <c>true</c> if [allow download video]; otherwise, <c>false</c>.</value>
        [PublicAPI]
        public bool? AllowDownloadVideo { get; set; }

        /// <summary>
        /// Gets or sets the spatial.
        /// </summary>
        /// <value>The spatial.</value>
        [PublicAPI]
        [CanBeNull]
        public SpatialUpdateMetadata Spatial { get; set; }

        /// <inheritdoc />
        [PublicAPI]
        public IDictionary<string, string> GetParameterValues()
        {
            var parameters = new Dictionary<string, string>();

            if (Name != null)
            {
                parameters["name"] = Name.Trim();
            }

            if (Description != null)
            {
                parameters["description"] = Description.Trim();
            }

            if (Privacy != null)
            {
                parameters["privacy.view"] = Privacy.ToString().ToLower();
            }

            if (Privacy == VideoPrivacyEnum.Password)
            {
                parameters["password"] = Password;
            }

            if (EmbedPrivacy != null)
            {
                parameters["privacy.embed"] = EmbedPrivacy.ToString().ToLower();
            }

            if (Comments != null)
            {
                parameters["privacy.comments"] = Comments.ToString().ToLower();
            }

            if (ReviewLinkEnabled.HasValue)
            {
                parameters["review_page"] = ReviewLinkEnabled.Value ? "true" : "false";
            }

            if (AllowDownloadVideo.HasValue)
            {
                parameters["privacy.download"] = AllowDownloadVideo.Value ? "true" : "false";
            }

            if (AllowAddToAlbumChannelGroup.HasValue)
            {
                parameters["privacy.add"] = AllowAddToAlbumChannelGroup.Value ? "true" : "false";
            }

            Spatial?.SetParameterValues(parameters, "spatial");


            return parameters;
        }
    }
}