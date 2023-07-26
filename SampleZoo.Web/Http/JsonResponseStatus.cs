﻿using Microsoft.AspNetCore.Mvc;

namespace SampleZoo.Web.Http
{
    public static class JsonResponseStatus
    {
        public static JsonResult SendStatus(this JsonResponseStatusType type, string message, object? data = null) =>
             new JsonResult(new { status = type.ToString(), message = message, data = data });
    }


    public enum JsonResponseStatusType
    {
        Success,
        Warning,
        Danger,
        Info
    }
}
