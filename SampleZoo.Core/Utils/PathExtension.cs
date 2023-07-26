﻿namespace SampleZoo.Core.Utils
{
    #region path extensions

    public static class PathExtension
    {
        #region user profile image

        public static string OriginalUserProfileImage = "/medias/images/user/profile/original/";

        public static string OriginalUserProfileImageServer =
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/medias/images/user/profile/original/");

        #endregion

        #region Domain Address

        //public static string DomainAddress = "https://localhost:44367";
        public static string DomainAddress = "https://SampleZoo.com";

        #endregion
    }

    #endregion

    #region Images Sizes

    public static class ImagesSizes
    {

    }

    #endregion

    #region image resizes information

    public static class ImageResizesInformation
    {

    }

    #endregion

    public static class FileAcceptableFormats
    {
        public static string ImageAvailableFormat = "image/png, image/jpeg, image/webp";
    }
}